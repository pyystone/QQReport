using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pyystone;
using System.Threading;

namespace fatieTools
{
    public partial class login : Form
    {
        delegate void D(object obj);
        private IDictionary<string, baiduTools> userinfo = new Dictionary<string, baiduTools>();
        private bool flag = true;
        private bool pass = false;
        private string namestr;
        public login()
        {
            InitializeComponent();
        }

        private void btnshowsave_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Thread t = new Thread(fileload);
            t.IsBackground = true;
            t.Start();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void fileload()
        {
            D d = new D(update);
            StreamReader sr = FileLS.fileReader(openFileDialog1.FileName, "utf-8");
            while (!sr.EndOfStream)
            {
                string[] str = stringHelper.StringSplit(sr.ReadLine(), "----");
                if (namestr.IndexOf(str[0]) != -1)
                {
                    continue;
                }
                if (userinfo.ContainsKey(str[0]))
                {
                    continue;
                }
                userinfo.Add(str[0], new baiduTools(str[0], str[1]));
            }
            lblogin.Invoke(d, "已导入");
        }

        private void login_Load(object sender, EventArgs e)
        {
            FileLS.CreateFile("cookie");
            StreamReader sr = FileLS.fileReader("cookie\\namelist.pcl", "utf-8");
            namestr = sr.ReadToEnd();
            sr.Close();
        }

        private void update(object str)
        {
            string[] sss = stringHelper.StringSplit(lblogin.Text, "\r\n");
            if (sss.Length > 13)
            {
                lblogin.Text = "";
                for (int i = 1 ; i < 13 ; i ++) {
                    lblogin.Text += sss[i] + "\r\n";
                }
            }
            lblogin.Text += (string)str + "\r\n";
        }

        private void update2(object str)
        {
            txtAccount.Text = (string)str;
        }
        private void update3(object str)
        {
            tbVcode.Text = (string)str;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(loginstart);
            t.IsBackground = true;
            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(savestart);
            t.IsBackground = true;
            t.Start();
        }

        private void loginstart() {
            D d1 = new D(update);
            D d2 = new D(update2);
            D d3 = new D(update3);
            foreach (string username in userinfo.Keys)
            {
                txtAccount.Invoke(d2, username);
                baiduTools info = userinfo[username];
                while (true)
                {
                    if (pass == true)
                    {
                        lblogin.Invoke(d1, username + "登录跳过");
                        pass = false;
                        flag = true;
                        break;
                    }
                    if (flag == false)
                    {
                        Thread.Sleep(2000);
                        continue;
                    }
                    if (tbVcode.Text != "") {
                        info.info.vcode = tbVcode.Text;
                        tbVcode.Invoke(d3, "");
                    }
                    lblogin.Invoke(d1, username + "登录中");
                    baiduTools.BdResult result = null;
                    try
                    {
                        result = info.login();
                    }
                    catch (Exception e)
                    {
                        lblogin.Invoke(d1, "error:" + e.ToString());
                    }
                    if (result == null) {
                        continue;
                    }
                    if (result.errorcode.Equals("0"))
                    {
                        lblogin.Invoke(d1, username + "登录成功");
                        break;
                    }
                    else
                    {
                        flag = false;
                        lblogin.Invoke(d1, "失败！错误码:" + baiduTools.getReason(result.errorcode));
                    }
                    if (result.vcode != null)
                    {
                        pbCode.Image = result.vcode;
                    }
                }
            }
            lblogin.Invoke(d1, "登录结束");
        }

        private void savestart() {
            D d = new D(update);
            lblogin.Invoke(d, "保存中！");
            FileLS.CreateFile("cookie");
            StreamWriter fw = FileLS.FileWrite("cookie\\namelist.pcl", "utf-8", true);
            foreach (string key in userinfo.Keys)
            {
                if (key == null)
                {
                    break;
                }
                if (userinfo[key].info.cookie.Count <10) {
                    continue;
                }
                fw.WriteLine(userinfo[key].info.username);
                string name = "cookie\\" + userinfo[key].info.username + ".pck";
                HtmlTools.WriteCookiesToDisk(name, userinfo[key].info.cookie);
            }
            fw.Close();
            lblogin.Invoke(d, "保存结束！");
        }

        private void tbVcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                flag = true;
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pass = true;
        }
    }
}
