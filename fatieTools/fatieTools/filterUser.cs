using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using pyystone;
using System.IO;
using System.Threading;

namespace fatieTools
{
    public partial class filterUser : Form
    {
        delegate void D(object obj);
        private string namestr = "";
        private Thread[] t;
        private static int index;
        private static StreamWriter passsr ;
        private static StreamWriter filesr ;
        private string[] strlist;
        public filterUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            namelist.Items.Clear();
//            StreamReader sr ;
//            sr = FileLS.fileReader("pass.txt", "utf-8");
//            namestr += sr.ReadToEnd();
//            sr.Close();
//            sr = FileLS.fileReader("faile.txt", "utf-8");
//            namestr += sr.ReadToEnd();
            sr.Close();
            sr= FileLS.fileReader(openFileDialog1.FileName);
            string[] data = HtmlTools.getrexDataByRex(sr.ReadToEnd(), "(.*)\r\n", 1).data.ToArray();//stringHelper.StringSplit(sr.ReadToEnd(),"\r\n");
            List<string> list = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                if (!namestr.Contains(data[i]))
                {
                    namelist.Items.Add(data[i]);
                    list.Add(data[i]);
                }
            }
            strlist = list.ToArray();
            index = 0;
            namelist.SetSelected(index,true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            passsr = FileLS.FileWrite("pass.txt", "utf-8", true);
            filesr = FileLS.FileWrite("faile.txt", "utf-8", true);
            t = new Thread[20];
            for (int i = 0; i < 20; i++)
            {
                if (t[i] == null)
                {
                    t[i] = new Thread(filter);
                    t[i].Start();
                }
                Thread.Sleep(1000);
            }
        }

        private void filter()
        {
            D d = new D(uplog);
            D dn = new D(upNum);
            while (true)
            {
                lbNum.Invoke(dn, new object());
                string str = getnameitem();
                if (str == "")
                {
                    if (index >= namelist.Items.Count)
                    {
                        tblog.Invoke(d, "没有需要判断的账号了，线程退出");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                bool ispass = false;
                if (cbTime.Checked == true)
                {
                    ispass = baiduData.passByTime(str, tbTieba.Text.Trim(), tbTime.Text.Trim());
                }
                if (cbFNum.Checked == true)
                {
                    ispass = baiduData.passbyFNum(str, tbTieba.Text.Trim(), tbFNum.Text.Trim());
                }
                if (ispass)
                {
                    tblog.Invoke(d, str + "pass");
                    passsr.WriteLine(str);
                    passsr.Flush();
                }
                else
                {
                    tblog.Invoke(d, str + "fail");
                    filesr.WriteLine(str);
                    filesr.Flush();
                }
            }
        }

        private string getnameitem()
        {
            D d = new D(uplist);
            if (index >= namelist.Items.Count)
            {
                return "";
            }
            string name = strlist[index];
            namelist.Invoke(d,index++);
            return name;
        }

        private void uplog(object obj)
        {
            int maxnum = 20;
            string[] data = stringHelper.StringSplit(tblog.Text,"\r\n");
            if (data.Length > maxnum)
            {
                tblog.Text = "";
                for (int i = data.Length - maxnum - 1; i < data.Length; i++)
                {
                    tblog.Text += data[i] + "\r\n";
                }
            }
            tblog.Text += (string)obj + "\r\n";
        }

        private void uplist(object obj)
        {
            namelist.SetSelected((int)obj, true);
        }

        private void upNum(object obj)
        {
            lbNum.Text = index.ToString() + "//" + namelist.Items.Count.ToString();
        }

        private void filterUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            passsr.Close();
            filesr.Close();
        }
    }
}
