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
    public partial class frmDataStatisticsResultDialog2 : Form
    {
        List<String> selectedElements;
        int fromAge, toAge;
        private BaseClass.DataBase dataBaseUtil = new BaseClass.DataBase();
        private Color graphColor = Color.Blue;
        List<int> selectedElementsCount = new List<int>();

        private frmDataStatisticsResultDialog2()
        {
            InitializeComponent();
        }

        public frmDataStatisticsResultDialog2(List<String> selectedElements)
        {
            InitializeComponent();
            this.selectedElements = selectedElements;
            this.paintAllPicts();
        }

        #region 将字符串转换为实际的范围
        private void changeRange(String selectedElement)
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

        private void paint(SeriesChartType chartType,Chart 需要绘图的表,String legend)
        {
            String sql = "";
            
            for(int index=0;index<selectedElements.Count;index++)
            {
                String str = selectedElements[index];
            
                changeRange(str);
                sql += "select count(*) " +
                    "from BasicData " +
                    "where 年龄>" + this.fromAge + " and 年龄<" + this.toAge;
                DataSet dataset = dataBaseUtil.RunProcReturn(sql, "BasicData");
                selectedElementsCount.Add(int.Parse(dataset.Tables[index].Rows[0].ItemArray[0].ToString()));
            }

            Series series = new Series();
            series.ChartType = chartType;
            series.BorderWidth = 2;
            series.Color = graphColor;
            series.LegendText = legend;
            series.IsValueShownAsLabel = true;
            series["PieLabelStyle"] = "outside";

            if (chartType == SeriesChartType.Column)
                for (int index = 0; index < selectedElements.Count; index++)
                {
                    series.Points.AddXY(this.selectedElements[index], this.selectedElementsCount[index]);
                }
            else
            {
                series.Points.DataBindXY(this.selectedElements, this.selectedElementsCount);
                series.Label = "#INDEX(#PERCENT)";
            }

            需要绘图的表.Series.Clear();
            需要绘图的表.Series.Add(series);

            // 设置显示范围
            ChartArea chartArea = 需要绘图的表.ChartAreas[0];
            //chartArea.AxisX.Minimum = xMin;
            //chartArea.AxisX.Maximum = xMax;
            chartArea.AxisY.IsInterlaced = true;
            chartArea.Area3DStyle.Enable3D = true;
        }

        private void paintPie()
        {
            this.paint(SeriesChartType.Pie, chart1, "");
        }

        private void paintBar()
        {
            this.paint(SeriesChartType.Column, chart2, "人数分布柱状图");
        }

        private void paintAllPicts()
        {
            this.paintPie();
            this.paintBar();
        }

        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Red;
            this.paintBar();
        }

        private void 蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Blue;
            this.paintBar();
        }

        private void 棕色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Brown;
            this.paintBar();
        }

        private void 黑色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Black;
            this.paintBar();
        }

        private void 粉色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Pink;
            this.paintBar();
        }

        private void 金色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Gold;
            this.paintBar();
        }

        private void 绿色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.graphColor = Color.Green;
            this.paintBar();
        }

        private void 关闭此窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
