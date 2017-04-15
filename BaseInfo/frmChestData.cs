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
    public partial class frmChestData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cChestDataInfo ChestDataInfo = new BID.BaseClass.cChestDataInfo();
        int G_Int_addOrUpdate = 0;

        public frmChestData()
        {
            InitializeComponent();
        }
        private void frmChestData_Load(object sender, EventArgs e)
        {
           
            dgvChestDataList.DataSource = baseinfo.GetAllChestData("ChestData").Tables[0].DefaultView;
            this.SetdgvChestDataListHeadText();
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
            ds = baseinfo.GetAllChestData("ChestData");


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
            txtBust.Text = string.Empty;
            txtChestThickness.Text = string.Empty;
            txtAcrossFront.Text = string.Empty;
            txtAcrossBack.Text = string.Empty;
            txtMilkInterval.Text = string.Empty;
            txtUnderBustGirth.Text = string.Empty;
            txtThoracicCavityBand.Text = string.Empty;
            txtNeckPointToBbustProminenceLeft.Text = string.Empty;
            txtNeckPointToBustProminenceRight.Text = string.Empty;
           
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
                    ChestDataInfo.id = txtID.Text;
                    ChestDataInfo.bust = txtBust.Text;
                    ChestDataInfo.chestThickness = txtChestThickness.Text;
                    ChestDataInfo.acrossFront = txtAcrossFront.Text;
                    ChestDataInfo.acrossBack = txtAcrossBack.Text;
                    ChestDataInfo.milkInterval = txtMilkInterval.Text;
                    ChestDataInfo.underBustGirth = txtUnderBustGirth.Text;
                    ChestDataInfo.thoracicCavityBand = txtThoracicCavityBand.Text;
                    ChestDataInfo.neckPointToBbustProminenceLeft = txtNeckPointToBbustProminenceLeft.Text;
                    ChestDataInfo.neckPointToBustProminenceRight = txtNeckPointToBustProminenceRight.Text;
                   
                    //执行添加
                    int id = baseinfo.AddChestData(ChestDataInfo);
                    MessageBox.Show("新增--胸部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                ChestDataInfo.id = txtID.Text;
                ChestDataInfo.bust = txtBust.Text;
                ChestDataInfo.chestThickness = txtChestThickness.Text;
                ChestDataInfo.acrossFront = txtAcrossFront.Text;
                ChestDataInfo.acrossBack = txtAcrossBack.Text;
                ChestDataInfo.milkInterval = txtMilkInterval.Text;
                ChestDataInfo.underBustGirth = txtUnderBustGirth.Text;
                ChestDataInfo.thoracicCavityBand = txtThoracicCavityBand.Text;
                ChestDataInfo.neckPointToBbustProminenceLeft = txtNeckPointToBbustProminenceLeft.Text;
                ChestDataInfo.neckPointToBustProminenceRight = txtNeckPointToBustProminenceRight.Text;
                //执行修改
                int id = baseinfo.UpdateChestData(ChestDataInfo);
                MessageBox.Show("修改--胸部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvChestDataList.DataSource = baseinfo.GetAllChestData("ChestData").Tables[0].DefaultView;
            this.SetdgvChestDataListHeadText();
            this.cancelEnabled();
        }
        //查询胸部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbChestDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbChestDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindChestData.Text.Trim() == string.Empty)
                {
                    dgvChestDataList.DataSource = baseinfo.GetAllChestData("ChestData").Tables[0].DefaultView;
                    this.SetdgvChestDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbChestDataType.Text == "ID")  //按编号查询
            {
                ChestDataInfo.id = tlTxtFindChestData.Text;
                ds = baseinfo.FindChestDataByID(ChestDataInfo, "ChestData");
                dgvChestDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvChestDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvChestDataListHeadText()
        {
            dgvChestDataList.Columns[0].HeaderText = "ID";
            dgvChestDataList.Columns[1].HeaderText = "前胸宽";
            dgvChestDataList.Columns[2].HeaderText = "乳间距";
            dgvChestDataList.Columns[3].HeaderText = "前颈点到乳峰长左";
            dgvChestDataList.Columns[4].HeaderText = "前颈点到乳峰长右";
            dgvChestDataList.Columns[5].HeaderText = "胸围";
            dgvChestDataList.Columns[6].HeaderText = "胸腔带围";
            dgvChestDataList.Columns[7].HeaderText = "胸下围";
            dgvChestDataList.Columns[8].HeaderText = "后背宽";
            dgvChestDataList.Columns[9].HeaderText = "胸厚";
           

        }

        private void dgvChestDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvChestDataList[0, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtAcrossFront.Text = this.dgvChestDataList[1, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtMilkInterval.Text = this.dgvChestDataList[2, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtNeckPointToBbustProminenceLeft.Text = this.dgvChestDataList[3, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtNeckPointToBustProminenceRight.Text = this.dgvChestDataList[4, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtBust.Text = this.dgvChestDataList[5, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtThoracicCavityBand.Text = this.dgvChestDataList[6, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtUnderBustGirth.Text = this.dgvChestDataList[7, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtAcrossBack.Text = this.dgvChestDataList[8, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            txtChestThickness.Text = this.dgvChestDataList[9, dgvChestDataList.CurrentCell.RowIndex].Value.ToString();
            
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--胸部数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ChestDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteChestData(ChestDataInfo);
            MessageBox.Show("删除--胸部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvChestDataList.DataSource = baseinfo.GetAllChestData("ChestData").Tables[0].DefaultView;
            this.SetdgvChestDataListHeadText();
            this.clearText();
        }
        private void dgvChestDataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
