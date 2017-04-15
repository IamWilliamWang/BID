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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmSysPopedom_Click(object sender, EventArgs e)//系统管理设置
        {
            new BID.SetSystem.frmSetOP().Show();
        }

        private void fileSetOP_Click(object sender, EventArgs e)//系统管理设置
        {
            new BID.SetSystem.frmSetOP().Show();
        }

        private void fileBakupAndRestor_Click(object sender, EventArgs e)//数据备份或恢复
        {
            new BID.SetSystem.frmBakup().Show();
        }

        private void fileClearTable_Click(object sender, EventArgs e)//系统清理
        {
            new BID.SetSystem.frmClearTable().Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)//退出系统
        {
            Environment.Exit(0);
        }

        //基础数据
        private void fileDataQuery_Click(object sender, EventArgs e)//数据查询
        {
            new BID.BaseInfo.frmDataQuery().Show();
        }

        private void fileHeaderData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmHeaderData().Show();
        }

        private void fileNeckData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmNeckData().Show();
        }

        private void fileShoulderData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmShoulderData().Show();
        }

        private void fileChestData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmChestData().Show();
        }

        private void fileBellyWaistHipData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmBellyWaistHipData().Show();
        }

        private void fileUpperLimbsData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmUpperLimbsData().Show();
        }

        private void fileLowerLimbsData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmLowerLimbsData().Show();
        }

        private void fileTrunkIntegralData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmTrunkIntegralData().Show();
        }

        private void fileFootData_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmFootData().Show();
        }    
          
        //辅助工具
        private void 登录Internet_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe");
        }

        private void 启动Word_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.EXE");
        }

        private void 启动Excel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("excel.exe");
        }

        private void 系统Calculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void fileOwner_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmOwner().Show();
        }

        private void fileQuery_Click(object sender, EventArgs e)
        {
            new BID.BaseInfo.frmQuery().Show();
        }

        private void ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            
        }

        private void 数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BID.DataAnalyze.frmDataAnalyze().Show();
        }

        private void 统计分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BID.DataAnalyze.frmDataStatistics().Show();
        }

        private void ToolStripMenuItem24_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
