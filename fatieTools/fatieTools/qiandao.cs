using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pyystone;
using System.IO;
using System.Threading;

namespace fatieTools
{
    public partial class qiandao : Form
    {
        delegate void D(object obj);
        private baiduTools[] mBDT;
        public qiandao()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            D d = new D(updata);
            lbStatus.Invoke(d, "导入中！");
            int i = 0;
            StreamReader sr = FileLS.fileReader("cookie\\namelist.pcl", "UTF-8");
            while (!sr.EndOfStream)
            {
                if (mBDT[i] == null)
                {
                    mBDT[i] = new baiduTools();
                }
                String name = sr.ReadLine();
                mBDT[i].info = new baiduTools.UserInfo(name, "", HtmlTools.ReadCookiesFromDisk("cookie\\" + name + ".pck"));
                i++;
                namelist.Items.Add(name);
            }
            sr.Close();
            lbStatus.Invoke(d, "导入结束！");
        }

        //更新用于调试代码
        private void updata(object obj)
        {
            if (obj == null)
            {
                return;
            }
            if (((string)obj).Equals("“clear”"))
            {
                lbStatus.Text = "";
                return;
            }
            lbStatus.Text += obj.ToString() + "\r\n";
        }

        private void updatalist(object obj) {
            if (obj == null)
            {
                return;
            }
            if (((string)obj).Equals("“clear”"))
            {
                lbtblist.Items.Clear();
                return;
            }
            lbtblist.Items.Add((string)obj);
        }

        private void udNamelist(object obj)
        {
            if (obj == null)
            {
                return;
            }
            namelist.SetSelected((int)obj,true);
        }

        private void qiandao_Load(object sender, EventArgs e)
        {
            mBDT = new baiduTools[1000];
            baiduTools.mLog = lbStatus;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(startSign);
            t.IsBackground = true;
            t.Start();
        }

        private void startSign()
        {
            D d = new D(updata);
            D d2 = new D(updatalist);
            D d3 = new D(udNamelist);
            for (int i = 0; i < mBDT.Length; i++)
            {
                lbtblist.Invoke(d2, "“clear”");
                lbStatus.Invoke(d, "“clear”");
                if (mBDT[i] == null)
                {
                    break;
                }
                string[] mtblist = mBDT[i].getTbList();
                foreach(string str in mtblist) {
                    lbtblist.Invoke(d2, str);
                }
                namelist.Invoke(d3, i);
                mBDT[i].startTbSign();
            }
            lbStatus.Invoke(d, "“clear”");
            lbStatus.Invoke(d, "签到结束");
            for (int i = 0; i < mBDT.Length; i++)
            {
                if (mBDT[i] == null)
                {
                    break;
                }
                for (int j = 0; j < mBDT[i].signdata.Count; j++)
                {
                    if (mBDT[i].signdata[j].tbSign == false)
                    {
                        lbStatus.Invoke(d, mBDT[i].info.username + " " + mBDT[i].signdata[j].tbName + "签到失败");
                    }
                }
            }
        }
    }
}
