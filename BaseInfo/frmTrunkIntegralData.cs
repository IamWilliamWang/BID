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
    public partial class frmTrunkIntegralData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cTrunkIntegralDataInfo TrunkIntegralDataInfo = new BID.BaseClass.cTrunkIntegralDataInfo();
        int G_Int_addOrUpdate = 0;
        public frmTrunkIntegralData()
        {
            InitializeComponent();
        }
        private void frmTrunkIntegralData_Load(object sender, EventArgs e)
        {
            
            dgvTrunkIntegralDataList.DataSource = baseinfo.GetAllTrunkIntegralData("TrunkIntegralData").Tables[0].DefaultView;
            this.SetdgvTrunkIntegralDataListHeadText();
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
            ds = baseinfo.GetAllTrunkIntegralData("TrunkIntegralData");


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
            txtBodyHigh.Text = string.Empty;
            txtCervicalHeight.Text = string.Empty;
            txtCervicalHip.Text = string.Empty;
            txtCervicalHeightKnee.Text = string.Empty;
            txtCervicalWaist.Text = string.Empty;
            txtScapulaHeight.Text = string.Empty;
            txtBreastHeight.Text = string.Empty;
            txtNeckFrontHeight.Text = string.Empty;
           
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
                    TrunkIntegralDataInfo.id = txtID.Text;
                    TrunkIntegralDataInfo.bodyHigh = txtBodyHigh.Text;
                    TrunkIntegralDataInfo.cervicalHeight = txtCervicalHeight.Text;
                    TrunkIntegralDataInfo.cervicalHip = txtCervicalHip.Text;
                    TrunkIntegralDataInfo.cervicalHeightKnee = txtCervicalHeightKnee.Text;
                    TrunkIntegralDataInfo.cervicalWaist = txtCervicalWaist.Text;
                    TrunkIntegralDataInfo.scapulaHeight = txtScapulaHeight.Text;
                    TrunkIntegralDataInfo.breastHeight = txtBreastHeight.Text;
                    TrunkIntegralDataInfo.neckFrontHeight = txtNeckFrontHeight.Text;
                    
                    //执行添加
                    int id = baseinfo.AddTrunkIntegralData(TrunkIntegralDataInfo);
                    MessageBox.Show("新增--躯干数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                TrunkIntegralDataInfo.id = txtID.Text;
                TrunkIntegralDataInfo.bodyHigh = txtBodyHigh.Text;
                TrunkIntegralDataInfo.cervicalHeight = txtCervicalHeight.Text;
                TrunkIntegralDataInfo.cervicalHip = txtCervicalHip.Text;
                TrunkIntegralDataInfo.cervicalHeightKnee = txtCervicalHeightKnee.Text;
                TrunkIntegralDataInfo.cervicalWaist = txtCervicalWaist.Text;
                TrunkIntegralDataInfo.scapulaHeight = txtScapulaHeight.Text;
                TrunkIntegralDataInfo.breastHeight = txtBreastHeight.Text;
                TrunkIntegralDataInfo.neckFrontHeight = txtNeckFrontHeight.Text;

                //执行修改
                int id = baseinfo.UpdateTrunkIntegralData(TrunkIntegralDataInfo);
                MessageBox.Show("修改--头部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvTrunkIntegralDataList.DataSource = baseinfo.GetAllTrunkIntegralData("TrunkIntegralData").Tables[0].DefaultView;
            this.SetdgvTrunkIntegralDataListHeadText();
            this.cancelEnabled();
        }
        //查询头部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbTrunkIntegralDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbTrunkIntegralDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindTrunkIntegralData.Text.Trim() == string.Empty)
                {
                    dgvTrunkIntegralDataList.DataSource = baseinfo.GetAllTrunkIntegralData("TrunkIntegralData").Tables[0].DefaultView;
                    this.SetdgvTrunkIntegralDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbTrunkIntegralDataType.Text == "ID")  //按编号查询
            {
                TrunkIntegralDataInfo.id = tlTxtFindTrunkIntegralData.Text;
                ds = baseinfo.FindTrunkIntegralDataByID(TrunkIntegralDataInfo, "TrunkIntegralData");
                dgvTrunkIntegralDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvTrunkIntegralDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvTrunkIntegralDataListHeadText()
        {
            dgvTrunkIntegralDataList.Columns[0].HeaderText = "ID";
            dgvTrunkIntegralDataList.Columns[1].HeaderText = "身高";
            dgvTrunkIntegralDataList.Columns[2].HeaderText = "颈椎点高";
            dgvTrunkIntegralDataList.Columns[3].HeaderText = "颈臀距";
            dgvTrunkIntegralDataList.Columns[4].HeaderText = "颈膝距";
            dgvTrunkIntegralDataList.Columns[5].HeaderText = "背长";
            dgvTrunkIntegralDataList.Columns[6].HeaderText = "肩胛骨高";
            dgvTrunkIntegralDataList.Columns[7].HeaderText = "胸围高";
            dgvTrunkIntegralDataList.Columns[8].HeaderText = "前颈点高";
           

        }

        private void dgvTrunkIntegralDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvTrunkIntegralDataList[0, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtBodyHigh.Text = this.dgvTrunkIntegralDataList[1, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtCervicalHeight.Text = this.dgvTrunkIntegralDataList[2, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtCervicalHip.Text = this.dgvTrunkIntegralDataList[3, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtCervicalHeightKnee.Text = this.dgvTrunkIntegralDataList[4, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtCervicalWaist.Text = this.dgvTrunkIntegralDataList[5, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtScapulaHeight.Text = this.dgvTrunkIntegralDataList[6, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtBreastHeight.Text = this.dgvTrunkIntegralDataList[7, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            txtNeckFrontHeight.Text = this.dgvTrunkIntegralDataList[8, dgvTrunkIntegralDataList.CurrentCell.RowIndex].Value.ToString();
            
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--躯干数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TrunkIntegralDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteTrunkIntegralData(TrunkIntegralDataInfo);
            MessageBox.Show("删除--躯干数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTrunkIntegralDataList.DataSource = baseinfo.GetAllTrunkIntegralData(" TrunkIntegralData").Tables[0].DefaultView;
            this.SetdgvTrunkIntegralDataListHeadText();
            this.clearText();
        }
    }
}
