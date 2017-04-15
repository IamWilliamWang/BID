namespace BID.SetSystem
{
    partial class frmClearTable
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUser = new System.Windows.Forms.CheckBox();
            this.chkOwner = new System.Windows.Forms.CheckBox();
            this.chkFootData = new System.Windows.Forms.CheckBox();
            this.chkTrunkIntegralData = new System.Windows.Forms.CheckBox();
            this.chkLowerLimbsData = new System.Windows.Forms.CheckBox();
            this.chkUpperLimbsData = new System.Windows.Forms.CheckBox();
            this.chkBellyWaistHipData = new System.Windows.Forms.CheckBox();
            this.chkChestData = new System.Windows.Forms.CheckBox();
            this.chkShoulderData = new System.Windows.Forms.CheckBox();
            this.chkNeckData = new System.Windows.Forms.CheckBox();
            this.chkHeaderData = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(1, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 155);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "                                        \r\n　　　注意：系统数据清理，将清理\r\n　　　　　　　　　　　　　　　　　　系统所" +
    "有的数据以及帐本数据都\r\n　　　　　　　　　　　　　　　　　　不存在，在系统清理磁盘前，请\r\n　　　　　　　　　　　　　　　　　　作好备份工作，否则造成大量数\r" +
    "\n　　　　　　　　　　　　　　　　　　据丢失带来不必要的损失。";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUser);
            this.groupBox1.Controls.Add(this.chkOwner);
            this.groupBox1.Controls.Add(this.chkFootData);
            this.groupBox1.Controls.Add(this.chkTrunkIntegralData);
            this.groupBox1.Controls.Add(this.chkLowerLimbsData);
            this.groupBox1.Controls.Add(this.chkUpperLimbsData);
            this.groupBox1.Controls.Add(this.chkBellyWaistHipData);
            this.groupBox1.Controls.Add(this.chkChestData);
            this.groupBox1.Controls.Add(this.chkShoulderData);
            this.groupBox1.Controls.Add(this.chkNeckData);
            this.groupBox1.Controls.Add(this.chkHeaderData);
            this.groupBox1.Location = new System.Drawing.Point(223, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // chkUser
            // 
            this.chkUser.AutoSize = true;
            this.chkUser.ForeColor = System.Drawing.Color.Blue;
            this.chkUser.Location = new System.Drawing.Point(10, 109);
            this.chkUser.Name = "chkUser";
            this.chkUser.Size = new System.Drawing.Size(84, 16);
            this.chkUser.TabIndex = 1;
            this.chkUser.Text = "用户信息表";
            this.chkUser.UseVisualStyleBackColor = true;
            // 
            // chkOwner
            // 
            this.chkOwner.AutoSize = true;
            this.chkOwner.Checked = true;
            this.chkOwner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOwner.Enabled = false;
            this.chkOwner.ForeColor = System.Drawing.Color.Red;
            this.chkOwner.Location = new System.Drawing.Point(119, 91);
            this.chkOwner.Name = "chkOwner";
            this.chkOwner.Size = new System.Drawing.Size(120, 16);
            this.chkOwner.TabIndex = 0;
            this.chkOwner.Text = "被测人基本信息表";
            this.chkOwner.UseVisualStyleBackColor = true;
            // 
            // chkFootData
            // 
            this.chkFootData.AutoSize = true;
            this.chkFootData.Checked = true;
            this.chkFootData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFootData.Enabled = false;
            this.chkFootData.ForeColor = System.Drawing.Color.Red;
            this.chkFootData.Location = new System.Drawing.Point(119, 72);
            this.chkFootData.Name = "chkFootData";
            this.chkFootData.Size = new System.Drawing.Size(84, 16);
            this.chkFootData.TabIndex = 0;
            this.chkFootData.Text = "足部数据表";
            this.chkFootData.UseVisualStyleBackColor = true;
            // 
            // chkTrunkIntegralData
            // 
            this.chkTrunkIntegralData.AutoSize = true;
            this.chkTrunkIntegralData.Checked = true;
            this.chkTrunkIntegralData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrunkIntegralData.Enabled = false;
            this.chkTrunkIntegralData.ForeColor = System.Drawing.Color.Red;
            this.chkTrunkIntegralData.Location = new System.Drawing.Point(119, 53);
            this.chkTrunkIntegralData.Name = "chkTrunkIntegralData";
            this.chkTrunkIntegralData.Size = new System.Drawing.Size(84, 16);
            this.chkTrunkIntegralData.TabIndex = 0;
            this.chkTrunkIntegralData.Text = "躯干数据表";
            this.chkTrunkIntegralData.UseVisualStyleBackColor = true;
            // 
            // chkLowerLimbsData
            // 
            this.chkLowerLimbsData.AutoSize = true;
            this.chkLowerLimbsData.Checked = true;
            this.chkLowerLimbsData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLowerLimbsData.Enabled = false;
            this.chkLowerLimbsData.ForeColor = System.Drawing.Color.Red;
            this.chkLowerLimbsData.Location = new System.Drawing.Point(119, 34);
            this.chkLowerLimbsData.Name = "chkLowerLimbsData";
            this.chkLowerLimbsData.Size = new System.Drawing.Size(84, 16);
            this.chkLowerLimbsData.TabIndex = 0;
            this.chkLowerLimbsData.Text = "下肢数据表";
            this.chkLowerLimbsData.UseVisualStyleBackColor = true;
            // 
            // chkUpperLimbsData
            // 
            this.chkUpperLimbsData.AutoSize = true;
            this.chkUpperLimbsData.Checked = true;
            this.chkUpperLimbsData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpperLimbsData.Enabled = false;
            this.chkUpperLimbsData.ForeColor = System.Drawing.Color.Red;
            this.chkUpperLimbsData.Location = new System.Drawing.Point(119, 15);
            this.chkUpperLimbsData.Name = "chkUpperLimbsData";
            this.chkUpperLimbsData.Size = new System.Drawing.Size(84, 16);
            this.chkUpperLimbsData.TabIndex = 0;
            this.chkUpperLimbsData.Text = "上肢数据表";
            this.chkUpperLimbsData.UseVisualStyleBackColor = true;
            // 
            // chkBellyWaistHipData
            // 
            this.chkBellyWaistHipData.AutoSize = true;
            this.chkBellyWaistHipData.Checked = true;
            this.chkBellyWaistHipData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBellyWaistHipData.Enabled = false;
            this.chkBellyWaistHipData.ForeColor = System.Drawing.Color.Red;
            this.chkBellyWaistHipData.Location = new System.Drawing.Point(10, 91);
            this.chkBellyWaistHipData.Name = "chkBellyWaistHipData";
            this.chkBellyWaistHipData.Size = new System.Drawing.Size(108, 16);
            this.chkBellyWaistHipData.TabIndex = 0;
            this.chkBellyWaistHipData.Text = "腹腰臀部数据表";
            this.chkBellyWaistHipData.UseVisualStyleBackColor = true;
            // 
            // chkChestData
            // 
            this.chkChestData.AutoSize = true;
            this.chkChestData.Checked = true;
            this.chkChestData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChestData.Enabled = false;
            this.chkChestData.ForeColor = System.Drawing.Color.Red;
            this.chkChestData.Location = new System.Drawing.Point(10, 72);
            this.chkChestData.Name = "chkChestData";
            this.chkChestData.Size = new System.Drawing.Size(84, 16);
            this.chkChestData.TabIndex = 0;
            this.chkChestData.Text = "胸部数据表";
            this.chkChestData.UseVisualStyleBackColor = true;
            // 
            // chkShoulderData
            // 
            this.chkShoulderData.AutoSize = true;
            this.chkShoulderData.Checked = true;
            this.chkShoulderData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShoulderData.Enabled = false;
            this.chkShoulderData.ForeColor = System.Drawing.Color.Red;
            this.chkShoulderData.Location = new System.Drawing.Point(10, 53);
            this.chkShoulderData.Name = "chkShoulderData";
            this.chkShoulderData.Size = new System.Drawing.Size(84, 16);
            this.chkShoulderData.TabIndex = 0;
            this.chkShoulderData.Text = "肩部数据表";
            this.chkShoulderData.UseVisualStyleBackColor = true;
            // 
            // chkNeckData
            // 
            this.chkNeckData.AutoSize = true;
            this.chkNeckData.Checked = true;
            this.chkNeckData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNeckData.Enabled = false;
            this.chkNeckData.ForeColor = System.Drawing.Color.Red;
            this.chkNeckData.Location = new System.Drawing.Point(10, 34);
            this.chkNeckData.Name = "chkNeckData";
            this.chkNeckData.Size = new System.Drawing.Size(84, 16);
            this.chkNeckData.TabIndex = 0;
            this.chkNeckData.Text = "颈部数据表";
            this.chkNeckData.UseVisualStyleBackColor = true;
            // 
            // chkHeaderData
            // 
            this.chkHeaderData.AutoSize = true;
            this.chkHeaderData.Checked = true;
            this.chkHeaderData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHeaderData.Enabled = false;
            this.chkHeaderData.ForeColor = System.Drawing.Color.Red;
            this.chkHeaderData.Location = new System.Drawing.Point(10, 15);
            this.chkHeaderData.Name = "chkHeaderData";
            this.chkHeaderData.Size = new System.Drawing.Size(84, 16);
            this.chkHeaderData.TabIndex = 0;
            this.chkHeaderData.Text = "头部数据表";
            this.chkHeaderData.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(342, 139);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(246, 139);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清理";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmClearTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 171);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmClearTable";
            this.Text = "系统数据清理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOwner;
        private System.Windows.Forms.CheckBox chkFootData;
        private System.Windows.Forms.CheckBox chkTrunkIntegralData;
        private System.Windows.Forms.CheckBox chkLowerLimbsData;
        private System.Windows.Forms.CheckBox chkUpperLimbsData;
        private System.Windows.Forms.CheckBox chkBellyWaistHipData;
        private System.Windows.Forms.CheckBox chkChestData;
        private System.Windows.Forms.CheckBox chkShoulderData;
        private System.Windows.Forms.CheckBox chkNeckData;
        private System.Windows.Forms.CheckBox chkHeaderData;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkUser;
    }
}