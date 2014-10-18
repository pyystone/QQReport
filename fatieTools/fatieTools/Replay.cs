using pyystone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace fatieTools
{
    public partial class Replay : Form
    {
        private baiduTools[] mBDT;
        private string nametxt;
        public delegate void D(object obj);
        public Replay()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void updata(object obj)
        {
            string[] sss = stringHelper.StringSplit(lbStatus.Text, "\r\n");
            if (sss.Length > 23)
            {
                lbStatus.Text = "";
                for (int i = 1; i < 23; i++)
                {
                    lbStatus.Text += sss[i] + "\r\n";
                }
            }
            lbStatus.Text += (string)obj + "\r\n";
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            nameList.Items.Clear();
            FileLS.CreateFile("result");
            StreamReader sr = FileLS.fileReader("result\\result.txt", "utf-8");
            nametxt = sr.ReadToEnd();
            sr.Close();
            D d = new D(updata);
            lbStatus.Invoke(d, "名单导入中！");
            sr = FileLS.fileReader(openFileDialog2.FileName, "UTF-8");
            while (!sr.EndOfStream)
            {
                String name = sr.ReadLine();
                if (nametxt.Contains(name))
                {
                    continue;
                }
                nameList.Items.Add(name);
            }
            sr.Close();
            lbStatus.Invoke(d, "导入结束！");
        }

        private void Replay_Load(object sender, EventArgs e)
        {
            accList.Items.Clear();
            mBDT = new baiduTools[500];
            D d = new D(updata);
            lbStatus.Invoke(d, "账号导入中！");
            int i = 0;
            StreamReader sr = FileLS.fileReader("cookie\\namelist.pcl", "UTF-8");
            while (!sr.EndOfStream)
            {
                String name = sr.ReadLine();
                if (mBDT[i] == null)
                {
                    mBDT[i] = new baiduTools();
                }
                mBDT[i].info = new baiduTools.UserInfo(name, "", HtmlTools.ReadCookiesFromDisk("cookie\\" + name + ".pck"));
                i++;
                accList.Items.Add(name);
            }
            sr.Close();
            lbStatus.Invoke(d, "导入结束！");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(startReplay);
            t.IsBackground = true;
            t.Start();
        }

        private void startReplay(object obj)
        {
            D d = new D(updata);
            D dname = new D(upnamelist);
            D dacc = new D(upacclist);
            string content = "";
            baiduTools.BdResult result;
            StreamWriter sw;
            int times = 0;
            for (int i = 0,j = 0; i < nameList.Items.Count;)
            {
                nameList.Invoke(dname, i);
                accList.Invoke(dacc, j % accList.Items.Count);
                content = tbcontent.Text;
                content += "\r\n";
                content += "@" + nameList.Items[i].ToString() + " \r\n";
                result = mBDT[j % accList.Items.Count].PostReply(tbtid.Text.Trim(), content);
                Thread.Sleep(Convert.ToInt32(tbtime.Text.Trim()));
                if (result == null)
                {
                    j++;
                    lbStatus.Invoke(d, "召唤失败，更换账号测试");
                    times++;
                }
                else if (result.errorcode == "0")
                {
                    lbStatus.Invoke(d, "召唤" + nameList.Items[i].ToString() + "成功");
                    sw = FileLS.FileWrite("result\\result.txt", "utf-8", true);
                    sw.WriteLine(nameList.Items[i].ToString());
                    sw.Close();
                    i++;
                    j++;
                    times = 0;
                }
                else
                {
                    if (result.errorcode == "40")
                    {
                        lbStatus.Invoke(d, "需要验证码");
                    }
                    else
                    {
                        lbStatus.Invoke(d, "发帖失败：错误信息：" + result.errorcode);
                    }
                    if (times > 3)
                    {
                        lbStatus.Invoke(d, "失败次数过多，线程终止10秒");
                        Thread.Sleep(10 * 1000);
                        times = 0;
                    }
                    j++;
                    lbStatus.Invoke(d, "召唤失败，更换账号测试");
                    times++;
                }
            }
        }
        private void upnamelist(object obj)
        {
            int i = (int)obj;
            if (i >= 0 && i < nameList.Items.Count)
            {
                nameList.SetSelected(i, true);
            }
        }
        private void upacclist(object obj)
        {
            int i = (int)obj;
            if (i >= 0 && i < accList.Items.Count)
            {
                accList.SetSelected(i, true);
            }
        }
    }
}
