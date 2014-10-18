using pyystone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Threading;


namespace fatieTools
{
    
    public partial class Form1 : Form
    {
        private login loginform;
        private qiandao qiandaoform;
        private Replay replayform;
        private helpform helpform1;
        private filterUser filter;
        private int form_x ;
        private int form_y;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            form_x = this.Width/2;
            form_y = this.Height / 2;
            this.IsMdiContainer = true;
            System.Net.ServicePointManager.DefaultConnectionLimit = 100; // 预防超时异常 提高允许的http的数量
            loginform = new login();
            qiandaoform = new qiandao();
            replayform = new Replay();
            filter = new filterUser();
        }


        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 登录工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginform.Visible)
            {
                loginform.Focus();
                return;
            }
            else
            {
                loginform = new login();
                loginform.WindowState = FormWindowState.Maximized;
                loginform.MdiParent = this;
                //loginform.StartPosition = FormStartPosition.Manual;
                //loginform.Location = new Point(form_x - loginform.Width / 2, form_y - loginform.Height / 2);
                loginform.Show();
            }
        }

        private void 签到工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (qiandaoform.Visible)
            {
                qiandaoform.Focus();
                return;
            }
            else
            {
                qiandaoform = new qiandao();
                qiandaoform.WindowState = FormWindowState.Maximized;
                qiandaoform.MdiParent = this;
                //qiandaoform.StartPosition = FormStartPosition.Manual;
                //qiandaoform.Location = new Point(form_x - qiandaoform.Width / 2, form_y - qiandaoform.Height / 2);
                qiandaoform.Show();
            }
        }

        private void 发帖工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replayform.Visible)
            {
                replayform.Focus();
                return;
            }
            else
            {
                replayform = new Replay();
                replayform.MdiParent = this;
                replayform.WindowState = FormWindowState.Maximized;
                //replayform.StartPosition = FormStartPosition.Manual;
                //replayform.Location = new Point(form_x - replayform.Width / 2, form_y - replayform.Height / 2);
                replayform.Show();
            }
        }

        private void 介绍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (helpform1.Visible)
            //{
            //    helpform1.Focus();
            //    return;
            //}
            //else
            //{
            //    helpform1 = new helpform();
            //    helpform1.MdiParent = this;
            //    helpform1.WindowState = FormWindowState.Maximized;
            //    //replayform.StartPosition = FormStartPosition.Manual;
            //    //replayform.Location = new Point(form_x - replayform.Width / 2, form_y - replayform.Height / 2);
            //    helpform1.Show();
            //}
            helpform1 = new helpform();
            helpform1.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 工具列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 数据筛选工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filter.Visible)
            {
                filter.Focus();
                return;
            }
            else
            {
                filter = new filterUser();
                filter.MdiParent = this;
                filter.WindowState = FormWindowState.Maximized;
                filter.Show();
            }
        }

    }
}
