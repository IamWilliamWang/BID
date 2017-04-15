using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID.InfoAddForm
{
    public partial class frmAddData : Form
    {
        public frmAddData()
        {
            InitializeComponent();
        }
        #region  当前窗体的所有共公变量
        BaseClass.BaseInfo MyMC = new BID.BaseClass.BaseInfo();
        BaseClass.DataBase MyDataClass = new BID.BaseClass.DataBase();
        public static DataSet MyDS_Grid;
        public static int hold_n = 0;
        public static string Part_ID = "";  //存储数据表的ID信息
     
        BaseClass.cOwnerInfo Ownerinfo = new BID.BaseClass.cOwnerInfo();
        BaseClass.cFootDataInfo FootDataInfo = new BID.BaseClass.cFootDataInfo();
        BaseClass.cHeaderDataInfo HeaderDataInfo = new BID.BaseClass.cHeaderDataInfo();
        BaseClass.cNeckDataInfo NeckDataInfo = new BID.BaseClass.cNeckDataInfo();
        BaseClass.cShoulderDataInfo ShoulderDataInfo = new BID.BaseClass.cShoulderDataInfo();
        BaseClass.cChestDataInfo ChestDataInfo = new BID.BaseClass.cChestDataInfo();
        BaseClass.cBellyWaistHipDataInfo BellyWaistHipDataInfo = new BID.BaseClass.cBellyWaistHipDataInfo();
        BaseClass.cTrunkIntegralDataInfo TrunkIntegralDataInfo = new BID.BaseClass.cTrunkIntegralDataInfo();
        BaseClass.cUpperLimbsDataInfo UpperLimbsDataInfo = new BID.BaseClass.cUpperLimbsDataInfo();
        BaseClass.cLowerLimbsDataInfo LowerLimbsDataInfo = new BID.BaseClass.cLowerLimbsDataInfo();
        #endregion

        private void Part0_Add_Click(object sender, EventArgs e)
        {
           
          
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllOwner("Owner");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt0ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt0ID.Text = P_Str_newID;
            }
        }

        private void Sut_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView0_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView0, groupBox20.Controls, "Owner_");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView1, groupBox21.Controls, "HeaderData_");
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView2, groupBox22.Controls, "NeckData_");
        }
        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView3, groupBox23.Controls, "ShoulderData_");
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView4, groupBox24.Controls, "ChestData_");
        }

        private void dataGridView5_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView5, groupBox25.Controls, "BellyWaistHipData_");
        }
        private void dataGridView6_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView6, groupBox26.Controls, "TrunkIntegral_");
        }

        private void dataGridView7_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView7, groupBox27.Controls, "UpperLimbsData_");
        }

        private void dataGridView8_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView8, groupBox28.Controls, "LowerLimbsData_");
        }
        private void dataGridView9_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView9, groupBox29.Controls, "FootData_");
        }

        private void frmAddData_Load(object sender, EventArgs e)
        {

        }

        private void Part1_Add_Click(object sender, EventArgs e)
        {
         
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllHeaderData("HeaderData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt1ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt1ID.Text = P_Str_newID;
            }
        }

        private void Part2_Add_Click(object sender, EventArgs e)
        {
         
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllNeckData("NeckData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt2ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt2ID.Text = P_Str_newID;
            }
        }

        private void Part3_Add_Click(object sender, EventArgs e)
        {
           
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllShoulderData("ShoulderData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt3ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt3ID.Text = P_Str_newID;
            }
        }

        private void Part4_Add_Click(object sender, EventArgs e)
        {
           
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllChestData("ChestData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt4ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt4ID.Text = P_Str_newID;
            }
        }

        private void Part5_Add_Click(object sender, EventArgs e)
        {
          
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllBellyWaistHipData("BellyWaistHipData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt5ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt5ID.Text = P_Str_newID;
            }
        }

        private void Part6_Add_Click(object sender, EventArgs e)
        {
           
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllTrunkIntegralData("TrunkIntegralData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt6ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt6ID.Text = P_Str_newID;
            }
        }

        private void Part7_Add_Click(object sender, EventArgs e)
        {
           
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllUpperLimbsData("UpperLimbsData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt7ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt7ID.Text = P_Str_newID;
            }
        }

        private void Part8_Add_Click(object sender, EventArgs e)
        {
          
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllLowerLimbsData("LowerLimbsData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt8ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt8ID.Text = P_Str_newID;
            }
        }

        private void Part9_Add_Click(object sender, EventArgs e)
        {
           
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = MyMC.GetAllFootData("FootData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txt9ID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txt9ID.Text = P_Str_newID;
            }
        }

        private void Part0_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                Ownerinfo.id = txt0ID.Text;
                Ownerinfo.idcard = txtIDCard.Text;
                Ownerinfo.sex = cmbSex.Text;
                Ownerinfo.age = txtAge.Text;
                Ownerinfo.job = txtJob.Text;
                Ownerinfo.workUnit = txtWorkUnit.Text;
                Ownerinfo.weight = txtWeight.Text;
              


                //执行添加
                int id = MyMC.AddOwner(Ownerinfo);
                MessageBox.Show("新增--基础数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView0.DataSource = MyMC.GetAllOwner("Owner").Tables[0].DefaultView;
            this.SetdataGridView0HeadText();
        }
        private void SetdataGridView0HeadText()
        {
            dataGridView0.Columns[0].HeaderText = "ID";
            dataGridView0.Columns[1].HeaderText = "性别";
            dataGridView0.Columns[2].HeaderText = "年龄";
            dataGridView0.Columns[3].HeaderText = "职位";
            dataGridView0.Columns[4].HeaderText = "工作单位";
            dataGridView0.Columns[5].HeaderText = "身份证前6位";
            dataGridView0.Columns[6].HeaderText = "体重";
        }

        private void Part9_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                FootDataInfo.id = txt9ID.Text;
                FootDataInfo.footLength = txtFootLength.Text;
                FootDataInfo.footWidth = txtFootWidth.Text;
                FootDataInfo.footGirth = txtFootGirth.Text;
                FootDataInfo.toeHeihet = txtToeHeihet.Text;
                FootDataInfo.footTarsiHigh = txtFootTarsiHigh.Text;
                FootDataInfo.medialMalleolusHigh = txtMedialMalleolusHigh.Text;
                FootDataInfo.lateralMalleolusHigh = txtLateralMalleolusHigh.Text;

                //执行添加
                int id = MyMC.AddFootData(FootDataInfo);
                MessageBox.Show("新增--足部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView9.DataSource = MyMC.GetAllFootData("FootData").Tables[0].DefaultView;
            this.SetdataGridView9HeadText();
        }
        public void SetdataGridView9HeadText()
        {
            dataGridView9.Columns[0].HeaderText = "ID";
            dataGridView9.Columns[1].HeaderText = "足长";
            dataGridView9.Columns[2].HeaderText = "足宽";
            dataGridView9.Columns[3].HeaderText = "足围";
            dataGridView9.Columns[4].HeaderText = "足趾高";
            dataGridView9.Columns[5].HeaderText = "跗骨点高";
            dataGridView9.Columns[6].HeaderText = "内踝高";
            dataGridView9.Columns[7].HeaderText = "外踝高";


        }

        private void Part1_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                HeaderDataInfo.id = txt1ID.Text;
                HeaderDataInfo.headHeight = txtHeadHeight.Text;
                HeaderDataInfo.headWidth = txtHeadWidth.Text;
                HeaderDataInfo.headLength = txtHeadLength.Text;
                HeaderDataInfo.headGirth = txtHeadGirth.Text;
                HeaderDataInfo.crownShapeAround = txtCrownShapeAround.Text;
                HeaderDataInfo.bitragionIntertragicArc = txtBitragionIntertragicArc.Text;
                HeaderDataInfo.headSagittalArc = txtHeadSagittalArc.Text;
                HeaderDataInfo.browTopNeckArcLength = txtBrowTopNeckArcLength.Text;
                HeaderDataInfo.morphoGicalFacialLength = txtMorphoGicalFacialLength.Text;
                HeaderDataInfo.interpupillaryDistance = txtInterpupillaryDistance.Text;
                //执行添加
                int id = MyMC.AddHeaderData(HeaderDataInfo);
                MessageBox.Show("新增--头部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = MyMC.GetAllHeaderData("HeaderData").Tables[0].DefaultView;
            this.SetdataGridView1HeadText();
        }
        public void SetdataGridView1HeadText()
        {
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "头高";
            dataGridView1.Columns[2].HeaderText = "头宽";
            dataGridView1.Columns[3].HeaderText = "头长";
            dataGridView1.Columns[4].HeaderText = "头围";
            dataGridView1.Columns[5].HeaderText = "头冠状围";
            dataGridView1.Columns[6].HeaderText = "耳屏间弧";
            dataGridView1.Columns[7].HeaderText = "头矢状弧";
            dataGridView1.Columns[8].HeaderText = "眉间顶颈弧长";
            dataGridView1.Columns[9].HeaderText = "形态面长";
            dataGridView1.Columns[10].HeaderText = "瞳孔间距";

        }

        private void Part2_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                NeckDataInfo.id = txt2ID.Text;
                NeckDataInfo.cervixThickness = txtCervixThickness.Text;
                NeckDataInfo.midNeckGirth = txtMidNeckGirth.Text;
                NeckDataInfo.neckGirth = txtNeckGirth.Text;

                //执行添加
                int id = MyMC.AddNeckData(NeckDataInfo);
                MessageBox.Show("新增--肩部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView2.DataSource = MyMC.GetAllNeckData("NeckData").Tables[0].DefaultView;
            this.SetdataGridView2HeadText();
        }
        public void SetdataGridView2HeadText()
        {
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "颈根厚";
            dataGridView2.Columns[2].HeaderText = "颈中围";
            dataGridView2.Columns[3].HeaderText = "颈围";
        }

        private void Part3_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                ShoulderDataInfo.id = txt3ID.Text;
                ShoulderDataInfo.shoulderAcross = txtShoulderAcross.Text;
                ShoulderDataInfo.leftShoulder = txtLeftShoulder.Text;
                ShoulderDataInfo.rightShoulder = txtRightShoulder.Text;
                ShoulderDataInfo.leftShoulderAngle = txtLeftShoulderAngle.Text;
                ShoulderDataInfo.rightShoulderAngle = txtRightShoulderAngle.Text;

                //执行添加
                int id = MyMC.AddShoulderData(ShoulderDataInfo);
                MessageBox.Show("新增--肩部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView3.DataSource = MyMC.GetAllShoulderData("ShoulderData").Tables[0].DefaultView;
            this.SetdataGridView3HeadText();
        }
        public void SetdataGridView3HeadText()
        {
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "肩宽";
            dataGridView3.Columns[2].HeaderText = "左肩宽";
            dataGridView3.Columns[3].HeaderText = "右肩宽";
            dataGridView3.Columns[4].HeaderText = "左肩斜";
            dataGridView3.Columns[5].HeaderText = "右肩斜";

        }

        private void Part4_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                ChestDataInfo.id = txt4ID.Text;
                ChestDataInfo.bust = txtBust.Text;
                ChestDataInfo.chestThickness = txtChestThickness.Text;
                ChestDataInfo.acrossFront = txtAcrossFront.Text;
                ChestDataInfo.acrossBack = txtAcrossBack.Text;
                ChestDataInfo.milkInterval = txtMilkInterval.Text;
                ChestDataInfo.underBustGirth = txtUnderBustGirth.Text;
                ChestDataInfo.thoracicCavityBand = txtThoracicCavityBand.Text;
                ChestDataInfo.neckPointToBbustProminenceLeft = txtNeckPointToBbustProminenceLeft.Text;
                ChestDataInfo.neckPointToBustProminenceRight = txtNeckPointToBustProminenceRight.Text;

                //执行添加
                int id = MyMC.AddChestData(ChestDataInfo);
                MessageBox.Show("新增--胸部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView4.DataSource = MyMC.GetAllChestData("ChestData").Tables[0].DefaultView;
            this.SetdataGridView4HeadText();
        }
        public void SetdataGridView4HeadText()
        {
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "前胸宽";
            dataGridView4.Columns[2].HeaderText = "乳间距";
            dataGridView4.Columns[3].HeaderText = "前颈点到乳峰长左";
            dataGridView4.Columns[4].HeaderText = "前颈点到乳峰长右";
            dataGridView4.Columns[5].HeaderText = "胸围";
            dataGridView4.Columns[6].HeaderText = "胸腔带围";
            dataGridView4.Columns[7].HeaderText = "胸下围";
            dataGridView4.Columns[8].HeaderText = "后背宽";
            dataGridView4.Columns[9].HeaderText = "胸厚";
        }

        private void Part5_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                BellyWaistHipDataInfo.id = txt5ID.Text;
                BellyWaistHipDataInfo.waist = txtWaist.Text;
                BellyWaistHipDataInfo.waistBackLevelDifference = txtWaistBackLevelDifference.Text;
                BellyWaistHipDataInfo.hipThickness = txtHipThickness.Text;
                BellyWaistHipDataInfo.adominalThickness = txtAdominalThickness.Text;
                BellyWaistHipDataInfo.hipGirth = txtHipGirth.Text;
                BellyWaistHipDataInfo.buttockGirth = txtButtockGirth.Text;
                BellyWaistHipDataInfo.maximumHipGirth = txtMaximumHipGirth.Text;
                BellyWaistHipDataInfo.belly = txtBelly.Text;
                BellyWaistHipDataInfo.maximumBellyCircamference = txtMaximumBellyCircamference.Text;
                BellyWaistHipDataInfo.waistPelvisDistance = txtWaistPelvisDistance.Text;
                BellyWaistHipDataInfo.waistPelvisLengthLeft = txtWaistPelvisLengthLeft.Text;
                BellyWaistHipDataInfo.waistPelvisLengthRight = txtWaistPelvisLengthRight.Text;
                BellyWaistHipDataInfo.waistUnderarmLeft = txtWaistUnderarmLeft.Text;
                BellyWaistHipDataInfo.waistUnderarmRight = txtWaistUnderarmRight.Text;
                //执行添加
                int id = MyMC.AddBellyWaistHipData(BellyWaistHipDataInfo);
                MessageBox.Show("新增--腹腰臀部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView5.DataSource = MyMC.GetAllBellyWaistHipData("BellyWaistHipData").Tables[0].DefaultView;
            this.SetdataGridView5HeadText();
        }
        public void SetdataGridView5HeadText()
        {
            dataGridView5.Columns[0].HeaderText = "ID";
            dataGridView5.Columns[1].HeaderText = "腰围";
            dataGridView5.Columns[2].HeaderText = "腰背水平差";
            dataGridView5.Columns[3].HeaderText = "臀厚";
            dataGridView5.Columns[4].HeaderText = "腹厚";
            dataGridView5.Columns[5].HeaderText = "上臀围";
            dataGridView5.Columns[6].HeaderText = "臀围";
            dataGridView5.Columns[7].HeaderText = "臀部后突围";
            dataGridView5.Columns[8].HeaderText = "腹围";
            dataGridView5.Columns[9].HeaderText = "腹部前突围";
            dataGridView5.Columns[10].HeaderText = "腰臀距后";
            dataGridView5.Columns[11].HeaderText = "腰臀长左";
            dataGridView5.Columns[12].HeaderText = "腰臀长右";
            dataGridView5.Columns[13].HeaderText = "上体侧躯干长左";
            dataGridView5.Columns[14].HeaderText = "上体侧躯干长右";

        }

        private void Part6_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                TrunkIntegralDataInfo.id = txt6ID.Text;
                TrunkIntegralDataInfo.bodyHigh = txtBodyHigh.Text;
                TrunkIntegralDataInfo.cervicalHeight = txtCervicalHeight.Text;
                TrunkIntegralDataInfo.cervicalHip = txtCervicalHip.Text;
                TrunkIntegralDataInfo.cervicalHeightKnee = txtCervicalHeightKnee.Text;
                TrunkIntegralDataInfo.cervicalWaist = txtCervicalWaist.Text;
                TrunkIntegralDataInfo.scapulaHeight = txtScapulaHeight.Text;
                TrunkIntegralDataInfo.breastHeight = txtBreastHeight.Text;
                TrunkIntegralDataInfo.neckFrontHeight = txtNeckFrontHeight.Text;

                //执行添加
                int id = MyMC.AddTrunkIntegralData(TrunkIntegralDataInfo);
                MessageBox.Show("新增--躯干数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView6.DataSource = MyMC.GetAllTrunkIntegralData("TrunkIntegralData").Tables[0].DefaultView;
            this.SetdataGridView6HeadText();
        }
        public void SetdataGridView6HeadText()
        {
            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[1].HeaderText = "身高";
            dataGridView6.Columns[2].HeaderText = "颈椎点高";
            dataGridView6.Columns[3].HeaderText = "颈臀距";
            dataGridView6.Columns[4].HeaderText = "颈膝距";
            dataGridView6.Columns[5].HeaderText = "背长";
            dataGridView6.Columns[6].HeaderText = "肩胛骨高";
            dataGridView6.Columns[7].HeaderText = "胸围高";
            dataGridView6.Columns[8].HeaderText = "前颈点高";
        }

        private void Part7_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                UpperLimbsDataInfo.id = txt7ID.Text;
                UpperLimbsDataInfo.cervicalWristLengthLeft = txtCervicalWristLengthLeft.Text;
                UpperLimbsDataInfo.cervicalWristLengthRight = txtCervicalWristLengthRight.Text;
                UpperLimbsDataInfo.armLengthLeft = txtArmLengthLeft.Text;
                UpperLimbsDataInfo.armLengthRight = txtArmLengthRight.Text;
                UpperLimbsDataInfo.upperArmLengthLeft = txtUpperArmLengthLeft.Text;
                UpperLimbsDataInfo.upperArmLengthRight = txtUpperArmLengthRight.Text;
                UpperLimbsDataInfo.upperArmGirthLeft = txtUpperArmGirthLeft.Text;
                UpperLimbsDataInfo.upperArmGirthRight = txtUpperArmGirthRight.Text;
                UpperLimbsDataInfo.wristGirthLeft = txtWristGirthLeft.Text;
                UpperLimbsDataInfo.wristGirthRight = txtWristGirthRight.Text;
                UpperLimbsDataInfo.handThickness = txtHandThickness.Text;
                UpperLimbsDataInfo.handGirth = txtHandGirth.Text;
                //执行添加
                int id = MyMC.AddUpperLimbsData(UpperLimbsDataInfo);
                MessageBox.Show("新增--上肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView7.DataSource = MyMC.GetAllUpperLimbsData("UpperLimbsData").Tables[0].DefaultView;
            this.SetdataGridView7HeadText();
        }
        public void SetdataGridView7HeadText()
        {
            dataGridView7.Columns[0].HeaderText = "ID";
            dataGridView7.Columns[1].HeaderText = "全臂长左";
            dataGridView7.Columns[2].HeaderText = "全臂长右";
            dataGridView7.Columns[3].HeaderText = "臂长左";
            dataGridView7.Columns[4].HeaderText = "臂长右";
            dataGridView7.Columns[5].HeaderText = "上臂长左";
            dataGridView7.Columns[6].HeaderText = "上臂长右";
            dataGridView7.Columns[7].HeaderText = "上臂围左";
            dataGridView7.Columns[8].HeaderText = "上臂围右";
            dataGridView7.Columns[9].HeaderText = "腕围左";
            dataGridView7.Columns[10].HeaderText = "腕围右";
            dataGridView7.Columns[11].HeaderText = "掌厚";
            dataGridView7.Columns[12].HeaderText = "掌围";

        }

        private void Part8_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //添加数据
                LowerLimbsDataInfo.id = txt8ID.Text;
                LowerLimbsDataInfo.insideLegLengthLeft = txtInsideLegLengthLeft.Text;
                LowerLimbsDataInfo.insideLegLengthRight = txtInsideLegLengthRight.Text;
                LowerLimbsDataInfo.sideLengthToWaistLeft = txtSideLengthToWaistLeft.Text;
                LowerLimbsDataInfo.sideLengthToWaistRight = txtSideLengthToWaistRight.Text;
                LowerLimbsDataInfo.lateralHeightOfWaistLeft = txtLateralHeightOfWaistLeft.Text;
                LowerLimbsDataInfo.lateralHeightOfWaistRight = txtLateralHeightOfWaistRight.Text;
                LowerLimbsDataInfo.thighGirthLeft = txtThighGirthLeft.Text;
                LowerLimbsDataInfo.thighGirthRight = txtThighGirthRight.Text;
                LowerLimbsDataInfo.kneeGirthLeft = txtKneeGirthLeft.Text;
                LowerLimbsDataInfo.kneeGirthRight = txtKneeGirthRight.Text;
                LowerLimbsDataInfo.calfGirthLeft = txtCalfGirthLeft.Text;
                LowerLimbsDataInfo.calfGirthRight = txtCalfGirthRight.Text;
                LowerLimbsDataInfo.ankleGirthLeft = txtAnkleGirthLeft.Text;
                LowerLimbsDataInfo.ankleGirthRight = txtAnkleGirthRight.Text;
                LowerLimbsDataInfo.waistKnee = txtWaistKnee.Text;
                LowerLimbsDataInfo.waistHeight = txtWaistHeight.Text;
                LowerLimbsDataInfo.hipHeight = txtHipHeight.Text;
                LowerLimbsDataInfo.maximumHipHeight = txtMaximumHipHeight.Text;
                LowerLimbsDataInfo.crothHeight = txtCrothHeight.Text;
                LowerLimbsDataInfo.bellyHeight = txtBellyHeight.Text;
                LowerLimbsDataInfo.maximuBellyHeight = txtMaximuBellyHeight.Text;
                LowerLimbsDataInfo.crothToWaistband = txtCrothToWaistband.Text;
                LowerLimbsDataInfo.crothLength = txtCrothLength.Text;
                //执行添加
                int id = MyMC.AddLowerLimbsData(LowerLimbsDataInfo);
                MessageBox.Show("新增--下肢数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView8.DataSource = MyMC.GetAllLowerLimbsData("LowerLimbsData").Tables[0].DefaultView;
            this.SetdataGridView8HeadText();
        }
        public void SetdataGridView8HeadText()
        {
            dataGridView8.Columns[0].HeaderText = "ID";
            dataGridView8.Columns[1].HeaderText = "腿内侧长左";
            dataGridView8.Columns[2].HeaderText = "腿内侧长右";
            dataGridView8.Columns[3].HeaderText = "腿外侧长左";
            dataGridView8.Columns[4].HeaderText = "腿外侧长右";
            dataGridView8.Columns[5].HeaderText = "腿外侧缝长左";
            dataGridView8.Columns[6].HeaderText = "腿外侧缝长右";
            dataGridView8.Columns[7].HeaderText = "大腿围左";
            dataGridView8.Columns[8].HeaderText = "大腿围右";
            dataGridView8.Columns[9].HeaderText = "膝围左";
            dataGridView8.Columns[10].HeaderText = "膝围右";
            dataGridView8.Columns[11].HeaderText = "腿肚围左";
            dataGridView8.Columns[12].HeaderText = "腿肚围右";
            dataGridView8.Columns[13].HeaderText = "踝围左";
            dataGridView8.Columns[14].HeaderText = "踝围右";
            dataGridView8.Columns[15].HeaderText = "腰膝距";
            dataGridView8.Columns[16].HeaderText = "腰高";
            dataGridView8.Columns[17].HeaderText = "臀高";
            dataGridView8.Columns[18].HeaderText = "臀后突点高";
            dataGridView8.Columns[19].HeaderText = "会阴高";
            dataGridView8.Columns[20].HeaderText = "腹高";
            dataGridView8.Columns[21].HeaderText = "腹部前突点高";
            dataGridView8.Columns[22].HeaderText = "股上长";
            dataGridView8.Columns[23].HeaderText = "会阴上部前后长";
        }

        private void Sut_Save_Click(object sender, EventArgs e)
        {
            string strsql = "select * from BasicData";
            string DA =MyMC.AddOwner(Ownerinfo) + "' ";
            DA += MyMC.AddHeaderData(HeaderDataInfo) + "' ";
            DA += MyMC.AddNeckData(NeckDataInfo) + "' ";
            DA += MyMC.AddShoulderData(ShoulderDataInfo) + "' ";
            DA += MyMC.AddChestData(ChestDataInfo) + "' ";
            DA += MyMC.AddBellyWaistHipData(BellyWaistHipDataInfo) + "' ";
            DA += MyMC.AddTrunkIntegralData(TrunkIntegralDataInfo) + "' ";
            DA += MyMC.AddUpperLimbsData(UpperLimbsDataInfo) + "' ";
            DA += MyMC.AddLowerLimbsData(LowerLimbsDataInfo) + "' ";
            DA += MyMC.AddFootData(FootDataInfo) + "' ";

            //将查询条件添加到SQL语句的尾部
            strsql = strsql + " where 1=1  ";
            //if (DA != "")
            //{
                strsql = strsql + DA;
          //  }
            //按照指定的条件进行添加
            MyDS_Grid = MyDataClass.getDataSet(strsql, "BasicData");
            MyDataClass.RunProc(BaseClass.BaseInfo.ADDs);
            this.Close();
           // dgvQueryList.DataSource = MyDS_Grid.Tables[0].DefaultView;
           // BaseClass.BaseInfo.ADDs = ""; //清空MyModule公共类中的ADDs变量
         //用MyModule公共类中的Part_SaveClass()方法组合添加或修改的SQL语句
          //  MyMC.Part_SaveClass(All_Field, S_0.Text.Trim(), "", tabControl1.TabPages[0].Controls, "S_", "tb_Stuffbusic", 30, hold_n);
            //如果ADDs变量不为空，则通过MyMeans公共类中的getsqlcom()方法执行添加、修改操作
            //if (BaseClass.BaseInfo.ADDs != "")
              //  MyDataClass.getsqlcom(ModuleClass.MyModule.ADDs);
        }

        private void Sut_SaveAll_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("是否将所有数据整合到BasicData中？警告：此操作将会覆盖原表", "整合所有数据吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String sql = "drop table BasicData " +
                            " " +
                            " " +
                            "select Owner.ID ID,Sex 性别,IDCard 身份证号,Age 年龄,Job 职位,WorkUnit 工作单位,Weight 体重, HeadHeight 头高,HeadWidth 头宽,HeadLength 头长,HeadGirth 头围,CrownShapeAround 头冠状围,BitragionIntertragicArc 耳屏间弧,HeadSagittalArc 头矢状弧,BrowTopNeckArcLength 眉间顶颈弧长,MorphoGicalFacialLength 形态面长,InterpupillaryDistance 瞳孔间距,CervixThickness 颈根厚,MidNeckGirth 颈中围,NeckGirth 颈围,ShoulderAcross 肩宽,LeftShoulder 左肩宽,RightShoulder 右肩宽,LeftShoulderAngle 左肩斜,RightShoulderAngle 右肩斜,AcrossFront 前胸宽,MilkInterval 乳间距,NeckPointToBbustProminenceLeft 前颈点到乳峰长左,NeckPointToBustProminenceRight 前颈点到乳峰长右,Bust 胸围,ThoracicCavityBand 胸腔带围,UnderBustGirth 胸下围,AcrossBack 后背宽,ChestThickness 胸厚,Waist 腰围,WaistBackLevelDifference 腰背水平差,HipThickness 臀厚,AdominalThickness 腹围厚,HipGirth 上臀围,ButtockGirth 臀围,MaximumHipGirth 臀部后突围,Belly 腹围,MaximumBellyCircamference 腹部前突围,WaistPelvisDistance 腰臀距后,WaistPelvisLengthLeft 腰臀长左,WaistPelvisLengthRight 腰臀长右,WaistUnderarmLeft 上体侧躯干长左,WaistUnderarmRight 上体侧躯干长右,BodyHigh 身高,CervicalHeight 颈椎点高,CervicalHip 颈臀距,CervicalHeightKnee 颈膝距,CervicalWaist 背长,ScapulaHeight 肩胛骨高,BreastHeight 胸围高,NeckFrontHeight 前颈点高,CervicalWristLengthLeft 全臂长左,CervicalWristLengthRight 全臂长右,ArmLengthLeft 臂长左,ArmLengthRight 臂长右,UpperArmLengthLeft 上臂长左,UpperArmLengthRight 上臂长右,UpperArmGirthLeft 上臂围左,UpperArmGirthRight 上臂围右,WristGirthLeft 腕围左,WristGirthRight 腕围右,HandThickness 掌厚,HandGirth 掌围,InsideLegLengthLeft 腿内侧长左,InsideLegLengthRight 腿内侧长右,SideLengthToWaistLeft 腿外侧长左,SideLengthToWaistRight 腿外侧长右,LateralHeightOfWaistLeft 腿外侧缝长左,LateralHeightOfWaistRight 腿外侧缝长右,ThighGirthLeft 大臀围左,ThighGirthRight 大臀围右,KneeGirthLeft 膝围左,KneeGirthRight 膝围右,CalfGirthLeft 腿肚围左,CalfGirthRight 腿肚围右,AnkleGirthLeft 踝围左,AnkleGirthRight 踝围右,WaistKnee 腰膝距,WaistHeight 腰高,HipHeight 臀高,MaximumHipHeight 臀后突点高,CrothHeight 会阴高,BellyHeight 腹高,MaximuBellyHeight 腹部前突点高,CrothToWaistband 股上长,CrothLength 会阴上部前后长,FootLength 足长,FootWidth 足宽,FootGirth 足围,ToeHeihet 足趾高,FootTarsiHigh 跗骨点高,MedialMalleolusHigh 内踝高,LateralMalleolusHigh 外踝高 " +
                            " into BasicData " +
                            "from " +
                            "Owner " +
                            " left outer join ChestData on Owner.ID = ChestData.ID " +
                            " left outer join FootData on ChestData.ID = FootData.ID " +
                            " left outer join HeaderData on FootData.ID = HeaderData.ID " +
                            " left outer join LowerLimbsData on HeaderData.ID = LowerLimbsData.ID " +
                            " left outer join NeckData on LowerLimbsData.ID = NeckData.ID " +
                            " left outer join BellyWaistHipData on NeckData.ID = BellyWaistHipData.ID " +
                            " left outer join ShoulderData on Owner.ID = ShoulderData.ID " +
                            " left outer join TrunkIntegralData on ShoulderData.ID = TrunkIntegralData.ID " +
                            " left outer join UpperLimbsData on TrunkIntegralData.ID = UpperLimbsData.ID";

                MyDataClass.RunProc(sql);
                MessageBox.Show("成功");
            }
        }
    }
}
