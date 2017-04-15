using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID.BaseInfo
{
    public partial class frmDataQuery : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cBasicDataInfo BasicDatainfo = new BID.BaseClass.cBasicDataInfo();
        int G_Int_addOrUpdate = 0;

        public frmDataQuery()
        {
            InitializeComponent();
        }

        private void dgvDataQueryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDataQuery_Load(object sender, EventArgs e)
        {
           
            dgvBasicDataList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
            this.SetdgvBasicDataListHeadText();
        }
        private void editEnabled()  //屏毕与此功能无关的按钮
        {
            groupBox1.Enabled = true;     //将容器可以使用，准备添加新的往来单位信息
            tlBtnAdd.Enabled = false;
            tlBtnEdit.Enabled = false;
            tlBtnDelete.Enabled = false;
            tlBtnSave.Enabled = true;
            tlBtnCancel.Enabled = true;
        }
        private void cancelEnabled()
        {
            groupBox1.Enabled = false;
            tlBtnAdd.Enabled = true;
            tlBtnEdit.Enabled = true;
            tlBtnDelete.Enabled = true;
            tlBtnSave.Enabled = false;
            tlBtnCancel.Enabled = false;

        }
        private void clearText()
        {
            txtID.Text = string.Empty;
            txtIDCard.Text = string.Empty;
            cmbSex.Text = string.Empty;
            txtBodyHigh.Text = string.Empty;
            txtAge.Text = string.Empty;
        }
        //设置DataGridView标题
        private void SetdgvBasicDataListHeadText()
        {       
            dgvBasicDataList.Columns[0].HeaderText = "ID";
            dgvBasicDataList.Columns[1].HeaderText = "性别";
            dgvBasicDataList.Columns[2].HeaderText = "年龄";
            dgvBasicDataList.Columns[48].HeaderText = "身高";
            dgvBasicDataList.Columns[5].HeaderText = "身份证前6位";  
        }
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbBasicDataType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbBasicDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindBasicData.Text.Trim() == string.Empty)
                {
                    dgvBasicDataList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
                    this.SetdgvBasicDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbBasicDataType.Text == "ID")  //按编号查询
            {
                BasicDatainfo.id  = tlTxtFindBasicData.Text;
                ds = baseinfo.FindBasicDataByID(BasicDatainfo, "BasicData");
                dgvBasicDataList.DataSource = ds.Tables[0].DefaultView;
            }
            else if (tlCmbBasicDataType.Text == "性别")　//按性别查询
            {
                BasicDatainfo.sex = tlTxtFindBasicData.Text;
                ds = baseinfo.FindBasicDataBySex(BasicDatainfo, "BasicData");
                dgvBasicDataList.DataSource = ds.Tables[0].DefaultView;
            }
            else if (tlCmbBasicDataType.Text == "年龄")　//按年龄查询
            {
                BasicDatainfo.age = tlTxtFindBasicData.Text;
                ds = baseinfo.FindBasicDataByAge(BasicDatainfo, "BasicData");
                dgvBasicDataList.DataSource = ds.Tables[0].DefaultView;
            }
            else if (tlCmbBasicDataType.Text == "身高")　//按身高查询
            {
                BasicDatainfo.bodyhigh = tlTxtFindBasicData.Text;
                ds = baseinfo.FindBasicDataByBodyHigh(BasicDatainfo, "BasicData");
                dgvBasicDataList.DataSource = ds.Tables[0].DefaultView;
            }
            else
            {
                BasicDatainfo.idcard = tlTxtFindBasicData.Text;
                ds = baseinfo.FindBasicDataByIDCard(BasicDatainfo, "BasicData");
                dgvBasicDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvBasicDataListHeadText();

        }

        private void tlBtnAdd_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            this.clearText();
            G_Int_addOrUpdate = 0;   //等于０为添加数据
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = baseinfo.GetAllBasicData("BasicData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txtID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txtID.Text = P_Str_newID;
            }
        }

        private void tlBtnEdit_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            G_Int_addOrUpdate = 1;   //等于１为修改数据
        }

        private void tlBtnSave_Click(object sender, EventArgs e)
        {
            //判断是添加还是修改数据
            if (G_Int_addOrUpdate == 0)
            {
                try
                {
                    //添加数据
                    BasicDatainfo.id  = txtID.Text;
                    BasicDatainfo.idcard  = txtIDCard.Text;
                    BasicDatainfo.sex  = cmbSex.Text;
                    BasicDatainfo.age  = txtAge.Text;
                    BasicDatainfo.bodyhigh  = txtBodyHigh.Text;
                   
                    //执行添加
                    int id = baseinfo.AddBasicData(BasicDatainfo);
                    MessageBox.Show("新增--基础数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                BasicDatainfo.id = txtID.Text;
                BasicDatainfo.idcard = txtIDCard.Text;
                BasicDatainfo.sex = cmbSex.Text;
                BasicDatainfo.age = txtAge.Text;
                BasicDatainfo.bodyhigh = txtBodyHigh.Text;

                //执行修改
                int id = baseinfo.UpdateBasicData(BasicDatainfo);
                MessageBox.Show("修改--基础数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvBasicDataList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
            this.SetdgvBasicDataListHeadText();
            this.cancelEnabled();
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            this.cancelEnabled();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--基础数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BasicDatainfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteBasicData(BasicDatainfo);
            MessageBox.Show("删除--基础数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvBasicDataList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
            this.SetdgvBasicDataListHeadText();
            this.clearText();
        }
        private void dgvBasicDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvBasicDataList[0, dgvBasicDataList.CurrentCell.RowIndex].Value.ToString();
            cmbSex.Text = this.dgvBasicDataList[1, dgvBasicDataList.CurrentCell.RowIndex].Value.ToString();
            txtAge.Text = this.dgvBasicDataList[2, dgvBasicDataList.CurrentCell.RowIndex].Value.ToString();
            txtBodyHigh.Text = this.dgvBasicDataList[48, dgvBasicDataList.CurrentCell.RowIndex].Value.ToString();
            txtIDCard.Text = this.dgvBasicDataList[5, dgvBasicDataList.CurrentCell.RowIndex].Value.ToString();
           
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBasicDataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tlBtnAdd_Click_1(object sender, EventArgs e)
        {
            InfoAddForm.frmAddData FrmAddD = new BID.InfoAddForm.frmAddData();
            FrmAddD.Text = "数据添加操作";
            FrmAddD.Tag = 1;
            FrmAddD.ShowDialog(this);
            ShowAll();
        }
        public void ShowAll()
        {
            BaseClass.BaseInfo.BasicData_ID = "";
            //用dgvBasicDataList控件显示
            dgvBasicDataList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
            
        }
    }
}
