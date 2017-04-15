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
    public partial class frmUpperLimbsData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cUpperLimbsDataInfo UpperLimbsDataInfo = new BID.BaseClass.cUpperLimbsDataInfo();
        int G_Int_addOrUpdate = 0;
        public frmUpperLimbsData()
        {
            InitializeComponent();
        }
        private void frmUpperLimbsData_Load(object sender, EventArgs e)
        {
           
            dgvUpperLimbsDataList.DataSource = baseinfo.GetAllUpperLimbsData("UpperLimbsData").Tables[0].DefaultView;
            this.SetdgvUpperLimbsDataListHeadText();
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
            ds = baseinfo.GetAllUpperLimbsData("UpperLimbsData");


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
            txtCervicalWristLengthLeft.Text = string.Empty;
            txtCervicalWristLengthRight.Text = string.Empty;
            txtArmLengthLeft.Text = string.Empty;
            txtArmLengthRight.Text = string.Empty;
            txtUpperArmLengthLeft.Text = string.Empty;
            txtUpperArmLengthRight.Text = string.Empty;
            txtUpperArmGirthLeft.Text = string.Empty;
            txtUpperArmGirthRight.Text = string.Empty;
            txtWristGirthLeft.Text = string.Empty;
            txtWristGirthRight.Text = string.Empty;
            txtHandThickness.Text = string.Empty;
            txtHandGirth.Text = string.Empty;
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
                    UpperLimbsDataInfo.id = txtID.Text;
                    UpperLimbsDataInfo.cervicalWristLengthLeft = txtCervicalWristLengthLeft.Text;
                    UpperLimbsDataInfo.cervicalWristLengthRight = txtCervicalWristLengthRight.Text;
                    UpperLimbsDataInfo.armLengthLeft = txtArmLengthLeft.Text;
                    UpperLimbsDataInfo.armLengthRight = txtArmLengthRight.Text;
                    UpperLimbsDataInfo.upperArmLengthLeft = txtUpperArmLengthLeft.Text;
                    UpperLimbsDataInfo.upperArmLengthRight = txtUpperArmLengthRight.Text;
                    UpperLimbsDataInfo.upperArmGirthLeft = txtUpperArmGirthLeft.Text;
                    UpperLimbsDataInfo.upperArmGirthRight = txtUpperArmGirthRight.Text;
                    UpperLimbsDataInfo.wristGirthLeft = txtWristGirthLeft.Text;
                    UpperLimbsDataInfo.wristGirthRight = txtWristGirthRight.Text;
                    UpperLimbsDataInfo.handThickness = txtHandThickness.Text;
                    UpperLimbsDataInfo.handGirth = txtHandGirth.Text;
                    //执行添加
                    int id = baseinfo.AddUpperLimbsData(UpperLimbsDataInfo);
                    MessageBox.Show("新增--上肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                UpperLimbsDataInfo.id = txtID.Text;
                UpperLimbsDataInfo.cervicalWristLengthLeft = txtCervicalWristLengthLeft.Text;
                UpperLimbsDataInfo.cervicalWristLengthRight = txtCervicalWristLengthRight.Text;
                UpperLimbsDataInfo.armLengthLeft = txtArmLengthLeft.Text;
                UpperLimbsDataInfo.armLengthRight = txtArmLengthRight.Text;
                UpperLimbsDataInfo.upperArmLengthLeft = txtUpperArmLengthLeft.Text;
                UpperLimbsDataInfo.upperArmLengthRight = txtUpperArmLengthRight.Text;
                UpperLimbsDataInfo.upperArmGirthLeft = txtUpperArmGirthLeft.Text;
                UpperLimbsDataInfo.upperArmGirthRight = txtUpperArmGirthRight.Text;
                UpperLimbsDataInfo.wristGirthLeft = txtWristGirthLeft.Text;
                UpperLimbsDataInfo.wristGirthRight = txtWristGirthRight.Text;
                UpperLimbsDataInfo.handThickness = txtHandThickness.Text;
                UpperLimbsDataInfo.handGirth = txtHandGirth.Text;

                //执行修改
                int id = baseinfo.UpdateUpperLimbsData(UpperLimbsDataInfo);
                MessageBox.Show("修改--上肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvUpperLimbsDataList.DataSource = baseinfo.GetAllUpperLimbsData("UpperLimbsData").Tables[0].DefaultView;
            this.SetdgvUpperLimbsDataListHeadText();
            this.cancelEnabled();
        }
        //查询上肢数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbUpperLimbsDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbUpperLimbsDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindUpperLimbsData.Text.Trim() == string.Empty)
                {
                    dgvUpperLimbsDataList.DataSource = baseinfo.GetAllUpperLimbsData("UpperLimbsData").Tables[0].DefaultView;
                    this.SetdgvUpperLimbsDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbUpperLimbsDataType.Text == "ID")  //按编号查询
            {
                UpperLimbsDataInfo.id = tlTxtFindUpperLimbsData.Text;
                ds = baseinfo.FindUpperLimbsDataByID(UpperLimbsDataInfo, "UpperLimbsData");
                dgvUpperLimbsDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvUpperLimbsDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvUpperLimbsDataListHeadText()
        {
            dgvUpperLimbsDataList.Columns[0].HeaderText = "ID";
            dgvUpperLimbsDataList.Columns[1].HeaderText = "全臂长左";
            dgvUpperLimbsDataList.Columns[2].HeaderText = "全臂长右";
            dgvUpperLimbsDataList.Columns[3].HeaderText = "臂长左";
            dgvUpperLimbsDataList.Columns[4].HeaderText = "臂长右";
            dgvUpperLimbsDataList.Columns[5].HeaderText = "上臂长左";
            dgvUpperLimbsDataList.Columns[6].HeaderText = "上臂长右";
            dgvUpperLimbsDataList.Columns[7].HeaderText = "上臂围左";
            dgvUpperLimbsDataList.Columns[8].HeaderText = "上臂围右";
            dgvUpperLimbsDataList.Columns[9].HeaderText = "腕围左";
            dgvUpperLimbsDataList.Columns[10].HeaderText = "腕围右";
            dgvUpperLimbsDataList.Columns[11].HeaderText = "掌厚";
            dgvUpperLimbsDataList.Columns[12].HeaderText = "掌围";

        }

        private void dgvUpperLimbsDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvUpperLimbsDataList[0, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtCervicalWristLengthLeft.Text = this.dgvUpperLimbsDataList[1, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtCervicalWristLengthRight.Text = this.dgvUpperLimbsDataList[2, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtArmLengthLeft.Text = this.dgvUpperLimbsDataList[3, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtArmLengthRight.Text = this.dgvUpperLimbsDataList[4, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtUpperArmLengthLeft.Text = this.dgvUpperLimbsDataList[5, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtUpperArmLengthRight.Text = this.dgvUpperLimbsDataList[6, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtUpperArmGirthLeft.Text = this.dgvUpperLimbsDataList[7, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtUpperArmGirthRight.Text = this.dgvUpperLimbsDataList[8, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtWristGirthLeft.Text = this.dgvUpperLimbsDataList[9, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtWristGirthRight.Text = this.dgvUpperLimbsDataList[10, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtHandThickness.Text = this.dgvUpperLimbsDataList[11, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
            txtHandGirth.Text = this.dgvUpperLimbsDataList[12, dgvUpperLimbsDataList.CurrentCell.RowIndex].Value.ToString();
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--上肢数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpperLimbsDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteUpperLimbsData(UpperLimbsDataInfo);
            MessageBox.Show("删除--上肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvUpperLimbsDataList.DataSource = baseinfo.GetAllUpperLimbsData("UpperLimbsData").Tables[0].DefaultView;
            this.SetdgvUpperLimbsDataListHeadText();
            this.clearText();
        }
    }
}
