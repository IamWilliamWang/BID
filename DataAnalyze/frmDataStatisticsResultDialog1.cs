using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BID.DataAnalyze
{
    public partial class frmDataStatisticsResultDialog1 : Form
    {
        private int fromAge, toAge;
        private BaseClass.DataBase dataBaseUtil = new BaseClass.DataBase();
        int xMin = 0;
        int xMax = 20000;
        Color graphColor = Color.Blue;
        bool IsValueShownAsLabel = true;
        bool Enable3D = true;

        private frmDataStatisticsResultDialog1()
        {
            InitializeComponent();
        }

        #region 外部可以调用的构造函数
        /// <summary>
        /// 根据选择内容显示统计对话框
        /// </summary>
        /// <param name="selectedElement">选择条目的字符串 </param>
        public frmDataStatisticsResultDialog1(String selectedElement)
        {
            InitializeComponent();
            this.addRange(selectedElement);
            this.paintAllPicts();
        }
        #endregion

        private void paintAllPicts()
        {
            this.showBodyHighGraph();
            this.showChestGraph();
            this.show臀部Graph();
        }

        #region 将字符串转换为实际的范围
        private void addRange(String selectedElement)
        {
            switch (selectedElement)
            {
                case "20-25岁":
                    this.fromAge = 20;
                    this.toAge = 25;
                    break;
                case "26-30岁":
                    this.fromAge = 26;
                    this.toAge = 30;
                    break;
                case "31-35岁":
                    this.fromAge = 31;
                    this.toAge = 35;
                    break;
                case "36-40岁":
                    this.fromAge = 36;
                    this.toAge = 40;
                    break;
                case "41-45岁":
                    this.fromAge = 41;
                    this.toAge = 45;
                    break;
                case "46-55岁":
                    this.fromAge = 46;
                    this.toAge = 55;
                    break;
                case "56-65岁":
                    this.fromAge = 56;
                    this.toAge = 65;
                    break;
                case "65岁以上":
                    this.fromAge = 65;
                    this.toAge = 200;
                    break;
                default:
                    throw new Exception("年龄选择异常");
            }
        }
        #endregion

        private int[] countersOfAnalysis(List<double> orginalData)
        {
            int[] num = new int[20];//0-20000
            foreach (double data in orginalData)
            {
                try
                {
                    num[((int)data) / 1000]++;
                }
                catch { }
            }
            return num;
        }

        private void paint(String 属性, Chart 需要绘图的图表, String LegendText)
        {
            String sql = "select " + 属性 + " from BasicData where 年龄>" + this.fromAge + " and 年龄<" + this.toAge;
            DataTable dataTable = dataBaseUtil.RunProcReturn(sql, "BasicData").Tables[0];
            List<double> dataTable_List = new List<double>();
            

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (double data in row.ItemArray)
                    dataTable_List.Add(data);
            }

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;//直方图
            series.BorderWidth = 2;
            series.Color = graphColor;
            series.LegendText = LegendText;
            series.IsValueShownAsLabel = this.IsValueShownAsLabel;

            int x = 0;
            int[] analysis = this.countersOfAnalysis(dataTable_List);
            foreach (float v in analysis)
            {
                series.Points.AddXY(x, v);
                x += 1000;
            }

            需要绘图的图表.Series.Clear();
            需要绘图的图表.Series.Add(series);

            // 设置显示范围
            ChartArea chartArea = 需要绘图的图表.ChartAreas[0];
            chartArea.AxisX.Minimum = xMin;
            chartArea.AxisX.Maximum = xMax;
            chartArea.AxisY.IsInterlaced = true;
            chartArea.Area3DStyle.Enable3D = this.Enable3D;
            //chartArea.AxisY.Minimum = 0d;
            //chartArea.AxisY.Maximum = 100d;
        }

        #region 输出身高折线图
        private void showBodyHighGraph()
        {
            paint("身高", this.chart1, "身高折现图");
        }
        #endregion

        #region 胸围统计
        private void showChestGraph()
        {
            paint("胸围", this.chart2, "胸围折线图");
        }
        #endregion

        #region 臀围统计
        private void show臀部Graph()
        {
            paint("臀围", this.chart3, "臀围折线图");
        }
        #endregion

        private void 修改X轴范围ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Microsoft.VisualBasic.Interaction.InputBox("输入X轴的最小值和最大值，用空格隔开。", "输入X轴的范围");
            String[] numStr = str.Split(' ');
            if (numStr.Length != 2)
            { 
                MessageBox.Show("请输入两个参数");
                return;
            }
            try
            {
                xMin = int.Parse(numStr[0]);
                xMax = int.Parse(numStr[1]);
                this.paintAllPicts();
            }
            catch
            {
                MessageBox.Show("输入错误");
            }
        }

        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Red;
            this.paintAllPicts();
        }

        private void 蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Blue;
            this.paintAllPicts();
        }

        private void 棕色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Brown;
            this.paintAllPicts();
        }

        private void 黑色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Black;
            this.paintAllPicts();
        }

        private void 粉色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Pink;
            this.paintAllPicts();
        }

        private void 金色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Gold;
            this.paintAllPicts();
        }

        private void 绿色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Green;
            this.paintAllPicts();
        }

        private void 关闭数值标注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.关闭数值标注ToolStripMenuItem.Text== "关闭数值标注")
            {
                this.IsValueShownAsLabel = false;
                this.关闭数值标注ToolStripMenuItem.Text = "打开数值标注";
            }
            else
            {
                this.IsValueShownAsLabel = true;
                this.关闭数值标注ToolStripMenuItem.Text = "关闭数值标注";
            }
            this.paintAllPicts();
        }

        private void 关闭3D效果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.关闭3D效果ToolStripMenuItem.Text== "关闭3D效果")
            {
                this.Enable3D = false;
                this.关闭3D效果ToolStripMenuItem.Text = "打开3D效果";
            }
            else
            {
                this.Enable3D = true;
                this.关闭3D效果ToolStripMenuItem.Text = "关闭3D效果";
            }
            this.paintAllPicts();
        }

        private void 关闭此窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
