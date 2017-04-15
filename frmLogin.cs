using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID
{
    public partial class frmLogin : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cPopedom popedom = new BID.BaseClass.cPopedom();
        public frmLogin()
        {
            InitializeComponent();
        }
      
        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是否按下Enter键
                txtUserPwd.Focus();//将鼠标焦点移动到“密码”文本框
        }

        private void txtUserPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//判断是否按下Enter键
                btnLogin.Focus();//将鼠标焦点移动到“登录”按钮
        }

       
        //登录
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("用户名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataSet ds = null;
            popedom.SysUser = txtUserName.Text;
            popedom.Password = txtUserPwd.Text;
            ds = baseinfo.Login(popedom);
            if (ds.Tables[0].Rows.Count > 0)
            {
                frmMain frm_main = new frmMain();
                frm_main.Show();
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["system"])) frm_main.ToolStripMenuItem1.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["base"])) frm_main.ToolStripMenuItem5.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["analyze"])) frm_main.ToolStripMenuItem16.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["classify"])) frm_main.ToolStripMenuItem17.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["discern"])) frm_main.ToolStripMenuItem18.Enabled = true;

                this.Visible = false;
            }
            else
            {
                MessageBox.Show("用户名称或密码不正确！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //退出
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
