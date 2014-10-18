using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace pyystone
{
    class baiduTools
    {
        private static string mLoginUrl = "http://passport.baidu.com/v2/api/?login";
        private static string mHomeUrl = "http://tieba.baidu.com/home/main?ie=utf-8&un=";
        private static string mSignUrl = "http://tieba.baidu.com/sign/add";
        private static string mTbUrl = "http://tieba.baidu.com/f?ie=utf-8&kw=";
        public static IDictionary<string, tbData> mtbList = null;
        public static bool needupdatetbs = false;
        public static TextBox mLog = new TextBox();

        private bool mhaslogin;

        delegate void D(object obj);

        public class tbData
        {
            public string mtbs;
            public string mfid;
            public tbData(string tbs = "", string fid = "")
            {
                mtbs = tbs;
                mfid = fid;
            }
        }
        public class signData
        {
            public string tbName;
            public string tbTbs;
            public bool tbSign;

            public signData(string name = "", string tbs = "", string sign = "")
            {
                tbName = name;
                tbTbs = tbs;
                tbs = sign;
            }
        }

        public class TieData
        {
            public string tid = "";
            public string fid = "";
            public string tbs = "";
            public string kw = "";
        }

        public class UserInfo
        {
            public string username;
            public string password;
            public CookieContainer cookie;
            public string vcode;
            public string vcodeurl;
            public TieData tiedata;
            public UserInfo(string name, string pwd, CookieContainer cc = null, string url = "", string code = "")
            {
                username = name;
                if (cc == null)
                {
                    cc = new CookieContainer();
                }
                cookie = cc;
                vcodeurl = url;
                vcode = code;
                password = pwd;
                tiedata = new TieData();
            }
        }

        public class BdResult
        {
            public string errorcode;
            public Bitmap vcode;
            public BdResult(string error, Bitmap code = null)
            {
                errorcode = error;
                vcode = code;
            }
        }
        public UserInfo info;
        public List<signData> signdata;
        public string mtoken;

        public baiduTools(string name, string pwd, CookieContainer cc = null)
        {
            info = new UserInfo(name, pwd, cc);
            mhaslogin = false;
        }
        public baiduTools()
        {
            mhaslogin = false;
        }
        /// <summary>
        /// 用于回复消息
        /// post地址 http://tieba.baidu.com/f/commit/post/add
        /// 数据 files=%5B%5D&sign_id=57617638&game_user=false&mouse_pwd=46%2C45%2C35%2C52%2C43%2C35%2C35%2C35%2C34%2C43%2C44%2C34%2C35%2C46%2C47%2C41%2C43%2C54%2C43%2C47%2C42%2C47%2C52%2C47%2C35%2C35%2C35%2C45%2C47%2C47%2C34%2C47%2C35%2C41%2C45%2C47%2C19%2C43%2C54%2C42%2C54%2C43%2C54%2C42%2C54%2C43%2C54%2C42%2C54%2C43%2C54%2C42%2C54%2C43%2C54%2C42%2C19%2C35%2C42%2C47%2C35%2C45%2C19%2C43%2C47%2C41%2C44%2C54%2C34%2C44%2C46%2C14045434800260&ie=utf-8&&floor_num=1&rich_text=1&mouse_pwd_isclick=0&__type__=reply&kw=贴吧名&fid=贴吧id&tid=帖子id&vcode_md5=验证码&tbs=页面.tbs&content=发帖内容&mouse_pwd_t=时间戳
        /// add  cookies : activelevel=1;
        /// 
        /// 
        /// </summary>
        /// <param name="obj">TieData格式数据</param>

        public BdResult PostReply(string tid, string content)
        {
            while (info.tiedata.kw == "" || info.tiedata.tbs == "" || info.tiedata.fid == "")
            {
                getTieData(tid);
            }
            info.cookie = HtmlTools.changeDomain(info.cookie, "tieba.baidu.com");
            StringBuilder sb = new StringBuilder();
            string mouse_pwd_t = HtmlTools.getTime().ToString();
            sb.Append("files=%5B%5D&sign_id=57617638&floor_num=1&mouse_pwd=37%2C45%2C47%2C49%2C44%2C45%2C46%2C43%2C40%2C20%2C44%2C49%2C45%2C49%2C44%2C49%2C45%2C49%2C44%2C49%2C45%2C49%2C44%2C49%2C45%2C49%2C44%2C49%2C45%2C20%2C44%2C44%2C40%2C44%2C42%2C20%2C44%2C36%2C47%2C45%2C49%2C44%2C45%2C37%2C45%2C" + mouse_pwd_t + "0&mouse_pwd_t=" + mouse_pwd_t + "&ie=utf-8&rich_text=1&mouse_pwd_isclick=0&__type__=reply");
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("kw", info.tiedata.kw);
            parameters.Add("fid", info.tiedata.fid);
            parameters.Add("tid", tid);
            parameters.Add("vcode_md5", "");
            parameters.Add("tbs", info.tiedata.tbs);
            parameters.Add("content", content);
            string url = "http://tieba.baidu.com/f/commit/post/add";
            string errorcode = "";
            HttpWebResponse response = HtmlTools.httpPost(url, parameters, null, null, null, info.cookie, sb);
            string resstr = "";
            if (response == null)
            {
                return null;
            }
            if (response.ContentEncoding.IndexOf("gzip") != -1)
            {
                resstr = HtmlTools.gzipDecompress(response);
            }
            else
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                resstr = stream.ReadToEnd();
            }
            errorcode = HtmlTools.getStringByRex(resstr, "no\":([^,]*),", 1);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            if (errorcode == "0")
            {
                return new BdResult(errorcode);
            }
            else
            {
                string str = HtmlTools.getStringByRex(resstr,"str_reason\":\"[^\\\"]+",1);
                str = HtmlTools.getUnicodeUrlDecode(errorcode);
                errorcode += "\r\n" + str;
                return new BdResult(errorcode);
            }
            
        }

        public Bitmap getVoce()
        {
            info.cookie = HtmlTools.changeDomain(info.cookie, "passport.baidu.com");
            string imgurl = "https://passport.baidu.com/cgi-bin/genimage?" + info.vcodeurl
                            + "&v=" + HtmlTools.getTime();
            HttpWebResponse res = HtmlTools.httpGet(imgurl, null, null, info.cookie);
            Stream resStream = res.GetResponseStream();//得到验证码数据流
            return new Bitmap(resStream);//初始化Bitmap图片
        }


        ///post 地址 http://passport.baidu.com/v2/api/?login
        ///post 内容
        ///ppui_logintime=5位随机数&charset=utf-8&codestring=验证码地址&token=标示&isPhone=false&index=0&u=&safeflg=0&staticpage=http%3A%2F%2Fwww.baidu.com%2Fcache%2Fuser%2Fhtml%2Fjump.html&loginType=1&tpl=mn&callback=parent.bdPass.api.login._postCallback&username=用户名&password=密码&verifycode=验证码&mem_pass=on
        ///验证码图片地址
        ///https://passport.baidu.com/cgi-bin/genimage?验证码地址&v=时间戳
        ///验证码数据在 返回的正文里面 通过 codestring=([^&]*)& 来得到
        ///出现验证码的错误提示为257
        public BdResult login()
        {
            Console.WriteLine("开始登陆");
            //cookie init
            Cookie c = new Cookie("HOSUPPORT", "1");
            c.Domain = "passport.baidu.com";
            info.cookie.Add(c);
            info.cookie.Add(getBAIDUID());
            mtoken = getToken();
            info.cookie.Add(getUBI());

            //parmeters init
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ppui_logintime", HtmlTools.getRandomNum(5));
            parameters.Add("token", mtoken);
            parameters.Add("codestring", info.vcodeurl);
            parameters.Add("verifycode", info.vcode);
            parameters.Add("username", info.username);
            parameters.Add("password", info.password);

            //headers init
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Cache-Control", "no-cache");
            headers.Add("Referer", "http://www.baidu.com/cache/user/html/login-1.2.html");
            headers.Add("DNT", "1");

            StringBuilder sb = new StringBuilder();
            sb.Append("charset=utf-8&isPhone=false&index=0&u=&safeflg=0&staticpage=http%3A%2F%2Fwww.baidu.com%2Fcache%2Fuser%2Fhtml%2Fjump.html&loginType=1&tpl=mn&callback=parent.bdPass.api.login._postCallback&mem_pass=on");
            StreamReader sr;
            HttpWebResponse response;
            BdResult result = new BdResult("-1");
            response = HtmlTools.httpPost(mLoginUrl, parameters, null, headers, null, info.cookie, sb);
            CookieCollection cc = HtmlTools.getCookie(response, "passport.baidu.com");
            if (cc != null)
            {
                info.cookie.Add(cc);
            }
            if (response != null)
            {
                string resstr = "";
                if (response.ContentEncoding.IndexOf("gzip") != -1)
                {
                    resstr = HtmlTools.gzipDecompress(response);
                }
                else
                {
                    StreamReader stream = new StreamReader(response.GetResponseStream());
                    resstr = stream.ReadToEnd();
                }
                string errorcode = HtmlTools.getStringByRex(resstr, "error=([\\d]*)'", 1);
                result.errorcode = errorcode;
                if (errorcode.Equals("6") || errorcode.Equals("257"))
                {
                    info.vcodeurl = HtmlTools.getStringByRex(resstr, "codestring=([^&]*)&", 1);
                    result.vcode = getVoce();
                }
                else if (errorcode.Equals("0"))
                {
                    mhaslogin = true;
                    response = null;
                    while (response == null)
                    {
                        response = HtmlTools.httpGet("http://www.baidu.com", null, null, info.cookie);
                    }
                    StreamReader stream = new StreamReader(response.GetResponseStream());
                    string sstemp = stream.ReadToEnd();
                    info.username = HtmlTools.getStringByRex(sstemp,"bds.comm.user=\"([^\"]+)\";",1);
                }
                response.Close();
            }
            return result;
        }

        public string gettbs(string tbname)
        {
            info.cookie = HtmlTools.changeDomain(info.cookie, "tieba.baidu.com");
            HttpWebResponse response = HtmlTools.httpGet(mTbUrl + tbname, null, null, info.cookie);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return HtmlTools.getStringByRex(HtmlTools.Encoding_deal(sr.ReadToEnd()), "PageData.tbs = \"([^\"]+)", 1);
        }

        private CookieCollection getBAIDUID()
        {
            info.cookie = HtmlTools.changeDomain(info.cookie, ".baidu.com");
            HttpWebResponse response = null;
            while (response == null)
            {
                response = HtmlTools.httpGet("http://www.baidu.com", null, null, info.cookie);
            }
            CookieCollection cc = HtmlTools.getCookie(response, ".baidu.com");
            response.Close();
            return cc;
        }
        //https://passport.baidu.com/v2/api/?logincheck&callback=bdPass.api.login._needCodestringCheckCallback&tpl=mn&charset=UTF-8&index=0&username=123&isphone=false&time=1407169886792
        //需要 BAIDUID 和 HOSUPPORT = 1;(cookie)
        //登录需要这个参数
        private CookieCollection getUBI()
        {
            info.cookie = HtmlTools.changeDomain(info.cookie, ".baidu.com");
            //string url = "https://passport.baidu.com/v2/api/?loginhistory&tpl=mn&apiver=v3&callback=bd__cbs__7a93p6&tt=" + HtmlTools.getTime() + "token = " + mtoken;
            //string url = "https://passport.baidu.com/v2/api/?logincheck&token="+ mtoken+"&tpl=mn&apiver=v3&tt="+HtmlTools.getTime()+"&username="+info.username+"&isphone=false&callback=bd__cbs__cd0wh8";
            string url = "https://passport.baidu.com/v2/api/?logincheck&callback=bdPass.api.login._needCodestringCheckCallback&tpl=mn&charset=UTF-8&index=0&username="+info.username+"&isphone=false&time=" + HtmlTools.getTime();
            HttpWebResponse response = null;
            while (response == null)
            {
                response = HtmlTools.httpGet(url, null, null, info.cookie);
            }
            CookieCollection cc = HtmlTools.getCookie(response, "passport.baidu.com");
            response.Close();
            if (cc == null) {
                cc = new CookieCollection();
            }
            return cc;
        }

        //get方法
        //url格式：https://passport.baidu.com/v2/api/?getapi&tpl=pp&apiver=v3&tt=时间戳&class=login&logintype=basicLogin&callback=bd__cbs__wtthan
        //token 返回类型
        //刚开始请求访问的时候 cookie 需要有2个参数 
        //BAIDUID 和 HOSUPPORT
        //前者通过baidu.com 获取 后者默认1
        //bd__cbs__wtthan({"errInfo":{ "no": "0" }, "data": { "rememberedUserName" : "", "codeString" : "", "token" : "7671af3fa07850aa282f323d1ea06968", "cookie" : "1", "usernametype":"1", "spLogin" : "rate", "disable":"", "loginrecord":{ 'email':[ ], 'phone':[ ] } }})
        //不添加 domain 会在添加的时候报错，因为 cookiecontainer 支持多个站点的 cookie ，如果不指定domain的话就会出错
        private string getToken()
        {
            string url;
            string token;
            int times = 0;
            url = "https://passport.baidu.com/v2/api/?getapi&tpl=pp&apiver=v3&tt=" + HtmlTools.getTime() + "&class=login&logintype=basicLogin&callback=bd__cbs__wtthan";
            HttpWebResponse response = HtmlTools.httpGet(url, null, null, info.cookie);
            StreamReader sd = new StreamReader(response.GetResponseStream());
            token = HtmlTools.getStringByRex(sd.ReadToEnd(), "token\" : \"([^\"]*)", 1);
            times = 0;
            while (response == null && times < 3)
            {
                times++;
                response = HtmlTools.httpGet(url, null, null, info.cookie);
            }
            if (times == 3)
            {
                return null;
            }
            CookieCollection cc2 = HtmlTools.getCookie(response, "passport.baidu.com");
            if (cc2 != null)
            {
                info.cookie.Add(cc2);
            }
            response.Close();
            return token;
        }

        public static string getReason(string error)
        {
            switch (error)
            {
                case "257":
                    return "需要验证码";
                case "6":
                    return "验证码错误";
                case "2":
                    return "账号或密码错误";
                default:
                    return "未知错误:" + error.ToString();
            }
        }

        public string[] getTbList()
        {
            D d = new D(outLog);
            if (mtbList == null)
            {
                mLog.Invoke(d, "导入tbs信息");
                mtbList = gettabList();
                mLog.Invoke(d, "导入tbs信息成功！");
            }
            mLog.Invoke(d, "获取" + info.username + "的贴吧列表");
            if (signdata == null)
            {
                signdata = new List<signData>();
            }
            HttpWebResponse response = null;
            while (response == null)
            {
                response = HtmlTools.httpGet(mHomeUrl + HtmlTools.UrlEncode(info.username), null, null, info.cookie);
            }
            StreamReader stream = new StreamReader(response.GetResponseStream(),Encoding.GetEncoding("gbk"));
            //string str = HtmlTools.Encoding_deal(Encoding.Default.GetBytes(stream.ReadToEnd()));
            ////string str = HtmlTools.getEncodingString(stream.ReadToEnd(), "utf-8", "gb2312");
            string str = stream.ReadToEnd();

            rexData tbname = HtmlTools.getrexDataByRex(str, "forum_name\":\"([^\"]+)", 1);
            rexData sign = HtmlTools.getrexDataByRex(str, "is_sign\":([\\d]+)", 1);
            rexData fid = HtmlTools.getrexDataByRex(str, "forum_id\":([\\d]+)", 1);
            for (int i = 0; i < tbname.data.Count; i++)
            {
                if (fid.data[i] == "" || sign.data[i] == "")
                {
                    break;
                }
                signData data = new signData();
                data.tbName = HtmlTools.getUnicodeUrlDecode(tbname.data[i]);
                tbname.data[i] = data.tbName;
                data.tbSign = sign.data[i].Equals("1");
                if (signdata.Contains(data))
                {
                    break;
                }
                signdata.Add(data);
                if (mtbList.ContainsKey(data.tbName) == false)
                {
                    mtbList.Add(data.tbName, new tbData(gettbs(data.tbName), fid.data[i]));
                    needupdatetbs = true;
                }
            }
            mLog.Invoke(d, "获取结束");
            return tbname.data.ToArray();
        }

        /// <summary>
        /// ie:utf-8
        /// kw:贴吧名
        /// tbs:f0dfe191db6c25521407046983
        /// 请求地址 http://tieba.baidu.com/sign/add
        /// </summary>
        public void startTbSign()
        {
            D d = new D(outLog);

            if (mtbList == null)
            {
                mLog.Invoke(d, "导入tbs信息");
                mtbList = gettabList();
                mLog.Invoke(d, "导入tbs信息成功！");
            }
            for (int i = 0; i < signdata.Count; )
            {
                IDictionary<string, string> param = new Dictionary<string, string>();
                signData data = signdata[i];
                if (data.tbSign == true)
                {
                    mLog.Invoke(d, data.tbName + "已经签到");
                    i++;
                    continue;
                }
                HttpWebResponse response1 = HtmlTools.httpGet("http://tieba.baidu.com/f?kw=" + data.tbName , null,null , info.cookie, null);
                info.cookie.Add(HtmlTools.getCookie(response1,"tieba.baidu.com"));
                response1.Close();
                param.Add("ie", "utf-8");
                param.Add("kw", HtmlTools.UrlEncode(data.tbName));
                param.Add("tbs", mtbList[data.tbName].mtbs);
                info.cookie = HtmlTools.changeDomain(info.cookie, "tieba.baidu.com");
                HttpWebResponse response = HtmlTools.httpPost(mSignUrl, param, null, null, null, info.cookie, null);
                if (response != null)
                {
                    string resstr = "";
                    if (response.ContentEncoding.IndexOf("gzip") != -1)
                    {
                        resstr = HtmlTools.gzipDecompress(response);
                    }
                    else
                    {
                        StreamReader stream = new StreamReader(response.GetResponseStream());
                        resstr = stream.ReadToEnd();
                    }
                    string errorcode = HtmlTools.getStringByRex(resstr, "no\":([\\d]*)", 1);
                    if (errorcode.Equals("0") == true)
                    {
                        mLog.Invoke(d, data.tbName + "签到成功！");
                        i++;
                        data.tbSign = true;
                    }
                    else if (errorcode.Equals("2280002") == true)
                    {
                        mLog.Invoke(d, "账号被封" + data.tbName + "签到成功");
                        i++;
                        data.tbSign = true;
                    }
                    else if (errorcode.Equals("1101") == true)
                    {
                        mLog.Invoke(d,data.tbName + "已经签到!");
                        i ++;
                        data.tbSign = true;
                    }
                    else
                    {
                        mLog.Invoke(d, data.tbName + "签到失败，重试中！错误码:" + errorcode);
                    }
                }
                response.Close();
                Thread.Sleep(5 * 1000);
            }
            if (needupdatetbs)
            {
                save();
                needupdatetbs = false;
            }
        }

        private void outLog(Object obj)
        {
            if (mLog != null)
            {
                mLog.Text += (string)obj + "\r\n";
            }
        }


        private void save()
        {
            FileLS.CreateFile("cookie");
            StreamWriter fw = FileLS.FileWrite("cookie\\tabslist.psdata", "UTF-8");
            foreach (string key in mtbList.Keys)
            {
                if (key == null)
                {
                    continue; ;
                }
                if (mtbList[key].mtbs == "" || mtbList[key].mfid == "")
                {
                    continue;
                }
                fw.WriteLine(key + "----" + mtbList[key].mtbs + "----" + mtbList[key].mfid);
            }
            fw.Close();
        }
        private IDictionary<string, tbData> gettabList()
        {
            FileLS.CreateFile("cookie");
            IDictionary<string, tbData> data = new Dictionary<string, tbData>();
            StreamReader sr = FileLS.fileReader("cookie\\tabslist.psdata", "UTF-8");
            while (!sr.EndOfStream)
            {
                string[] str = stringHelper.StringSplit(sr.ReadLine(), "----");
                if (data.ContainsKey(str[0]))
                {
                    continue;
                }
                data.Add(str[0], new tbData(str[1], str[2]));
            }
            return data;
        }

        private void getTieData(string tid)
        {
            info.tiedata.tid = tid;
            string url = "http://tieba.baidu.com/p/";
            HttpWebResponse response = HtmlTools.httpGet(url + tid, null, null, info.cookie);
            StreamReader sr = new StreamReader(response.GetResponseStream(),Encoding.Default);
            string data = HtmlTools.Encoding_deal(Encoding.Default.GetBytes(sr.ReadToEnd()));
            info.tiedata.kw = HtmlTools.UrlEncode(HtmlTools.getStringByRex(data, "fname=\"([^\\\"]+)\"", 1));
            info.tiedata.fid = HtmlTools.getStringByRex(data, "fid:'([^']*)'", 1);
            info.tiedata.tbs = HtmlTools.getStringByRex(data, "tbs:'([^']*)'", 1);
            info.cookie.Add(HtmlTools.getCookie(response, "tieba.baidu.com"));
            response.Close();
        }
    }
}
