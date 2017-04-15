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
    public partial class frmNeckData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cNeckDataInfo NeckDataInfo = new BID.BaseClass.cNeckDataInfo();
        int G_Int_addOrUpdate = 0;

        public frmNeckData()
        {
            InitializeComponent();
        }
        private void frmNeckData_Load(object sender, EventArgs e)
        {
            
            dgvNeckDataList.DataSource = baseinfo.GetAllNeckData("NeckData").Tables[0].DefaultView;
            this.SetdgvNeckDataListHeadText();
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
            ds = baseinfo.GetAllNeckData("NeckData");


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
            txtCervixThickness.Text = string.Empty;
            txtNeckGirth.Text = string.Empty;
            txtMidNeckGirth.Text = string.Empty;
           
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            this.cancelEnabled();
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
                    NeckDataInfo.id = txtID.Text;
                    NeckDataInfo.cervixThickness = txtCervixThickness.Text;   
                    NeckDataInfo.midNeckGirth = txtMidNeckGirth.Text;
                    NeckDataInfo.neckGirth = txtNeckGirth.Text;

                    //执行添加
                    int id = baseinfo.AddNeckData(NeckDataInfo);
                    MessageBox.Show("新增--肩部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                NeckDataInfo.id = txtID.Text;
                NeckDataInfo.cervixThickness = txtCervixThickness.Text;
                NeckDataInfo.midNeckGirth = txtMidNeckGirth.Text;
                NeckDataInfo.neckGirth = txtNeckGirth.Text;

                //执行修改
                int id = baseinfo.UpdateNeckData(NeckDataInfo);
                MessageBox.Show("修改--肩部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvNeckDataList.DataSource = baseinfo.GetAllNeckData("NeckData").Tables[0].DefaultView;
            this.SetdgvNeckDataListHeadText();
            this.cancelEnabled();
        }
        //查询颈部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbNeckDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbNeckDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindNeckData.Text.Trim() == string.Empty)
                {
                    dgvNeckDataList.DataSource = baseinfo.GetAllNeckData("NeckData").Tables[0].DefaultView;
                    this.SetdgvNeckDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbNeckDataType.Text == "ID")  //按编号查询
            {
                NeckDataInfo.id = tlTxtFindNeckData.Text;
                ds = baseinfo.FindNeckDataByID(NeckDataInfo, "NeckData");
                dgvNeckDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvNeckDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvNeckDataListHeadText()
        {
            dgvNeckDataList.Columns[0].HeaderText = "ID";
            dgvNeckDataList.Columns[1].HeaderText = "颈根厚";
            dgvNeckDataList.Columns[2].HeaderText = "颈中围";
            dgvNeckDataList.Columns[3].HeaderText = "颈围";
          

        }

        private void dgvNeckDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvNeckDataList[0, dgvNeckDataList.CurrentCell.RowIndex].Value.ToString();
            txtCervixThickness.Text = this.dgvNeckDataList[1, dgvNeckDataList.CurrentCell.RowIndex].Value.ToString();
            txtMidNeckGirth.Text = this.dgvNeckDataList[2, dgvNeckDataList.CurrentCell.RowIndex].Value.ToString();
            txtNeckGirth.Text = this.dgvNeckDataList[3, dgvNeckDataList.CurrentCell.RowIndex].Value.ToString();
            
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--颈部数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NeckDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteNeckData(NeckDataInfo);
            MessageBox.Show("删除--颈部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvNeckDataList.DataSource = baseinfo.GetAllNeckData("NeckData").Tables[0].DefaultView;
            this.SetdgvNeckDataListHeadText();
            this.clearText();
        }
    }
}
