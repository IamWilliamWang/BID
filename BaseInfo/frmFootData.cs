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
    public partial class frmFootData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cFootDataInfo FootDataInfo = new BID.BaseClass.cFootDataInfo();
        int G_Int_addOrUpdate = 0;
        public frmFootData()
        {
            InitializeComponent();
        }
        private void frmFootData_Load(object sender, EventArgs e)
        {
            
            dgvFootDataList.DataSource = baseinfo.GetAllFootData("FootData").Tables[0].DefaultView;
            this.SetdgvFootDataListHeadText();
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
            ds = baseinfo.GetAllFootData("FootData");


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
            txtFootLength.Text = string.Empty;
            txtFootWidth.Text = string.Empty;
            txtFootGirth.Text = string.Empty;
            txtToeHeihet.Text = string.Empty;
            txtFootTarsiHigh.Text = string.Empty;
            txtMedialMalleolusHigh.Text = string.Empty;
            txtLateralMalleolusHigh.Text = string.Empty;
           
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
                    FootDataInfo.id = txtID.Text;
                    FootDataInfo.footLength = txtFootLength.Text;
                    FootDataInfo.footWidth = txtFootWidth.Text;
                    FootDataInfo.footGirth = txtFootGirth.Text;
                    FootDataInfo.toeHeihet = txtToeHeihet.Text;
                    FootDataInfo.footTarsiHigh = txtFootTarsiHigh.Text;
                    FootDataInfo.medialMalleolusHigh = txtMedialMalleolusHigh.Text;
                    FootDataInfo.lateralMalleolusHigh = txtLateralMalleolusHigh.Text;
                    
                    //执行添加
                    int id = baseinfo.AddFootData(FootDataInfo);
                    MessageBox.Show("新增--足部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                FootDataInfo.id = txtID.Text;
                FootDataInfo.footLength = txtFootLength.Text;
                FootDataInfo.footWidth = txtFootWidth.Text;
                FootDataInfo.footGirth = txtFootGirth.Text;
                FootDataInfo.toeHeihet = txtToeHeihet.Text;
                FootDataInfo.footTarsiHigh = txtFootTarsiHigh.Text;
                FootDataInfo.medialMalleolusHigh = txtMedialMalleolusHigh.Text;
                FootDataInfo.lateralMalleolusHigh = txtLateralMalleolusHigh.Text;

                //执行修改
                int id = baseinfo.UpdateFootData(FootDataInfo);
                MessageBox.Show("修改--足部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvFootDataList.DataSource = baseinfo.GetAllFootData("FootData").Tables[0].DefaultView;
            this.SetdgvFootDataListHeadText();
            this.cancelEnabled();
        }
        //查询足部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbFootDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbFootDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindFootData.Text.Trim() == string.Empty)
                {
                    dgvFootDataList.DataSource = baseinfo.GetAllFootData("FootData").Tables[0].DefaultView;
                    this.SetdgvFootDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbFootDataType.Text == "ID")  //按编号查询
            {
                FootDataInfo.id = tlTxtFindFootData.Text;
                ds = baseinfo.FindFootDataByID(FootDataInfo, "FootData");
                dgvFootDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvFootDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvFootDataListHeadText()
        {
            dgvFootDataList.Columns[0].HeaderText = "ID";
            dgvFootDataList.Columns[1].HeaderText = "足长";
            dgvFootDataList.Columns[2].HeaderText = "足宽";
            dgvFootDataList.Columns[3].HeaderText = "足围";
            dgvFootDataList.Columns[4].HeaderText = "足趾高";
            dgvFootDataList.Columns[5].HeaderText = "跗骨点高";
            dgvFootDataList.Columns[6].HeaderText = "内踝高";
            dgvFootDataList.Columns[7].HeaderText = "外踝高";
           

        }

        private void dgvFootDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvFootDataList[0, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
            txtFootLength.Text = this.dgvFootDataList[1, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
            txtFootWidth.Text = this.dgvFootDataList[2, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
            txtFootGirth.Text = this.dgvFootDataList[3, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
            txtToeHeihet.Text = this.dgvFootDataList[4, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
            txtFootTarsiHigh.Text = this.dgvFootDataList[5, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
            txtMedialMalleolusHigh.Text = this.dgvFootDataList[6, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
            txtLateralMalleolusHigh.Text = this.dgvFootDataList[7, dgvFootDataList.CurrentCell.RowIndex].Value.ToString();
           
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--足部数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FootDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteFootData(FootDataInfo);
            MessageBox.Show("删除--足部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvFootDataList.DataSource = baseinfo.GetAllFootData("FootData").Tables[0].DefaultView;
            this.SetdgvFootDataListHeadText();
            this.clearText();
        }

        private void txtFootLength_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
