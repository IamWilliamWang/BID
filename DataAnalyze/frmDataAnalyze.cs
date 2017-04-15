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
    public partial class frmDataAnalyze : Form
    {
        private DataSet allFindedDataSet;

        public frmDataAnalyze()
        {
            InitializeComponent();
        }

        private void showAllFindedData()
        {
            String sql = "select * " +
                        "from BasicData " +
                        "where 性别='" + cmbSex.Text + "' and 胸围>" + txt1_Bust.Text + " and 胸围<" + txt2_Bust.Text + " " +
                        "and 腰围>" + txt1_Waist.Text + " and 腰围<" + txt2_Waist.Text + " " +
                        "and 臀围>" + txt1_ButtockGirth.Text + " and 臀围<" + txt2_ButtockGirth.Text + " " +
                        "and 年龄>" + txt1_Age.Text + " and 年龄<" + txt2_Age.Text +
                        "and 身高>" + txt1_BodyHigh.Text + " and 身高<" + txt2_BodyHigh.Text;

            BaseClass.DataBase myDataUtil = new BaseClass.DataBase();
            this.allFindedDataSet = myDataUtil.RunProcReturn(sql, "BasicData");
            this.dataGridViewFindResult.DataSource = allFindedDataSet.Tables[0];
            
        }

        private void showAnalyzedData()
        {
            //String[] columnNames = { "年龄", "体重", "头高", "头宽", "头长", "头围", "头冠状围", "耳屏间弧", "头矢状弧", "眉间顶颈弧长", "形态面长", "瞳孔间距", "颈根厚", "颈中围", "颈围", "肩宽", "左肩宽", "右肩宽", "左肩斜", "右肩斜", "前胸宽", "乳间距", "前颈点到乳峰长左", "前颈点到乳峰长右", "胸围", "胸腔带围", "胸下围", "后背宽", "胸厚", "腰围", "腰背水平差", "臀厚", "腹围厚", "上臀围", "臀围", "臀部后突围", "腹围", "腹部前突围", "腰臀距后", "腰臀长左", "腰臀长右", "上体侧躯干长左", "上体侧躯干长右", "身高", "颈椎点高", "颈臀距", "颈膝距", "背长", "肩胛骨高", "胸围高", "前颈点高", "全臂长左", "全臂长右", "臂长左", "臂长右", "上臂长左", "上臂长右", "上臂围左", "上臂围右", "腕围左", "腕围右", "掌厚", "掌围", "腿内侧长左", "腿内侧长右", "腿外侧长左", "腿外侧长右", "腿外侧缝长左", "腿外侧缝长右", "大臀围左", "大臀围右", "膝围左", "膝围右", "腿肚围左", "腿肚围右", "踝围左", "踝围右", "腰膝距", "腰高", "臀高", "臀后突点高", "会阴高", "腹高", "腹部前突点高", "股上长", "会阴上部前后长", "足长", "足宽", "足围", "足趾高", "跗骨点高", "内踝高", "外踝高" };
            List<List<double>> allFindedDataRows = new List<List<double>>();
            DataTable dt = allFindedDataSet.Tables[0];
            foreach(DataRow row in dt.Rows)
            {
                int 该行总列数 = row.ItemArray.Count();
                int 当前查找的列号 = 3;
                List<double> rowDataList = new List<double>();
                while (当前查找的列号 < 该行总列数)
                {
                    try
                    {
                        float data = float.Parse(row.ItemArray[当前查找的列号].ToString());
                        rowDataList.Add(data);
                    }
                    catch
                    {
                        ;
                    }
                    finally
                    {
                        当前查找的列号++;
                    }
                }
                allFindedDataRows.Add(rowDataList);
                
            }

            List<double> 平均值 = DataAnalyzeUtil.get平均值List(allFindedDataRows);
            List<double> 最大值 = DataAnalyzeUtil.get最大值List(allFindedDataRows);
            List<double> 最小值 = DataAnalyzeUtil.get最小值List(allFindedDataRows);
            List<double> 极差 = DataAnalyzeUtil.get极差List(allFindedDataRows);
            List<double> 标准差 = DataAnalyzeUtil.get标准差List(allFindedDataRows);

            List<List<double>> analyzeData = new List<List<double>>();
            analyzeData.Add(平均值);
            analyzeData.Add(最大值);
            analyzeData.Add(最小值);
            analyzeData.Add(极差);
            analyzeData.Add(标准差);

            String[] columnNames = { "平均值", "最大值", "最小值", "极差", "标准差" };
            int dataGridViewRowIndex = 0;
            foreach (List<double> thisList in analyzeData)
            {
                this.dataGridViewAnalyzeResult.Rows.Add();

                int dataGridViewColumnIndex = 1;
                dataGridViewAnalyzeResult.Rows[dataGridViewRowIndex].Cells[0].Value = columnNames[dataGridViewRowIndex];
                foreach (float element in thisList)
                {
                    dataGridViewAnalyzeResult.Rows[dataGridViewRowIndex].Cells[dataGridViewColumnIndex++].Value = element;
                }
                dataGridViewRowIndex++;
            }

        }

        private void button查询_Click(object sender, EventArgs e)
        {
            this.showAllFindedData();
            
        }

        private void button统计_Click(object sender, EventArgs e)
        {
            this.showAnalyzedData();
        }
    }
}
