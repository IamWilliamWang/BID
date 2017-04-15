using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//引用类库
using System.Data.SqlClient;

namespace BID.BaseInfo
{
    public partial class frmHeaderData : Form
    {
        BaseClass.BaseInfo baseinfo = new BID.BaseClass.BaseInfo();
        BaseClass.cHeaderDataInfo HeaderDataInfo = new BID.BaseClass.cHeaderDataInfo();
        int G_Int_addOrUpdate = 0;
        public frmHeaderData()
        {
            InitializeComponent();
        }
        private void frmHeaderData_Load(object sender, EventArgs e)
        {
            
            dgvHeaderDataList.DataSource = baseinfo.GetAllHeaderData("HeaderData").Tables[0].DefaultView;
            this.SetdgvHeaderDataListHeadText();
        }

        private void tlBtnAdd_Click(object sender, EventArgs e)
        {

            this.editEnabled();
            this.clearText();
            G_Int_addOrUpdate = 0;   //等于０为添加数据
            //设置自动编号
            DataSet ds = null;
            string P_Str_newID = "";
            int P_Int_newID = 0;
            ds = baseinfo.GetAllHeaderData("HeaderData");


            if (ds.Tables[0].Rows.Count == 0)
            {
                txtID.Text = "A0005901m1";
            }
            else
            {
                P_Str_newID = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"]);
                P_Int_newID = Convert.ToInt32(P_Str_newID.Substring(1, 4)) + 1;
                P_Str_newID = "A" + P_Int_newID.ToString();
                txtID.Text = P_Str_newID;
            }
        }
        private void editEnabled()  //屏毕与此功能无关的按钮
        {
            groupBox1.Enabled = true;     //将容器可以使用，准备添加新的往来单位信息
            tlBtnAdd.Enabled = false;
            tlBtnEdit.Enabled = false;
            tlBtnDelete.Enabled = false;
            tlBtnSave.Enabled = true;
            tlBtnCancel.Enabled = true;
        }
        private void cancelEnabled()
        {
            groupBox1.Enabled = false;
            tlBtnAdd.Enabled = true;
            tlBtnEdit.Enabled = true;
            tlBtnDelete.Enabled = true;
            tlBtnSave.Enabled = false;
            tlBtnCancel.Enabled = false;
        }
        private void clearText()
        {
            txtID.Text = string.Empty;
            txtHeadHeight.Text = string.Empty;
            txtHeadWidth.Text = string.Empty;
            txtHeadLength.Text = string.Empty;
            txtHeadGirth.Text = string.Empty;
            txtCrownShapeAround.Text = string.Empty;
            txtBitragionIntertragicArc.Text = string.Empty;
            txtHeadSagittalArc.Text = string.Empty;
            txtBrowTopNeckArcLength.Text = string.Empty;
            txtMorphoGicalFacialLength.Text = string.Empty;
            txtInterpupillaryDistance.Text = string.Empty;
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            this.cancelEnabled();
        }

        private void tlBtnEdit_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            G_Int_addOrUpdate = 1;   //等于１为修改数据
        }

        private void tlBtnSave_Click(object sender, EventArgs e)
        {
            //判断是添加还是修改数据
            if (G_Int_addOrUpdate == 0)
            {
                try
                {
                    //添加数据
                    HeaderDataInfo.id  = txtID.Text;
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
                    int id = baseinfo.AddHeaderData(HeaderDataInfo);
                    MessageBox.Show("新增--头部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                HeaderDataInfo.id = txtID.Text;
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
                //执行修改
                int id = baseinfo.UpdateHeaderData(HeaderDataInfo);
                MessageBox.Show("修改--头部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvHeaderDataList.DataSource = baseinfo.GetAllHeaderData("HeaderData").Tables[0].DefaultView;
            this.SetdgvHeaderDataListHeadText();
            this.cancelEnabled();
        }
        //查询头部数据
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbHeaderDataType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbHeaderDataType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindHeaderData.Text.Trim() == string.Empty)
                {
                    dgvHeaderDataList.DataSource = baseinfo.GetAllHeaderData("HeaderData").Tables[0].DefaultView;
                    this.SetdgvHeaderDataListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbHeaderDataType.Text == "ID")  //按编号查询
            {
                HeaderDataInfo.id = tlTxtFindHeaderData.Text;
                ds = baseinfo.FindHeaderDataByID(HeaderDataInfo, "HeaderData");
                dgvHeaderDataList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvHeaderDataListHeadText();
        }
        //设置DataGridView标题
        public void SetdgvHeaderDataListHeadText()
        {
            dgvHeaderDataList.Columns[0].HeaderText = "编号";
            dgvHeaderDataList.Columns[1].HeaderText = "头高";
            dgvHeaderDataList.Columns[2].HeaderText = "头宽";
            dgvHeaderDataList.Columns[3].HeaderText = "头长";
            dgvHeaderDataList.Columns[4].HeaderText = "头围";
            dgvHeaderDataList.Columns[5].HeaderText = "头冠状围";
            dgvHeaderDataList.Columns[6].HeaderText = "耳屏间弧";
            dgvHeaderDataList.Columns[7].HeaderText = "头矢状弧";
            dgvHeaderDataList.Columns[8].HeaderText = "眉间顶颈弧长";
            dgvHeaderDataList.Columns[9].HeaderText = "形态面长";
            dgvHeaderDataList.Columns[10].HeaderText = "瞳孔间距";

        }

        private void dgvHeaderDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = this.dgvHeaderDataList[0, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtHeadHeight.Text = this.dgvHeaderDataList[1, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtHeadWidth.Text = this.dgvHeaderDataList[2, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtHeadLength.Text = this.dgvHeaderDataList[3, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtHeadGirth.Text = this.dgvHeaderDataList[4, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtCrownShapeAround.Text = this.dgvHeaderDataList[5, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtBitragionIntertragicArc.Text = this.dgvHeaderDataList[6, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtHeadSagittalArc.Text = this.dgvHeaderDataList[7, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtBrowTopNeckArcLength.Text = this.dgvHeaderDataList[8, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtMorphoGicalFacialLength.Text = this.dgvHeaderDataList[9, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
            txtInterpupillaryDistance.Text = this.dgvHeaderDataList[10, dgvHeaderDataList.CurrentCell.RowIndex].Value.ToString();
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--头部数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HeaderDataInfo.id = txtID.Text;
            //执行删除
            int id = baseinfo.DeleteHeaderData(HeaderDataInfo);
            MessageBox.Show("删除--头部数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHeaderDataList.DataSource = baseinfo.GetAllHeaderData("HeaderData").Tables[0].DefaultView;
            this.SetdgvHeaderDataListHeadText();
            this.clearText();
        }
    }
}
