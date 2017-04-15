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
    public partial class frmShoulderData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cShoulderDataInfo ShoulderDataInfo = new BID.BaseClass.cShoulderDataInfo();
        int G_Int_addOrUpdate = 0;

        public frmShoulderData()
        {
            InitializeComponent();
        }
        private void frmShoulderData_Load(object sender, EventArgs e)
        {
           
            dgvShoulderDataList.DataSource = baseinfo.GetAllShoulderData("ShoulderData").Tables[0].DefaultView;
            this.SetdgvShoulderDataListHeadText();
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
            ds = baseinfo.GetAllShoulderData("ShoulderData");


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
            txtShoulderAcross.Text = string.Empty;
            txtLeftShoulder.Text = string.Empty;
            txtRightShoulder.Text = string.Empty;
            txtLeftShoulderAngle.Text = string.Empty;
            txtRightShoulderAngle.Text = string.Empty;
           
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
                    ShoulderDataInfo.id = txtID.Text;
                    ShoulderDataInfo.shoulderAcross = txtShoulderAcross.Text;
                    ShoulderDataInfo.leftShoulder = txtLeftShoulder.Text;
                    ShoulderDataInfo.rightShoulder = txtRightShoulder.Text;
                    ShoulderDataInfo.leftShoulderAngle = txtLeftShoulderAngle.Text;
                    ShoulderDataInfo.rightShoulderAngle = txtRightShoulderAngle.Text;
                   
                    //执行添加
                    int id = baseinfo.AddShoulderData(ShoulderDataInfo);
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
                ShoulderDataInfo.id = txtID.Text;
                ShoulderDataInfo.shoulderAcross = txtShoulderAcross.Text;
                ShoulderDataInfo.leftShoulder = txtLeftShoulder.Text;
                ShoulderDataInfo.rightShoulder = txtRightShoulder.Text;
                ShoulderDataInfo.leftShoulderAngle = txtLeftShoulderAngle.Text;
                ShoulderDataInfo.rightShoulderAngle = txtRightShoulderAngle.Text;
                //执行修改
                int id = baseinfo.UpdateShoulderData(ShoulderDataInfo);
                MessageBox.Show("修改--肩部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvShoulderDataList.DataSource = baseinfo.GetAllShoulderData("ShoulderData").Tables[0].DefaultView;
            this.SetdgvShoulderDataListHeadText();
            this.cancelEnabled();
        }
        //查询肩部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbShoulderDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbShoulderDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindShoulderData.Text.Trim() == string.Empty)
                {
                    dgvShoulderDataList.DataSource = baseinfo.GetAllShoulderData("ShoulderData").Tables[0].DefaultView;
                    this.SetdgvShoulderDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbShoulderDataType.Text == "ID")  //按编号查询
            {
                ShoulderDataInfo.id = tlTxtFindShoulderData.Text;
                ds = baseinfo.FindShoulderDataByID(ShoulderDataInfo, "ShoulderData");
                dgvShoulderDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvShoulderDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvShoulderDataListHeadText()
        {
            dgvShoulderDataList.Columns[0].HeaderText = "ID";
            dgvShoulderDataList.Columns[1].HeaderText = "肩宽";
            dgvShoulderDataList.Columns[2].HeaderText = "左肩宽";
            dgvShoulderDataList.Columns[3].HeaderText = "右肩宽";
            dgvShoulderDataList.Columns[4].HeaderText = "左肩斜";
            dgvShoulderDataList.Columns[5].HeaderText = "右肩斜";
   
        }

        private void dgvShoulderDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvShoulderDataList[0, dgvShoulderDataList.CurrentCell.RowIndex].Value.ToString();
            txtShoulderAcross.Text = this.dgvShoulderDataList[1, dgvShoulderDataList.CurrentCell.RowIndex].Value.ToString();
            txtLeftShoulder.Text = this.dgvShoulderDataList[2, dgvShoulderDataList.CurrentCell.RowIndex].Value.ToString();
            txtRightShoulder.Text = this.dgvShoulderDataList[3, dgvShoulderDataList.CurrentCell.RowIndex].Value.ToString();
            txtLeftShoulderAngle.Text = this.dgvShoulderDataList[4, dgvShoulderDataList.CurrentCell.RowIndex].Value.ToString();
            txtRightShoulderAngle.Text = this.dgvShoulderDataList[5, dgvShoulderDataList.CurrentCell.RowIndex].Value.ToString();
           
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--肩部数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShoulderDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteShoulderData(ShoulderDataInfo);
            MessageBox.Show("删除--肩部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvShoulderDataList.DataSource = baseinfo.GetAllShoulderData("ShoulderData").Tables[0].DefaultView;
            this.SetdgvShoulderDataListHeadText();
            this.clearText();
        }
    }
}
