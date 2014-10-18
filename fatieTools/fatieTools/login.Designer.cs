namespace fatieTools
{
    partial class login
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
            this.tbVcode = new System.Windows.Forms.TextBox();
            this.pbCode = new System.Windows.Forms.PictureBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.btnload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblogin = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tbVcode
            // 
            this.tbVcode.Location = new System.Drawing.Point(120, 198);
            this.tbVcode.Name = "tbVcode";
            this.tbVcode.Size = new System.Drawing.Size(161, 25);
            this.tbVcode.TabIndex = 14;
            this.tbVcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVcode_KeyPress);
            // 
            // pbCode
            // 
            this.pbCode.Location = new System.Drawing.Point(120, 111);
            this.pbCode.Name = "pbCode";
            this.pbCode.Size = new System.Drawing.Size(161, 62);
            this.pbCode.TabIndex = 13;
            this.pbCode.TabStop = false;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(120, 66);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(161, 25);
            this.txtAccount.TabIndex = 11;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(120, 27);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(161, 23);
            this.submit.TabIndex = 10;
            this.submit.Text = "开始";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(25, 27);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 23);
            this.btnload.TabIndex = 16;
            this.btnload.Text = "导入";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "正在登录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "验证码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "输入验证码";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "再次登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(192, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblogin
            // 
            this.lblogin.Location = new System.Drawing.Point(287, 28);
            this.lblogin.Multiline = true;
            this.lblogin.Name = "lblogin";
            this.lblogin.Size = new System.Drawing.Size(238, 245);
            this.lblogin.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 24);
            this.button2.TabIndex = 23;
            this.button2.Text = "跳过";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 286);
            this.Controls.Add(this.lblogin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.tbVcode);
            this.Controls.Add(this.pbCode);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.submit);
            this.Name = "login";
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbVcode;
        private System.Windows.Forms.PictureBox pbCode;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox lblogin;
        private System.Windows.Forms.Button button2;
    }
}