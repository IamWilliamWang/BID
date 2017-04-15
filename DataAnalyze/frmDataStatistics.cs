using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID.DataAnalyze
{
    public partial class frmDataStatistics : Form
    {
        public frmDataStatistics()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String 选定项 = this.listBox年龄段选择.SelectedItem.ToString();
            if (this.listBox年龄段选择项.Items.Contains(选定项) == false)
            {
                if (选定项 == "全选")
                {
                    this.listBox年龄段选择项.Items.Clear();
                    this.listBox年龄段选择项.Items.Add("20-25岁");
                    this.listBox年龄段选择项.Items.Add("26-30岁");
                    this.listBox年龄段选择项.Items.Add("31-35岁");
                    this.listBox年龄段选择项.Items.Add("36-40岁");
                    this.listBox年龄段选择项.Items.Add("41-45岁");
                    this.listBox年龄段选择项.Items.Add("46-55岁");
                    this.listBox年龄段选择项.Items.Add("56-65岁");
                    this.listBox年龄段选择项.Items.Add("65岁以上");
                }
                else
                    this.listBox年龄段选择项.Items.Add(选定项);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String selectedElement = this.listBox年龄段选择.SelectedItem.ToString();
            if (selectedElement == "全选")
            {
                MessageBox.Show("此状态不能选择全选","警告");
                return;
            }
            frmDataStatisticsResultDialog1 form = new frmDataStatisticsResultDialog1(selectedElement);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<String> selectedElement = new List<string>();
            foreach(String str in this.listBox年龄段选择项.Items)
            {
                selectedElement.Add(str);
            }
            selectedElement.Sort();
            new frmDataStatisticsResultDialog2(selectedElement).Show();
        }
    }
}
