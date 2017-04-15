using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID.SetSystem
{
    public partial class frmSetOP : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cPopedom popedom = new BID.BaseClass.cPopedom();
        int ID = 0;
        public frmSetOP()
        {
            InitializeComponent();
        }

        public void SetHeadText()
        {
            dgvSysUserList.Columns[0].HeaderText = "ID";
            dgvSysUserList.Columns[0].Width = 40;
            dgvSysUserList.Columns[1].HeaderText = "用户名称";
            dgvSysUserList.Columns[2].HeaderText = "用户密码";
            dgvSysUserList.Columns[3].HeaderText = "系统管理";
            dgvSysUserList.Columns[3].Width = 80;
            dgvSysUserList.Columns[4].HeaderText = "基础信息";
            dgvSysUserList.Columns[4].Width = 80;
            dgvSysUserList.Columns[5].HeaderText = "数据统计分析";
            dgvSysUserList.Columns[5].Width = 80;
            dgvSysUserList.Columns[6].HeaderText = "体型分类";
            dgvSysUserList.Columns[6].Width = 80;
            dgvSysUserList.Columns[7].HeaderText = "体型识别";
            dgvSysUserList.Columns[7].Width = 80;
        }

        private void tlbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlbtnAdd_Click(object sender, EventArgs e)
        {
            if (tltxtUserName.Text == string.Empty)
            {
                MessageBox.Show("用户名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (baseinfo.FindUserName(tltxtUserName.Text))
            {
                MessageBox.Show("用户名称已经存在，不添加重复的用户名！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            baseinfo.AddSysUser(tltxtUserName.Text, tltxtPwd.Text);
            MessageBox.Show("系统新用户--添加成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvSysUserList.DataSource = baseinfo.GetAllUser().Tables[0].DefaultView;
            this.SetHeadText();
        }

        private void tlbtnDel_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("请选择将要删除的系统用户！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            baseinfo.DeleteSysUser(ID);
            MessageBox.Show("系统用户--删除成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvSysUserList.DataSource = baseinfo.GetAllUser().Tables[0].DefaultView;
            this.SetHeadText();
        }

        private void frmSetOP_Load(object sender, EventArgs e)
        {
       
            dgvSysUserList.DataSource = baseinfo.GetAllUser().Tables[0].DefaultView;
            this.SetHeadText();
        }

        private void tlbtnUpdate_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("请选择将要修改的系统用户！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            popedom.SysUser = tltxtUserName.Text;
            popedom.Password = tltxtPwd.Text;

            baseinfo.UpdateSysUser(popedom);
            dgvSysUserList.DataSource = baseinfo.GetAllUser().Tables[0].DefaultView;
            this.SetHeadText();
        }

        private void dgvSysUserList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                popedom.SystemSet = Convert.ToBoolean(dgvSysUserList[3, e.RowIndex].Value.ToString());
                popedom.Base_Info = Convert.ToBoolean(dgvSysUserList[4, e.RowIndex].Value.ToString());
                popedom.Analyze = Convert.ToBoolean(dgvSysUserList[5, e.RowIndex].Value.ToString());
                popedom.Classify = Convert.ToBoolean(dgvSysUserList[6, e.RowIndex].Value.ToString());
                popedom.Discern = Convert.ToBoolean(dgvSysUserList[7, e.RowIndex].Value.ToString());
            }
            catch { }
        }

        private void dgvSysUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = Convert.ToInt16(dgvSysUserList[0, e.RowIndex].Value.ToString());
                tltxtUserName.Text = dgvSysUserList[1, e.RowIndex].Value.ToString();
                tltxtPwd.Text = dgvSysUserList[2, e.RowIndex].Value.ToString();
                popedom.ID = ID;
            }
            catch { }
        }

        private void dgvSysUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
