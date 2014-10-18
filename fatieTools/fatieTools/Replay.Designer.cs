namespace fatieTools
{
    partial class Replay
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
            this.accList = new System.Windows.Forms.ListBox();
            this.nameList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbtid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcontent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.lbStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbtime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // accList
            // 
            this.accList.FormattingEnabled = true;
            this.accList.ItemHeight = 15;
            this.accList.Location = new System.Drawing.Point(38, 64);
            this.accList.Name = "accList";
            this.accList.Size = new System.Drawing.Size(204, 394);
            this.accList.TabIndex = 1;
            // 
            // nameList
            // 
            this.nameList.FormattingEnabled = true;
            this.nameList.ItemHeight = 15;
            this.nameList.Location = new System.Drawing.Point(248, 64);
            this.nameList.Name = "nameList";
            this.nameList.Size = new System.Drawing.Size(203, 394);
            this.nameList.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "导入召唤名单";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbtid
            // 
            this.tbtid.Location = new System.Drawing.Point(498, 35);
            this.tbtid.Name = "tbtid";
            this.tbtid.Size = new System.Drawing.Size(100, 25);
            this.tbtid.TabIndex = 3;
            this.tbtid.Text = "3236546948";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "帖子id";
            // 
            // tbcontent
            // 
            this.tbcontent.Location = new System.Drawing.Point(528, 66);
            this.tbcontent.Multiline = true;
            this.tbcontent.Name = "tbcontent";
            this.tbcontent.Size = new System.Drawing.Size(210, 385);
            this.tbcontent.TabIndex = 5;
            this.tbcontent.Text = "2014年8月17日23:00-8月18日23:00的天炮战，小奏的骑士们希望您可以投给她支持的一票，我们期待您的参与。投票地址见主贴和2楼。如果您对此没有兴趣，" +
    "请无视这个召唤，非常抱歉打扰到您m(_ _)m[br][br]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "召唤内容";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(847, 34);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始召唤";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // lbStatus
            // 
            this.lbStatus.Location = new System.Drawing.Point(760, 66);
            this.lbStatus.Multiline = true;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(210, 385);
            this.lbStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "账号列表";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "召唤速度（毫秒）";
            // 
            // tbtime
            // 
            this.tbtime.Location = new System.Drawing.Point(741, 32);
            this.tbtime.Name = "tbtime";
            this.tbtime.Size = new System.Drawing.Size(100, 25);
            this.tbtime.TabIndex = 3;
            this.tbtime.Text = "1000";
            // 
            // Replay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 474);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.tbcontent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbtime);
            this.Controls.Add(this.tbtid);
            this.Controls.Add(this.nameList);
            this.Controls.Add(this.accList);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.button2);
            this.Name = "Replay";
            this.Text = "Replay";
            this.Load += new System.EventHandler(this.Replay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox accList;
        private System.Windows.Forms.ListBox nameList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbcontent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox lbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbtime;
    }
}