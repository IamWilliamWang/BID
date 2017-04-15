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
    public partial class frmClearTable : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();//创建BaseInfo类的对象
        public frmClearTable()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (chkHeaderData.Checked) //判断头部数据表复选框是否选中
                baseinfo.ClearTable("HeaderData");//清理头部数据表信息
            if (chkNeckData.Checked)//判断颈部数据表复选框是否选中
            {
                baseinfo.ClearTable("NeckData");//清理颈部数据表信息
            }
            if (chkShoulderData.Checked)//判断肩部数据表复选框是否选中
            {
                baseinfo.ClearTable("ShoulderData");//清理肩部数据表信息
            }
            if (chkChestData.Checked)//判断胸部数据表复选框是否选中
            {
                baseinfo.ClearTable("ChestData");//清理胸部数据表信息
            }
            if (chkBellyWaistHipData.Checked)//判断腹腰臀部数据表复选框是否选中
            {
                baseinfo.ClearTable("BellyWaistHipData");//清理腹腰臀部数据表信息
            }
            if (chkUpperLimbsData.Checked)//判断上肢数据表复选框是否选中
            {
                baseinfo.ClearTable("UpperLimbsData");//清理上肢数据表信息
            }
            if (chkLowerLimbsData.Checked)//判断下肢数据表复选框是否选中
            {
                baseinfo.ClearTable("LowerLimbsData");//清理下肢数据表信息
            }
            if (chkTrunkIntegralData.Checked)//判断躯干数据表复选框是否选中
            {
                baseinfo.ClearTable("TrunkIntegralData");//清理躯干数据表信息
            }
            if (chkFootData.Checked)//判断足部数据表复选框是否选中
            {
                baseinfo.ClearTable("FootData");//清理足部数据表信息
            }
            if (chkOwner.Checked)//判断被测人基本信息表复选框是否选中
            {
                baseinfo.ClearTable("Owner");//清理被测人基本信息表信息
            }
            if (chkUser.Checked) baseinfo.ClearTable("User");//清理用户信息
            MessageBox.Show("系统数据清理成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}
