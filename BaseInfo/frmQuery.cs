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
    public partial class frmQuery : Form
    {
       
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.DataBase BasicDatainfo = new BID.BaseClass.DataBase();
        public string ARsign = " AND ";
        public static DataSet MyDS_Grid;
        public static string Sut_SQL = "select ID as ID,Sex as 性别,IDCard as 身份证前6位,Bust as 胸围,Age as 年龄,Waist as 腰围,ButtockGirth as 臀围,BodyHigh as 身高 from BasicData";
        
        public frmQuery()
        {
            InitializeComponent();
        }
      

        #region  清空控件集上的控件信息
        /// <summary>
        /// 清空GroupBox控件上的控件信息.
        /// </summary>
        /// <param name="n">控件个数</param>
        /// <param name="GBox">GroupBox控件的数据集</param>
        /// <param name="TName">获取信息控件的部份名称</param>
        private void Clear_Box(int n, Control.ControlCollection GBox, string TName)
        {
            for (int i = 0; i < n; i++)
            {
                foreach (Control C in GBox)
                {
                    if (C.GetType().Name == "TextBox" | C.GetType().Name == "MaskedTextBox" | C.GetType().Name == "ComboBox")
                        if (C.Name.IndexOf(TName) > -1)
                        {
                            C.Text = "";
                        }
                }
            }
        }
        #endregion

        private void frmQuery_Load(object sender, EventArgs e)
        {
            baseinfo.CoPassData(cmbID, "select distinct ID from BasicData", 0);
            baseinfo.CoPassData(cmbSex, "select distinct Sex from BasicData", 0);
            baseinfo.CoPassData(cmbIDCard, "select distinct IDCard from BasicData", 0);

            dgvQueryList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
            this.SetdgvQueryListHeadText();
           
        }

     
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ARsign = " AND ";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ARsign = " OR ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseClass.BaseInfo.FindValue = "";    //清空存储查询语句的变量
            string Find_SQL = Sut_SQL;  //存储显示数据表中所有信息的SQL语句
                                        // baseinfo.Find_Grids(groupBox1.Controls, "Find", ARsign);    //将指定控件集下的控件组合成查询条件
            string strwhere = "";
            string strsql = "select * from BasicData";
            if (cmbID.Text != "")
            {
                strwhere += " and id='"+cmbID.Text + "' ";
            }
            if (cmbSex.Text != "")
            {
                strwhere += " and sex='" + cmbSex.Text + "' ";
            }
            if (cmbIDCard.Text != "")
            {
                strwhere =strwhere+ " and idcard='" + cmbIDCard.Text + "' ";
            }
            if (txt1_Bust.Text != ""&&txt2_Bust.Text!="")
            {
                strwhere = strwhere + " and bust>='" + txt1_Bust.Text + "' and bust<='" + txt2_Bust.Text + "' ";
            }
            if (txt1_Age.Text != "" && txt2_Age.Text != "")
            {
                strwhere = strwhere + " and age>='" + txt1_Age.Text + "' and age<='" + txt2_Age.Text + "' ";
            }
            if (txt1_Waist.Text != "" && txt2_Waist.Text != "")
            {
                strwhere = strwhere + " and Waist>='" + txt1_Waist.Text + "' and Waist<='" + txt2_Waist.Text + "' ";
            }
            if (txt1_BodyHigh.Text != "" && txt2_BodyHigh.Text != "")
            {
                strwhere = strwhere + " and BodyHight>='" + txt1_BodyHigh.Text + "' and BodyHigh<='" + txt2_BodyHigh.Text + "' ";
            }
            //
            if (txt1_ButtockGirth.Text != "" && txt2_ButtockGirth.Text != "")
            {
                strwhere = strwhere + " and ButtockGirth>='" + txt1_ButtockGirth.Text + "' and ButtockGirth<='" + txt2_ButtockGirth.Text + "' ";
            }


            //将查询条件添加到SQL语句的尾部
            strsql = strsql + " where 1=1  ";
                if (strwhere != "")
                {
                strsql = strsql + strwhere;
                }
                //按照指定的条件进行查询
            MyDS_Grid = BasicDatainfo.getDataSet(strsql, "BasicData");
            dgvQueryList.DataSource = MyDS_Grid.Tables[0].DefaultView;
                //在dataGridView1控件是显示查询的结果
              // dgvQueryList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
            checkBox1.Checked = false;
            this.SetdgvQueryListHeadText();
        }

        private void txt1_Bust_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt2_Bust_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt1_Waist_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt2_Waist_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt1_ButtockGirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt2_ButtockGirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt1_Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt2_Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt1_BodyHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }

        private void txt2_BodyHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            baseinfo.Estimate_Key(e, "", 0);
        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dgvQueryList.DataSource = baseinfo.GetAllBasicData("BasicData").Tables[0].DefaultView;
                this.SetdgvQueryListHeadText();
              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear_Box(7, groupBox1.Controls, "cmb");
            Clear_Box(12, groupBox1.Controls, "txt");
            Clear_Box(4, groupBox1.Controls, "Sign");
        }
        public void SetdgvQueryListHeadText()
        {
            dgvQueryList.Columns[0].HeaderText = "ID";
            dgvQueryList.Columns[1].HeaderText = "性别";
            dgvQueryList.Columns[2].HeaderText = "年龄";
            dgvQueryList.Columns[48].HeaderText = "身高";
            dgvQueryList.Columns[5].HeaderText = "身份证前6位";
            dgvQueryList.Columns[29].HeaderText = "胸围";
            dgvQueryList.Columns[34].HeaderText = "腰围";
            dgvQueryList.Columns[39].HeaderText = "臀围";
        }
        private void dgvFootDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbID.Text = this.dgvQueryList[0, dgvQueryList.CurrentCell.RowIndex].Value.ToString();
            cmbSex.Text = this.dgvQueryList[1, dgvQueryList.CurrentCell.RowIndex].Value.ToString();
            cmbIDCard.Text = this.dgvQueryList[2, dgvQueryList.CurrentCell.RowIndex].Value.ToString();
            txt1_Bust.Text = this.dgvQueryList[3, dgvQueryList.CurrentCell.RowIndex].Value.ToString();
            txt1_Waist.Text = this.dgvQueryList[4, dgvQueryList.CurrentCell.RowIndex].Value.ToString();
            txt1_ButtockGirth.Text = this.dgvQueryList[5, dgvQueryList.CurrentCell.RowIndex].Value.ToString();
            txt1_Age.Text = this.dgvQueryList[6, dgvQueryList.CurrentCell.RowIndex].Value.ToString();
            txt1_BodyHigh.Text = this.dgvQueryList[7, dgvQueryList.CurrentCell.RowIndex].Value.ToString();

        }


        private void txt1_Age_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
