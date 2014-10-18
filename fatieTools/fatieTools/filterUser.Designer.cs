namespace fatieTools
{
    partial class filterUser
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
            this.button1 = new System.Windows.Forms.Button();
            this.namelist = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.cbTime = new System.Windows.Forms.CheckBox();
            this.cbTieba = new System.Windows.Forms.CheckBox();
            this.tbTieba = new System.Windows.Forms.TextBox();
            this.tblog = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbNum = new System.Windows.Forms.Label();
            this.tbFNum = new System.Windows.Forms.TextBox();
            this.cbFNum = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "导入账号列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // namelist
            // 
            this.namelist.FormattingEnabled = true;
            this.namelist.ItemHeight = 15;
            this.namelist.Location = new System.Drawing.Point(34, 68);
            this.namelist.Name = "namelist";
            this.namelist.Size = new System.Drawing.Size(230, 394);
            this.namelist.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(415, 68);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(152, 25);
            this.tbTime.TabIndex = 3;
            this.tbTime.Text = "2014-08-01 00:00";
            // 
            // cbTime
            // 
            this.cbTime.AutoSize = true;
            this.cbTime.Location = new System.Drawing.Point(290, 70);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(119, 19);
            this.cbTime.TabIndex = 4;
            this.cbTime.Text = "发帖时间限制";
            this.cbTime.UseVisualStyleBackColor = true;
            // 
            // cbTieba
            // 
            this.cbTieba.AutoSize = true;
            this.cbTieba.Location = new System.Drawing.Point(290, 123);
            this.cbTieba.Name = "cbTieba";
            this.cbTieba.Size = new System.Drawing.Size(89, 19);
            this.cbTieba.TabIndex = 5;
            this.cbTieba.Text = "贴吧限制";
            this.cbTieba.UseVisualStyleBackColor = true;
            // 
            // tbTieba
            // 
            this.tbTieba.Location = new System.Drawing.Point(415, 121);
            this.tbTieba.Name = "tbTieba";
            this.tbTieba.Size = new System.Drawing.Size(152, 25);
            this.tbTieba.TabIndex = 3;
            this.tbTieba.Text = "立华奏";
            // 
            // tblog
            // 
            this.tblog.Location = new System.Drawing.Point(623, 35);
            this.tblog.Multiline = true;
            this.tblog.Name = "tblog";
            this.tblog.Size = new System.Drawing.Size(221, 427);
            this.tblog.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "开始筛选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Location = new System.Drawing.Point(415, 37);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(0, 15);
            this.lbNum.TabIndex = 8;
            // 
            // tbFNum
            // 
            this.tbFNum.Location = new System.Drawing.Point(488, 175);
            this.tbFNum.Name = "tbFNum";
            this.tbFNum.Size = new System.Drawing.Size(79, 25);
            this.tbFNum.TabIndex = 3;
            this.tbFNum.Text = "5";
            // 
            // cbFNum
            // 
            this.cbFNum.AutoSize = true;
            this.cbFNum.Location = new System.Drawing.Point(290, 177);
            this.cbFNum.Name = "cbFNum";
            this.cbFNum.Size = new System.Drawing.Size(149, 19);
            this.cbFNum.TabIndex = 5;
            this.cbFNum.Text = "置顶贴吧发帖限制";
            this.cbFNum.UseVisualStyleBackColor = true;
            // 
            // filterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 488);
            this.Controls.Add(this.lbNum);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tblog);
            this.Controls.Add(this.cbFNum);
            this.Controls.Add(this.cbTieba);
            this.Controls.Add(this.tbFNum);
            this.Controls.Add(this.cbTime);
            this.Controls.Add(this.tbTieba);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.namelist);
            this.Controls.Add(this.button1);
            this.Name = "filterUser";
            this.Text = "filterUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.filterUser_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox namelist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.CheckBox cbTime;
        private System.Windows.Forms.CheckBox cbTieba;
        private System.Windows.Forms.TextBox tbTieba;
        private System.Windows.Forms.TextBox tblog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.TextBox tbFNum;
        private System.Windows.Forms.CheckBox cbFNum;
    }
}