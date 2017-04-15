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
    public partial class frmOwner : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cOwnerInfo Ownerinfo = new BID.BaseClass.cOwnerInfo();
        int G_Int_addOrUpdate = 0;
        public frmOwner()
        {
            InitializeComponent();
        }
        private void frmOwner_Load(object sender, EventArgs e)
        {
            
            dgvOwnerList.DataSource = baseinfo.GetAllOwner("Owner").Tables[0].DefaultView;
            this.SetdgvOwnerListHeadText();
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
            txtJob.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtWorkUnit.Text = string.Empty;
            txtWeight.Text = string.Empty;
        }
        //设置DataGridView标题
        private void SetdgvOwnerListHeadText()
        {
            dgvOwnerList.Columns[0].HeaderText = "ID";
            dgvOwnerList.Columns[1].HeaderText = "性别";
            dgvOwnerList.Columns[2].HeaderText = "年龄";
            dgvOwnerList.Columns[3].HeaderText = "职位";
            dgvOwnerList.Columns[4].HeaderText = "工作单位";
            dgvOwnerList.Columns[5].HeaderText = "身份证前6位";
            dgvOwnerList.Columns[6].HeaderText = "体重";
        }
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbOwnerType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbOwnerType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindOwner.Text.Trim() == string.Empty)
                {
                    dgvOwnerList.DataSource = baseinfo.GetAllOwner("Owner").Tables[0].DefaultView;
                    this.SetdgvOwnerListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbOwnerType.Text == "ID")  //按编号查询
            {
                Ownerinfo.id = tlTxtFindOwner.Text;
                ds = baseinfo.FindOwnerByID(Ownerinfo, "Owner");
                dgvOwnerList.DataSource = ds.Tables[0].DefaultView;
            }

            this.SetdgvOwnerListHeadText();

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
            ds = baseinfo.GetAllOwner("Owner");


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
                    Ownerinfo.id = txtID.Text;
                    Ownerinfo.idcard = txtIDCard.Text;
                    Ownerinfo.sex = cmbSex.Text;
                    Ownerinfo.age = txtAge.Text;
                    Ownerinfo.job = txtJob.Text;
                    Ownerinfo.workUnit = txtWorkUnit.Text;
                    Ownerinfo.weight = txtWeight.Text;

                    //执行添加
                    int id = baseinfo.AddOwner(Ownerinfo);
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
                Ownerinfo.id = txtID.Text;
                Ownerinfo.idcard = txtIDCard.Text;
                Ownerinfo.sex = cmbSex.Text;
                Ownerinfo.age = txtAge.Text;
                Ownerinfo.job = txtJob.Text;
                Ownerinfo.workUnit = txtWorkUnit.Text;
                Ownerinfo.weight = txtWeight.Text;

                //执行修改
                int id = baseinfo.UpdateOwner(Ownerinfo);
                MessageBox.Show("修改--基础数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvOwnerList.DataSource = baseinfo.GetAllOwner("Owner").Tables[0].DefaultView;
            this.SetdgvOwnerListHeadText();
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
                MessageBox.Show("删除--Owner数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Ownerinfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteOwner(Ownerinfo);
            MessageBox.Show("删除--Owner数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvOwnerList.DataSource = baseinfo.GetAllOwner("Owner").Tables[0].DefaultView;
            this.SetdgvOwnerListHeadText();
            this.clearText();
        }
        private void dgvOwnerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvOwnerList[0, dgvOwnerList.CurrentCell.RowIndex].Value.ToString();
            cmbSex.Text = this.dgvOwnerList[1, dgvOwnerList.CurrentCell.RowIndex].Value.ToString();
            txtAge.Text = this.dgvOwnerList[2, dgvOwnerList.CurrentCell.RowIndex].Value.ToString();
            txtJob.Text = this.dgvOwnerList[3, dgvOwnerList.CurrentCell.RowIndex].Value.ToString();
            txtWorkUnit.Text = this.dgvOwnerList[4, dgvOwnerList.CurrentCell.RowIndex].Value.ToString();
            txtIDCard.Text = this.dgvOwnerList[5, dgvOwnerList.CurrentCell.RowIndex].Value.ToString();
            txtWeight.Text = this.dgvOwnerList[6, dgvOwnerList.CurrentCell.RowIndex].Value.ToString();

        }

        private void tlbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
