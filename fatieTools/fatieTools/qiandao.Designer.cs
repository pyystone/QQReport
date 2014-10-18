namespace fatieTools
{
    partial class qiandao
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.namelist = new System.Windows.Forms.ListBox();
            this.lbStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbtblist = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 43);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "导入";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(131, 43);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 1;
            this.btnSign.Text = "开始签到";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // namelist
            // 
            this.namelist.FormattingEnabled = true;
            this.namelist.ItemHeight = 15;
            this.namelist.Location = new System.Drawing.Point(28, 101);
            this.namelist.Name = "namelist";
            this.namelist.Size = new System.Drawing.Size(247, 364);
            this.namelist.TabIndex = 2;
            // 
            // lbStatus
            // 
            this.lbStatus.Location = new System.Drawing.Point(559, 101);
            this.lbStatus.Multiline = true;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lbStatus.Size = new System.Drawing.Size(244, 364);
            this.lbStatus.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "账号列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "关注贴吧列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "动态";
            // 
            // lbtblist
            // 
            this.lbtblist.FormattingEnabled = true;
            this.lbtblist.HorizontalScrollbar = true;
            this.lbtblist.ItemHeight = 15;
            this.lbtblist.Location = new System.Drawing.Point(296, 101);
            this.lbtblist.Name = "lbtblist";
            this.lbtblist.ScrollAlwaysVisible = true;
            this.lbtblist.Size = new System.Drawing.Size(247, 364);
            this.lbtblist.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // qiandao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 539);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbtblist);
            this.Controls.Add(this.namelist);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnSave);
            this.Name = "qiandao";
            this.Text = "qiandao";
            this.Load += new System.EventHandler(this.qiandao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.ListBox namelist;
        private System.Windows.Forms.TextBox lbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbtblist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}