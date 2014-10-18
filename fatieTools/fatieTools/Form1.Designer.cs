namespace fatieTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.签到工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发帖工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.介绍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.筛选工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据筛选工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具列表ToolStripMenuItem,
            this.筛选工具ToolStripMenuItem,
            this.介绍ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具列表ToolStripMenuItem
            // 
            this.工具列表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录工具ToolStripMenuItem,
            this.签到工具ToolStripMenuItem,
            this.发帖工具ToolStripMenuItem});
            this.工具列表ToolStripMenuItem.Name = "工具列表ToolStripMenuItem";
            this.工具列表ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.工具列表ToolStripMenuItem.Text = "百度功能";
            this.工具列表ToolStripMenuItem.Click += new System.EventHandler(this.工具列表ToolStripMenuItem_Click);
            // 
            // 登录工具ToolStripMenuItem
            // 
            this.登录工具ToolStripMenuItem.Name = "登录工具ToolStripMenuItem";
            this.登录工具ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.登录工具ToolStripMenuItem.Text = "登录工具";
            this.登录工具ToolStripMenuItem.Click += new System.EventHandler(this.登录工具ToolStripMenuItem_Click);
            // 
            // 签到工具ToolStripMenuItem
            // 
            this.签到工具ToolStripMenuItem.Name = "签到工具ToolStripMenuItem";
            this.签到工具ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.签到工具ToolStripMenuItem.Text = "签到工具";
            this.签到工具ToolStripMenuItem.Click += new System.EventHandler(this.签到工具ToolStripMenuItem_Click);
            // 
            // 发帖工具ToolStripMenuItem
            // 
            this.发帖工具ToolStripMenuItem.Name = "发帖工具ToolStripMenuItem";
            this.发帖工具ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.发帖工具ToolStripMenuItem.Text = "发帖工具";
            this.发帖工具ToolStripMenuItem.Click += new System.EventHandler(this.发帖工具ToolStripMenuItem_Click);
            // 
            // 介绍ToolStripMenuItem
            // 
            this.介绍ToolStripMenuItem.Name = "介绍ToolStripMenuItem";
            this.介绍ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.介绍ToolStripMenuItem.Text = "介绍";
            this.介绍ToolStripMenuItem.Click += new System.EventHandler(this.介绍ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 筛选工具ToolStripMenuItem
            // 
            this.筛选工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据筛选工具ToolStripMenuItem});
            this.筛选工具ToolStripMenuItem.Name = "筛选工具ToolStripMenuItem";
            this.筛选工具ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.筛选工具ToolStripMenuItem.Text = "筛选工具";
            // 
            // 数据筛选工具ToolStripMenuItem
            // 
            this.数据筛选工具ToolStripMenuItem.Name = "数据筛选工具ToolStripMenuItem";
            this.数据筛选工具ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.数据筛选工具ToolStripMenuItem.Text = "数据筛选工具";
            this.数据筛选工具ToolStripMenuItem.Click += new System.EventHandler(this.数据筛选工具ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 539);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登录工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 签到工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发帖工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 介绍ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 筛选工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据筛选工具ToolStripMenuItem;
    }
}

