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
    public partial class frmLowerLimbsData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cLowerLimbsDataInfo LowerLimbsDataInfo = new BID.BaseClass.cLowerLimbsDataInfo();
        int G_Int_addOrUpdate = 0;
        public frmLowerLimbsData()
        {
            InitializeComponent();
        }
        private void frmLowerLimbsData_Load(object sender, EventArgs e)
        {
           
            dgvLowerLimbsDataList.DataSource = baseinfo.GetAllLowerLimbsData("LowerLimbsData").Tables[0].DefaultView;
            this.SetdgvLowerLimbsDataListHeadText();
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
            ds = baseinfo.GetAllLowerLimbsData("LowerLimbsData");


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
            txtInsideLegLengthLeft.Text = string.Empty;
            txtInsideLegLengthRight.Text = string.Empty;
            txtSideLengthToWaistLeft.Text = string.Empty;
            txtSideLengthToWaistRight.Text = string.Empty;
            txtLateralHeightOfWaistLeft.Text = string.Empty;
            txtLateralHeightOfWaistRight.Text = string.Empty;
            txtThighGirthLeft.Text = string.Empty;
            txtThighGirthRight.Text = string.Empty;
            txtKneeGirthLeft.Text = string.Empty;
            txtKneeGirthRight.Text = string.Empty;
            txtCalfGirthLeft.Text = string.Empty;
            txtCalfGirthRight.Text = string.Empty;
            txtAnkleGirthLeft.Text = string.Empty;
            txtAnkleGirthRight.Text = string.Empty;
            txtWaistKnee.Text = string.Empty;
            txtWaistHeight.Text = string.Empty;
            txtHipHeight.Text = string.Empty;
            txtMaximumHipHeight.Text = string.Empty;
            txtCrothHeight.Text = string.Empty;
            txtBellyHeight.Text = string.Empty;
            txtMaximuBellyHeight.Text = string.Empty;
            txtCrothToWaistband.Text = string.Empty;
            txtCrothLength.Text = string.Empty;
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
                    LowerLimbsDataInfo.id = txtID.Text;
                    LowerLimbsDataInfo.insideLegLengthLeft  = txtInsideLegLengthLeft.Text;
                    LowerLimbsDataInfo.insideLegLengthRight = txtInsideLegLengthRight.Text;
                    LowerLimbsDataInfo.sideLengthToWaistLeft = txtSideLengthToWaistLeft.Text;
                    LowerLimbsDataInfo.sideLengthToWaistRight = txtSideLengthToWaistRight.Text;
                    LowerLimbsDataInfo.lateralHeightOfWaistLeft = txtLateralHeightOfWaistLeft.Text;
                    LowerLimbsDataInfo.lateralHeightOfWaistRight = txtLateralHeightOfWaistRight.Text;
                    LowerLimbsDataInfo.thighGirthLeft = txtThighGirthLeft.Text;
                    LowerLimbsDataInfo.thighGirthRight = txtThighGirthRight.Text;
                    LowerLimbsDataInfo.kneeGirthLeft = txtKneeGirthLeft.Text;
                    LowerLimbsDataInfo.kneeGirthRight = txtKneeGirthRight.Text;
                    LowerLimbsDataInfo.calfGirthLeft = txtCalfGirthLeft.Text;
                    LowerLimbsDataInfo.calfGirthRight = txtCalfGirthRight.Text;
                    LowerLimbsDataInfo.ankleGirthLeft = txtAnkleGirthLeft.Text;
                    LowerLimbsDataInfo.ankleGirthRight = txtAnkleGirthRight.Text;
                    LowerLimbsDataInfo.waistKnee = txtWaistKnee.Text;
                    LowerLimbsDataInfo.waistHeight = txtWaistHeight.Text;
                    LowerLimbsDataInfo.hipHeight = txtHipHeight.Text;
                    LowerLimbsDataInfo.maximumHipHeight = txtMaximumHipHeight.Text;
                    LowerLimbsDataInfo.crothHeight = txtCrothHeight.Text;
                    LowerLimbsDataInfo.bellyHeight = txtBellyHeight.Text;
                    LowerLimbsDataInfo.maximuBellyHeight = txtMaximuBellyHeight.Text;
                    LowerLimbsDataInfo.crothToWaistband = txtCrothToWaistband.Text;
                    LowerLimbsDataInfo.crothLength = txtCrothLength.Text;
                    //执行添加
                    int id = baseinfo.AddLowerLimbsData(LowerLimbsDataInfo);
                    MessageBox.Show("新增--下肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                LowerLimbsDataInfo.id = txtID.Text;
                LowerLimbsDataInfo.insideLegLengthLeft = txtInsideLegLengthLeft.Text;
                LowerLimbsDataInfo.insideLegLengthRight = txtInsideLegLengthRight.Text;
                LowerLimbsDataInfo.sideLengthToWaistLeft = txtSideLengthToWaistLeft.Text;
                LowerLimbsDataInfo.sideLengthToWaistRight = txtSideLengthToWaistRight.Text;
                LowerLimbsDataInfo.lateralHeightOfWaistLeft = txtLateralHeightOfWaistLeft.Text;
                LowerLimbsDataInfo.lateralHeightOfWaistRight = txtLateralHeightOfWaistRight.Text;
                LowerLimbsDataInfo.thighGirthLeft = txtThighGirthLeft.Text;
                LowerLimbsDataInfo.thighGirthRight = txtThighGirthRight.Text;
                LowerLimbsDataInfo.kneeGirthLeft = txtKneeGirthLeft.Text;
                LowerLimbsDataInfo.kneeGirthRight = txtKneeGirthRight.Text;
                LowerLimbsDataInfo.calfGirthLeft = txtCalfGirthLeft.Text;
                LowerLimbsDataInfo.calfGirthRight = txtCalfGirthRight.Text;
                LowerLimbsDataInfo.ankleGirthLeft = txtAnkleGirthLeft.Text;
                LowerLimbsDataInfo.ankleGirthRight = txtAnkleGirthRight.Text;
                LowerLimbsDataInfo.waistKnee = txtWaistKnee.Text;
                LowerLimbsDataInfo.waistHeight = txtWaistHeight.Text;
                LowerLimbsDataInfo.hipHeight = txtHipHeight.Text;
                LowerLimbsDataInfo.maximumHipHeight = txtMaximumHipHeight.Text;
                LowerLimbsDataInfo.crothHeight = txtCrothHeight.Text;
                LowerLimbsDataInfo.bellyHeight = txtBellyHeight.Text;
                LowerLimbsDataInfo.maximuBellyHeight = txtMaximuBellyHeight.Text;
                LowerLimbsDataInfo.crothToWaistband = txtCrothToWaistband.Text;
                LowerLimbsDataInfo.crothLength = txtCrothLength.Text;

                //执行修改
                int id = baseinfo.UpdateLowerLimbsData(LowerLimbsDataInfo);
                MessageBox.Show("修改--下肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvLowerLimbsDataList.DataSource = baseinfo.GetAllLowerLimbsData("LowerLimbsData").Tables[0].DefaultView;
            this.SetdgvLowerLimbsDataListHeadText();
            this.cancelEnabled();
        }
        //查询头部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbLowerLimbsDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbLowerLimbsDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindLowerLimbsData.Text.Trim() == string.Empty)
                {
                    dgvLowerLimbsDataList.DataSource = baseinfo.GetAllLowerLimbsData("LowerLimbsData").Tables[0].DefaultView;
                    this.SetdgvLowerLimbsDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbLowerLimbsDataType.Text == "ID")  //按编号查询
            {
                LowerLimbsDataInfo.id = tlTxtFindLowerLimbsData.Text;
                ds = baseinfo.FindLowerLimbsDataByID(LowerLimbsDataInfo, "LowerLimbsData");
                dgvLowerLimbsDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvLowerLimbsDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvLowerLimbsDataListHeadText()
        {
            dgvLowerLimbsDataList.Columns[0].HeaderText = "ID";
            dgvLowerLimbsDataList.Columns[1].HeaderText = "腿内侧长左";
            dgvLowerLimbsDataList.Columns[2].HeaderText = "腿内侧长右";
            dgvLowerLimbsDataList.Columns[3].HeaderText = "腿外侧长左";
            dgvLowerLimbsDataList.Columns[4].HeaderText = "腿外侧长右";
            dgvLowerLimbsDataList.Columns[5].HeaderText = "腿外侧缝长左";
            dgvLowerLimbsDataList.Columns[6].HeaderText = "腿外侧缝长右";
            dgvLowerLimbsDataList.Columns[7].HeaderText = "大腿围左";
            dgvLowerLimbsDataList.Columns[8].HeaderText = "大腿围右";
            dgvLowerLimbsDataList.Columns[9].HeaderText = "膝围左";
            dgvLowerLimbsDataList.Columns[10].HeaderText = "膝围右";
            dgvLowerLimbsDataList.Columns[11].HeaderText = "腿肚围左";
            dgvLowerLimbsDataList.Columns[12].HeaderText = "腿肚围右";
            dgvLowerLimbsDataList.Columns[13].HeaderText = "踝围左";
            dgvLowerLimbsDataList.Columns[14].HeaderText = "踝围右";
            dgvLowerLimbsDataList.Columns[15].HeaderText = "腰膝距";
            dgvLowerLimbsDataList.Columns[16].HeaderText = "腰高";
            dgvLowerLimbsDataList.Columns[17].HeaderText = "臀高";
            dgvLowerLimbsDataList.Columns[18].HeaderText = "臀后突点高";
            dgvLowerLimbsDataList.Columns[19].HeaderText = "会阴高";
            dgvLowerLimbsDataList.Columns[20].HeaderText = "腹高";
            dgvLowerLimbsDataList.Columns[21].HeaderText = "腹部前突点高";
            dgvLowerLimbsDataList.Columns[22].HeaderText = "股上长";
            dgvLowerLimbsDataList.Columns[23].HeaderText = "会阴上部前后长";
        }

        private void dgvLowerLimbsDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvLowerLimbsDataList[0, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtInsideLegLengthLeft.Text = this.dgvLowerLimbsDataList[1, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtInsideLegLengthRight.Text = this.dgvLowerLimbsDataList[2, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtSideLengthToWaistLeft.Text = this.dgvLowerLimbsDataList[3, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtSideLengthToWaistRight.Text = this.dgvLowerLimbsDataList[4, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtLateralHeightOfWaistLeft.Text = this.dgvLowerLimbsDataList[5, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtLateralHeightOfWaistRight.Text = this.dgvLowerLimbsDataList[6, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtThighGirthLeft.Text = this.dgvLowerLimbsDataList[7, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtThighGirthRight.Text = this.dgvLowerLimbsDataList[8, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtKneeGirthLeft.Text = this.dgvLowerLimbsDataList[9, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtKneeGirthRight.Text = this.dgvLowerLimbsDataList[10, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtCalfGirthLeft.Text = this.dgvLowerLimbsDataList[11, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtCalfGirthRight.Text = this.dgvLowerLimbsDataList[12, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtAnkleGirthLeft.Text = this.dgvLowerLimbsDataList[13, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtAnkleGirthRight.Text = this.dgvLowerLimbsDataList[14, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistKnee.Text = this.dgvLowerLimbsDataList[15, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistHeight.Text = this.dgvLowerLimbsDataList[16, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtHipHeight.Text = this.dgvLowerLimbsDataList[17, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtMaximumHipHeight.Text = this.dgvLowerLimbsDataList[18, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtCrothHeight.Text = this.dgvLowerLimbsDataList[19, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtBellyHeight.Text = this.dgvLowerLimbsDataList[20, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtMaximuBellyHeight.Text = this.dgvLowerLimbsDataList[21, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtCrothToWaistband.Text = this.dgvLowerLimbsDataList[22, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtCrothLength.Text = this.dgvLowerLimbsDataList[23, dgvLowerLimbsDataList.CurrentCell.RowIndex].Value.ToString();
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--下肢数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LowerLimbsDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteLowerLimbsData(LowerLimbsDataInfo);
            MessageBox.Show("删除--下肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvLowerLimbsDataList.DataSource = baseinfo.GetAllLowerLimbsData("LowerLimbsData").Tables[0].DefaultView;
            this.SetdgvLowerLimbsDataListHeadText();
            this.clearText();
        }
    }
}
