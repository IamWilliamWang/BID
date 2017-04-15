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
    public partial class frmBellyWaistHipData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cBellyWaistHipDataInfo BellyWaistHipDataInfo = new BID.BaseClass.cBellyWaistHipDataInfo();
        int G_Int_addOrUpdate = 0;

        public frmBellyWaistHipData()
        {
            InitializeComponent();
        }
        private void frmBellyWaistHipData_Load(object sender, EventArgs e)
        {
            
            dgvBellyWaistHipDataList.DataSource = baseinfo.GetAllBellyWaistHipData("BellyWaistHipData").Tables[0].DefaultView;
            this.SetdgvBellyWaistHipDataListHeadText();
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
            ds = baseinfo.GetAllBellyWaistHipData("BellyWaistHipData");


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
            txtWaist.Text = string.Empty;
            txtWaistBackLevelDifference.Text = string.Empty;
            txtHipThickness.Text = string.Empty;
            txtAdominalThickness.Text = string.Empty;
            txtHipGirth.Text = string.Empty;
            txtButtockGirth.Text = string.Empty;
            txtMaximumHipGirth.Text = string.Empty;
            txtBelly.Text = string.Empty;
            txtMaximumBellyCircamference.Text = string.Empty;
            txtWaistPelvisDistance.Text = string.Empty;
            txtWaistPelvisLengthLeft.Text = string.Empty;
            txtWaistPelvisLengthRight.Text = string.Empty;
            txtWaistUnderarmLeft.Text = string.Empty;
            txtWaistUnderarmRight.Text = string.Empty;
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
                    BellyWaistHipDataInfo.id = txtID.Text;
                    BellyWaistHipDataInfo.waist = txtWaist.Text;
                    BellyWaistHipDataInfo.waistBackLevelDifference = txtWaistBackLevelDifference.Text;
                    BellyWaistHipDataInfo.hipThickness = txtHipThickness.Text;
                    BellyWaistHipDataInfo.adominalThickness = txtAdominalThickness.Text;
                    BellyWaistHipDataInfo.hipGirth = txtHipGirth.Text;
                    BellyWaistHipDataInfo.buttockGirth = txtButtockGirth.Text;
                    BellyWaistHipDataInfo.maximumHipGirth = txtMaximumHipGirth.Text;
                    BellyWaistHipDataInfo.belly = txtBelly.Text;
                    BellyWaistHipDataInfo.maximumBellyCircamference = txtMaximumBellyCircamference.Text;
                    BellyWaistHipDataInfo.waistPelvisDistance = txtWaistPelvisDistance.Text;
                    BellyWaistHipDataInfo.waistPelvisLengthLeft = txtWaistPelvisLengthLeft.Text;
                    BellyWaistHipDataInfo.waistPelvisLengthRight = txtWaistPelvisLengthRight.Text;
                    BellyWaistHipDataInfo.waistUnderarmLeft = txtWaistUnderarmLeft.Text;
                    BellyWaistHipDataInfo.waistUnderarmRight = txtWaistUnderarmRight.Text;
                    //执行添加
                    int id = baseinfo.AddBellyWaistHipData(BellyWaistHipDataInfo);
                    MessageBox.Show("新增--腹腰臀部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                BellyWaistHipDataInfo.id = txtID.Text;
                BellyWaistHipDataInfo.waist = txtWaist.Text;
                BellyWaistHipDataInfo.waistBackLevelDifference = txtWaistBackLevelDifference.Text;
                BellyWaistHipDataInfo.hipThickness = txtHipThickness.Text;
                BellyWaistHipDataInfo.adominalThickness = txtAdominalThickness.Text;
                BellyWaistHipDataInfo.hipGirth = txtHipGirth.Text;
                BellyWaistHipDataInfo.buttockGirth = txtButtockGirth.Text;
                BellyWaistHipDataInfo.maximumHipGirth = txtMaximumHipGirth.Text;
                BellyWaistHipDataInfo.belly = txtBelly.Text;
                BellyWaistHipDataInfo.maximumBellyCircamference = txtMaximumBellyCircamference.Text;
                BellyWaistHipDataInfo.waistPelvisDistance = txtWaistPelvisDistance.Text;
                BellyWaistHipDataInfo.waistPelvisLengthLeft = txtWaistPelvisLengthLeft.Text;
                BellyWaistHipDataInfo.waistPelvisLengthRight = txtWaistPelvisLengthRight.Text;
                BellyWaistHipDataInfo.waistUnderarmLeft = txtWaistUnderarmLeft.Text;
                BellyWaistHipDataInfo.waistUnderarmRight = txtWaistUnderarmRight.Text;
                //执行修改
                int id = baseinfo.UpdateBellyWaistHipData(BellyWaistHipDataInfo);
                MessageBox.Show("修改--腹腰臀部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvBellyWaistHipDataList.DataSource = baseinfo.GetAllBellyWaistHipData("BellyWaistHipData").Tables[0].DefaultView;
            this.SetdgvBellyWaistHipDataListHeadText();
            this.cancelEnabled();
        }
        //查询头部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbBellyWaistHipDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbBellyWaistHipDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindBellyWaistHipData.Text.Trim() == string.Empty)
                {
                    dgvBellyWaistHipDataList.DataSource = baseinfo.GetAllBellyWaistHipData("BellyWaistHipData").Tables[0].DefaultView;
                    this.SetdgvBellyWaistHipDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbBellyWaistHipDataType.Text == "ID")  //按编号查询
            {
                BellyWaistHipDataInfo.id = tlTxtFindBellyWaistHipData.Text;
                ds = baseinfo.FindBellyWaistHipDataByID(BellyWaistHipDataInfo, "BellyWaistHipData");
                dgvBellyWaistHipDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvBellyWaistHipDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvBellyWaistHipDataListHeadText()
        {
            dgvBellyWaistHipDataList.Columns[0].HeaderText = "ID";
            dgvBellyWaistHipDataList.Columns[1].HeaderText = "腰围";
            dgvBellyWaistHipDataList.Columns[2].HeaderText = "腰背水平差";
            dgvBellyWaistHipDataList.Columns[3].HeaderText = "臀厚";
            dgvBellyWaistHipDataList.Columns[4].HeaderText = "腹厚";
            dgvBellyWaistHipDataList.Columns[5].HeaderText = "上臀围";
            dgvBellyWaistHipDataList.Columns[6].HeaderText = "臀围";
            dgvBellyWaistHipDataList.Columns[7].HeaderText = "臀部后突围";
            dgvBellyWaistHipDataList.Columns[8].HeaderText = "腹围";
            dgvBellyWaistHipDataList.Columns[9].HeaderText = "腹部前突围";
            dgvBellyWaistHipDataList.Columns[10].HeaderText = "腰臀距后";
            dgvBellyWaistHipDataList.Columns[11].HeaderText = "腰臀长左";
            dgvBellyWaistHipDataList.Columns[12].HeaderText = "腰臀长右";
            dgvBellyWaistHipDataList.Columns[13].HeaderText = "上体侧躯干长左";
            dgvBellyWaistHipDataList.Columns[14].HeaderText = "上体侧躯干长右";

        }

        private void dgvBellyWaistHipDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvBellyWaistHipDataList[0, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaist.Text = this.dgvBellyWaistHipDataList[1, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistBackLevelDifference.Text = this.dgvBellyWaistHipDataList[2, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtHipThickness.Text = this.dgvBellyWaistHipDataList[3, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtAdominalThickness.Text = this.dgvBellyWaistHipDataList[4, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtHipGirth.Text = this.dgvBellyWaistHipDataList[5, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtButtockGirth.Text = this.dgvBellyWaistHipDataList[6, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtMaximumHipGirth.Text = this.dgvBellyWaistHipDataList[7, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtBelly.Text = this.dgvBellyWaistHipDataList[8, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtMaximumBellyCircamference.Text = this.dgvBellyWaistHipDataList[9, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistPelvisDistance.Text = this.dgvBellyWaistHipDataList[10, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistPelvisLengthLeft.Text = this.dgvBellyWaistHipDataList[11, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistPelvisLengthRight.Text = this.dgvBellyWaistHipDataList[12, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistUnderarmLeft.Text = this.dgvBellyWaistHipDataList[13, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
            txtWaistUnderarmRight.Text = this.dgvBellyWaistHipDataList[14, dgvBellyWaistHipDataList.CurrentCell.RowIndex].Value.ToString();
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--腹腰臀部数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BellyWaistHipDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteBellyWaistHipData(BellyWaistHipDataInfo);
            MessageBox.Show("删除--头部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvBellyWaistHipDataList.DataSource = baseinfo.GetAllBellyWaistHipData("BellyWaistHipData").Tables[0].DefaultView;
            this.SetdgvBellyWaistHipDataListHeadText();
            this.clearText();
        }
    }
}
