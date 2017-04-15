namespace BID.DataAnalyze
{
    partial class frmDataStatisticsResultDialog1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.坐标调整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改X轴范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.红色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.蓝色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.棕色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黑色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粉色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.金色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绿色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭数值标注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭此窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭3D效果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(701, 355);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(693, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "胸围统计折线图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 6);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(684, 323);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chart2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(693, 329);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "腰围统计折线图";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(8, 7);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(682, 322);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chart3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(693, 329);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "臀围统计折线图";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(4, 4);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(686, 329);
            this.chart3.TabIndex = 0;
            this.chart3.Text = "chart3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.坐标调整ToolStripMenuItem,
            this.修改颜色ToolStripMenuItem,
            this.关闭数值标注ToolStripMenuItem,
            this.关闭3D效果ToolStripMenuItem,
            this.关闭此窗口ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(713, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 坐标调整ToolStripMenuItem
            // 
            this.坐标调整ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改X轴范围ToolStripMenuItem});
            this.坐标调整ToolStripMenuItem.Name = "坐标调整ToolStripMenuItem";
            this.坐标调整ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.坐标调整ToolStripMenuItem.Text = "坐标调整";
            // 
            // 修改X轴范围ToolStripMenuItem
            // 
            this.修改X轴范围ToolStripMenuItem.Name = "修改X轴范围ToolStripMenuItem";
            this.修改X轴范围ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.修改X轴范围ToolStripMenuItem.Text = "修改所有X轴范围";
            this.修改X轴范围ToolStripMenuItem.Click += new System.EventHandler(this.修改X轴范围ToolStripMenuItem_Click);
            // 
            // 修改颜色ToolStripMenuItem
            // 
            this.修改颜色ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.红色ToolStripMenuItem,
            this.蓝色ToolStripMenuItem,
            this.棕色ToolStripMenuItem,
            this.黑色ToolStripMenuItem,
            this.粉色ToolStripMenuItem,
            this.金色ToolStripMenuItem,
            this.绿色ToolStripMenuItem});
            this.修改颜色ToolStripMenuItem.Name = "修改颜色ToolStripMenuItem";
            this.修改颜色ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.修改颜色ToolStripMenuItem.Text = "修改颜色";
            // 
            // 红色ToolStripMenuItem
            // 
            this.红色ToolStripMenuItem.Name = "红色ToolStripMenuItem";
            this.红色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.红色ToolStripMenuItem.Text = "红色";
            this.红色ToolStripMenuItem.Click += new System.EventHandler(this.红色ToolStripMenuItem_Click);
            // 
            // 蓝色ToolStripMenuItem
            // 
            this.蓝色ToolStripMenuItem.Name = "蓝色ToolStripMenuItem";
            this.蓝色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.蓝色ToolStripMenuItem.Text = "蓝色";
            this.蓝色ToolStripMenuItem.Click += new System.EventHandler(this.蓝色ToolStripMenuItem_Click);
            // 
            // 棕色ToolStripMenuItem
            // 
            this.棕色ToolStripMenuItem.Name = "棕色ToolStripMenuItem";
            this.棕色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.棕色ToolStripMenuItem.Text = "棕色";
            this.棕色ToolStripMenuItem.Click += new System.EventHandler(this.棕色ToolStripMenuItem_Click);
            // 
            // 黑色ToolStripMenuItem
            // 
            this.黑色ToolStripMenuItem.Name = "黑色ToolStripMenuItem";
            this.黑色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.黑色ToolStripMenuItem.Text = "黑色";
            this.黑色ToolStripMenuItem.Click += new System.EventHandler(this.黑色ToolStripMenuItem_Click);
            // 
            // 粉色ToolStripMenuItem
            // 
            this.粉色ToolStripMenuItem.Name = "粉色ToolStripMenuItem";
            this.粉色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.粉色ToolStripMenuItem.Text = "粉色";
            this.粉色ToolStripMenuItem.Click += new System.EventHandler(this.粉色ToolStripMenuItem_Click);
            // 
            // 金色ToolStripMenuItem
            // 
            this.金色ToolStripMenuItem.Name = "金色ToolStripMenuItem";
            this.金色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.金色ToolStripMenuItem.Text = "金色";
            this.金色ToolStripMenuItem.Click += new System.EventHandler(this.金色ToolStripMenuItem_Click);
            // 
            // 绿色ToolStripMenuItem
            // 
            this.绿色ToolStripMenuItem.Name = "绿色ToolStripMenuItem";
            this.绿色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.绿色ToolStripMenuItem.Text = "绿色";
            this.绿色ToolStripMenuItem.Click += new System.EventHandler(this.绿色ToolStripMenuItem_Click);
            // 
            // 关闭数值标注ToolStripMenuItem
            // 
            this.关闭数值标注ToolStripMenuItem.Name = "关闭数值标注ToolStripMenuItem";
            this.关闭数值标注ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.关闭数值标注ToolStripMenuItem.Text = "关闭数值标注";
            this.关闭数值标注ToolStripMenuItem.Click += new System.EventHandler(this.关闭数值标注ToolStripMenuItem_Click);
            // 
            // 关闭此窗口ToolStripMenuItem
            // 
            this.关闭此窗口ToolStripMenuItem.Name = "关闭此窗口ToolStripMenuItem";
            this.关闭此窗口ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.关闭此窗口ToolStripMenuItem.Text = "关闭此窗口";
            this.关闭此窗口ToolStripMenuItem.Click += new System.EventHandler(this.关闭此窗口ToolStripMenuItem_Click);
            // 
            // 关闭3D效果ToolStripMenuItem
            // 
            this.关闭3D效果ToolStripMenuItem.Name = "关闭3D效果ToolStripMenuItem";
            this.关闭3D效果ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.关闭3D效果ToolStripMenuItem.Text = "关闭3D效果";
            this.关闭3D效果ToolStripMenuItem.Click += new System.EventHandler(this.关闭3D效果ToolStripMenuItem_Click);
            // 
            // frmDataStatisticsResultDialog1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 395);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDataStatisticsResultDialog1";
            this.Text = "单年龄段分析";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 坐标调整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改X轴范围ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改颜色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 红色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 蓝色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 棕色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 黑色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粉色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 金色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绿色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭此窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭数值标注ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭3D效果ToolStripMenuItem;
    }
}