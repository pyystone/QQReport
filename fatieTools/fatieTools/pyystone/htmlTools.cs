using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Collections;
using System.Data;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace pyystone
{
    class rexData
    {
        public List<string> data;
        public rexData()
        {
            data = new List<string>();
        }
        ~rexData()
        {
            data = null;
        }
    }
    class HtmlTools
    {
        private static readonly string DefaultUserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.66 Safari/537.36 LBBROWSER";  
        static private WebClient init()//对 webclient进行初始化
        {
            WebClient MyWeb = new WebClient();
            MyWeb.Credentials = CredentialCache.DefaultCredentials;
            return MyWeb;
        }
        /// <summary>
        /// 获得网页源码，非动态
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static public string DownHtmlPage(string url)
        {
            string strWebData = string.Empty;
            if (url != null || url.Trim() != "")
            {
                WebClient myWebClient = new WebClient();
                myWebClient.Credentials = CredentialCache.DefaultCredentials;
                byte[] myDataBuffer = myWebClient.DownloadData(url);
                strWebData = Encoding_deal(myDataBuffer);
            }
            return strWebData;
        }
        /// <summary>
        /// 下载指定数据资源
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        static public bool DownHtmlFile(string url,string fileurl)
        {
            WebClient MyWeb = init();
            MyWeb.DownloadFile(url, fileurl);
            return true;
        }
        static public string Encoding_deal(string myDataBuffer)
        {
            return Encoding_deal(Encoding.Default.GetBytes(myDataBuffer));
        }
        /// <summary>
        /// 编码处理
        /// </summary>
        /// <param name="strWebData"></param>
        /// <returns></returns>
        static public string Encoding_deal(byte[] myDataBuffer)
        {
            string strWebData = Encoding.Default.GetString(myDataBuffer);
            string charSet = "";
            Match charSetMatch = Regex.Match(strWebData, "<meta([^<]*)charset=\"([^<\\\"]*)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string webCharSet = charSetMatch.Groups[2].Value;
            if (charSet == null || charSet == "")
            {
                //如果未获取到编码，则设置默认编码
                if (webCharSet == null || webCharSet == "")
                {
                    charSet = "UTF-8";
                }
                else if (webCharSet == "gbk")
                {
                    charSet = "gb2312";
                }
                else 
                {
                    charSet = webCharSet;
                }
            }
            if (charSet[0] == '\"')
            {
                charSet = charSet.Substring(1, charSet.Length - 1);
            }
            if (charSet != null && charSet != "" )
            {
                strWebData = Encoding.GetEncoding(charSet).GetString(myDataBuffer);
            }
            return strWebData;
        }

        public static HttpWebRequest httpPostrequest(string url, IDictionary<string, string> parameters, int? timeout, IDictionary<string, string> headers, Encoding requestEncoding, CookieCollection cookies, StringBuilder buffer = null, WebProxy proxy = null, string refererurl = "")
        {
            CookieContainer cc = new CookieContainer();
            cc.Add(cookies);
            return httpPostrequest(url, parameters, timeout, headers, requestEncoding, cc, buffer, proxy, refererurl);
        }

        public static HttpWebRequest httpPostrequest(string url, IDictionary<string, string> parameters, int? timeout, IDictionary<string, string> headers, Encoding requestEncoding, CookieContainer cookies, StringBuilder buffer = null, WebProxy proxy = null, string refererurl = "")
        {
            if (String.IsNullOrEmpty(url))
            {
                MessageBox.Show("url 为空");
                return null;
            }
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            if (proxy != null)
            {
                request.UseDefaultCredentials = true;
                request.Proxy = proxy;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("Accept-Language", "zh-cn");
            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.UserAgent = DefaultUserAgent;
            if (refererurl != "")
            {
                request.Referer = refererurl;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            else
            {
                request.Timeout = 10000;
            }
            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    switch (key)
                    {
                        case "Referer":
                            request.Referer = headers[key];
                            break;
                        case "":
                            break;
                        default:
                            request.Headers.Add(key, headers[key]);
                            break;
                    }
                }
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer = cookies;
            }
            if (!(parameters == null || parameters.Count == 0))
            {
                int i = 1;
                if (buffer == null)
                {
                    buffer = new StringBuilder();
                    i = 0;
                }
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                if (requestEncoding == null)
                {
                    requestEncoding = Encoding.UTF8; ;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                //byte[] data = Encoding.Default.GetBytes(buffer.ToString());
                System.GC.Collect();
                try
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return request;
        }
        public static HttpWebResponse httpPost(string url, IDictionary<string, string> parameters, int? timeout, IDictionary<string, string> headers, Encoding requestEncoding, CookieCollection cookies, StringBuilder buffer = null, WebProxy proxy = null, string refererurl = "")
        {
            CookieContainer cc = new CookieContainer();
            cc.Add(cookies);
            return httpPost(url,parameters,timeout,headers,requestEncoding,cc,buffer,proxy,refererurl);
        }
        //网页post消息
        public static HttpWebResponse httpPost(string url, IDictionary<string, string> parameters, int? timeout, IDictionary<string, string> headers, Encoding requestEncoding, CookieContainer cookies, StringBuilder buffer = null, WebProxy proxy = null, string refererurl = "")
        {
            try
            {
                return httpPostrequest(url,parameters,timeout,headers,requestEncoding,cookies,buffer,proxy).GetResponse() as HttpWebResponse;
                
            }
            catch (Exception eex)
            {
                return null;
            }
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        public static HttpWebResponse httpGet(string url, int? timeout, IDictionary<string, string> headers, CookieCollection cookies, WebProxy proxy = null)
        {
            CookieContainer cc = new CookieContainer();
            if (cookies != null)
            {
                cc.Add(cookies);
            }
            return httpGet(url, timeout, headers, cc, proxy);
            
        }
        public static HttpWebRequest httpGetrequest(string url, int? timeout, IDictionary<string, string> headers, CookieCollection cookies, WebProxy proxy = null)
        {

            CookieContainer cc = new CookieContainer();
            if (cookies != null)
            {
                cc.Add(cookies);
            }
            return httpGetrequest(url, timeout, headers, cc, proxy);
        }
        public static HttpWebRequest httpGetrequest(string url, int? timeout, IDictionary<string, string> headers, CookieContainer cookies, WebProxy proxy = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            if (proxy != null)
            {
                request.UseDefaultCredentials = true;
                request.Proxy = proxy;
            }
            request.Method = "GET";

            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    switch (key)
                    {
                        case "Referer":
                            request.Referer = headers[key];
                            break;
                        default:
                            request.Headers.Add(key, headers[key]);
                            break;
                    }

                }
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer = cookies;
            }
            return request;
        }

        public static HttpWebResponse httpGet(string url, int? timeout, IDictionary<string, string> headers, CookieContainer cookies, WebProxy proxy = null)
        {
            try
            {
                HttpWebResponse response = httpGetrequest(url,timeout,headers,cookies,proxy).GetResponse() as HttpWebResponse;
                return response;
            }
            catch (Exception eex)
            {
                Console.WriteLine(eex.ToString());
                return null;
            }

        }
        //获得时间戳
        public static long getTime() {
            System.DateTime time = DateTime.Now;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //intResult = (time- startTime).TotalMilliseconds;
            long t = (time.Ticks - startTime.Ticks) / 10000;            //除10000调整为13位
            return t;
        }
        public static List<rexData> getStringByRex(string txt, string rex, int[] index)
        {
            List<rexData> res = new List<rexData>();
            rexData result = new rexData();
            Match charSetMatch = Regex.Match(txt, rex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            while (charSetMatch.Success)
            {
                foreach (int i in index)
                {
                    result.data.Add(charSetMatch.Groups[i].Value);
                }
                res.Add(result);
                charSetMatch = charSetMatch.NextMatch();
            }
            return res;
        }
        public static rexData getrexDataByRex(string txt, string rex, int index)
        {
            rexData result = new rexData();
            Match charSetMatch = Regex.Match(txt, rex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            while (charSetMatch.Success)
            {
                result.data.Add(charSetMatch.Groups[index].Value);
                charSetMatch = charSetMatch.NextMatch();
            }
            return result;
        }
        public static string getStringByRex(string txt, string rex, int index)
        {
            List<rexData> res = new List<rexData>();
            rexData result = new rexData();
            Match charSetMatch = Regex.Match(txt, rex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            while (charSetMatch.Success)
            {
                return charSetMatch.Groups[index].Value;
            }
            return "";
        }
        
        //获得随机数
        public static string getRandomNum(int length)
        {
            Random rand = new Random((int)(DateTime.Now.Ticks));
            if (length <1) {
                return "";
            }
            string res = String.Empty;
            res += rand.Next(9) + 1;
            for (int i = 1; i < length; i++)
            {
                res += rand.Next(10);
            }
            return res;
        }

        public static CookieCollection GetCookieCollectionByString(string cookieHead, string defaultDomain)
        {
            CookieCollection collection = new CookieCollection();
            if (cookieHead == null) return null;
            if (defaultDomain == null) return null;
            string[] ary = cookieHead.Split(';');
            for (int i = 0; i < ary.Length; i++)
            {
                Cookie ck = GetCookieFromString(ary[i].Trim(), defaultDomain);
                if (ck != null)
                {
                    ck.Version = 0;
                    collection.Add(ck);
                }
            }
            return collection;
        }
        public static Cookie GetCookieFromString(string cookieString, string defaultDomain)
        {
            if (cookieString == null || defaultDomain == null) return null;
            string[] ary = cookieString.Split(',');
            Hashtable hs = new Hashtable();
            for (int i = 0; i < ary.Length; i++)
            {
                string s = ary[i].Trim();
                int index = s.IndexOf("=", System.StringComparison.Ordinal);
                if (index > 0)
                {
                    hs.Add(s.Substring(0, index), s.Substring(index + 1));
                }
            }
            Cookie ck = new Cookie();
            foreach (object key in hs.Keys)
            {
                if (key.ToString() == "path") ck.Path = hs[key].ToString();

                else if (key.ToString() == "expires")
                {
                    //ck.Expires=DateTime.Parse(hs[Key].ToString();
                }
                else if (key.ToString() == "domain") ck.Domain = hs[key].ToString();
                else
                {
                    ck.Name = key.ToString();
                    ck.Value = hs[key].ToString();
                }
            }
            if (ck.Name == "") return null;
            if (ck.Domain == "") ck.Domain = defaultDomain;
            return ck;
        }

        public static CookieCollection getCookie(HttpWebResponse response, string defaultDomain)
        {
            if (response == null)
            {
                return null;
            }
            String cookieVal = null;
            String key = null;
            for (int i = 1; i < response.Headers.Count ; i++)
            {
                key = response.Headers.GetKey(i);
                if (key.Equals("Set-Cookie"))
                {
                    cookieVal += response.Headers[i];
                }
            }
            if (cookieVal == null)
            {
                return new CookieCollection();
            }
            return GetCookieCollectionByString(cookieVal,defaultDomain);
        }

        /// <summary>
        /// 对 response 进行 zip 解压缩
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static string gzipDecompress(HttpWebResponse response)
        {
            StringBuilder s = new StringBuilder(102400);
            GZipStream g = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
            byte[] d = new byte[20480];
            int l = g.Read(d, 0, 20480);
            while (l > 0)
            {
                s.Append(Encoding.Default.GetString(d, 0, l));
                l = g.Read(d, 0, 20480);
            }
            return s.ToString();
        }
        //gzip  解压缩
        public static DataSet GetDatasetByString(string Value)
        {
            DataSet ds = new DataSet();
            string CC = GZipDecompressString(Value);
            System.IO.StringReader Sr = new StringReader(CC);
            ds.ReadXml(Sr);
            return ds;
        }

        /// <summary>  
        /// 将传入的二进制字符串资料以GZip算法解压缩  
        /// </summary>  
        /// <param name="zippedString">经GZip压缩后的二进制字符串</param>  
        /// <returns>原始未压缩字符串</returns>  
        public static string GZipDecompressString(string zippedString)
        {
            if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
            {
                return "";
            }
            else
            {
                byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
                return (string)(System.Text.Encoding.UTF8.GetString(Decompress(zippedData)));
            }
        }
        /// <summary>  
        /// ZIP解压  
        /// </summary>  
        /// <param name="zippedData"></param>  
        /// <returns></returns>  
        public static byte[] Decompress(byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream outBuffer = new MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }

        /// <summary>
        /// cookiecontainer 保存到文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="cookieJar"></param>
        public static void WriteCookiesToDisk(string file, CookieContainer cookieJar)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    Console.Out.Write("Writing cookies to disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookieJar);
                    Console.Out.WriteLine("Done.");
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Problem writing cookies to disk: " + e.GetType());
                }
            }
        }
        /// <summary>
        /// 从文件读取 cookiecontainer
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static CookieContainer ReadCookiesFromDisk(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    Console.Out.Write("Reading cookies from disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    Console.Out.WriteLine("Done.");
                    return (CookieContainer)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Problem reading cookies from disk: " + e.GetType());
                return new CookieContainer();
            }
        }

        public static CookieCollection CookieContainerToCookieCollection(CookieContainer cc,string[] urilist)
        {
            CookieCollection ccn = new CookieCollection();
            foreach(string str in urilist) {
                //ccn.Add(cc.GetCookieHeader(new Uri(str)));
            }
            return ccn;
        }
        /// <summary>
        /// 获得cookies列表 用于修改 domain
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>

        public static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }

            return lstCookies;
        }

        public string CookieContainerToString(CookieContainer cc)
        {
            StringBuilder sbc = new StringBuilder();
            List<Cookie> cooklist = GetAllCookies(cc);
            foreach (Cookie cookie in cooklist)
            {
                sbc.AppendFormat("{0};{1};{2};{3};{4};{5}\r\n",
                    cookie.Domain, cookie.Name, cookie.Path, cookie.Port,
                    cookie.Secure.ToString(), cookie.Value);
            }
            return sbc.ToString();
        }

        public CookieContainer StringToCookieContainer(string ss)
        {
            CookieContainer ccn = new CookieContainer();
            string[] cookies = ss.Split("\r\n".ToCharArray());
            foreach (string c in cookies)
            {
                string[] cc = c.Split(";".ToCharArray());
                Cookie ck = new Cookie(); ;
                ck.Discard = false;
                ck.Domain = cc[0];
                ck.Expired = true;
                ck.HttpOnly = true;
                ck.Name = cc[1];
                ck.Path = cc[2];
                ck.Port = cc[3];
                ck.Secure = bool.Parse(cc[4]);
                ck.Value = cc[5];
                ccn.Add(ck);
            }
            return ccn;
        }

        public static CookieContainer changeDomain(CookieContainer cc,string url)
        {
            CookieContainer ccn = new CookieContainer();
            List<Cookie> cl = HtmlTools.GetAllCookies(cc);
            for (int i = 0; i < cl.Count; i++)
            {
                cl[i].Version = 0;
                cl[i].Domain = url;
                ccn.Add(cl[i]);
            }
            return ccn;
        }
        public static string getEncodingString(string str,string strencoding,string changeencoding)
        {
            Encoding ogcoding = Encoding.GetEncoding(strencoding);
            Encoding cgcoding = Encoding.GetEncoding(changeencoding);
            byte[] b = ogcoding.GetBytes(str);
            byte[] asciiBytes = Encoding.Convert(ogcoding, cgcoding, b);
            char[] asciiChars = new char[cgcoding.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            cgcoding.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            return new string(asciiChars);
        }

        public static string getUrlString(string str, string strencoding, string changeencoding)
        {
                Encoding ogcoding = Encoding.GetEncoding(strencoding);
                Encoding cgcoding = Encoding.GetEncoding(changeencoding);
                //解码                    
                return getUrlString(str, ogcoding, cgcoding);
        }

        public static string getUrlString(string str, Encoding ogcoding, Encoding cgcoding)
        {
            return cgcoding.GetString(Encoding.Default.GetBytes(HttpUtility.UrlDecode(str.ToUpper(), ogcoding)));
        }

        public static string getUnicodeUrlDecode(string str)
        {
            MatchCollection mCollection2 = Regex.Matches(str, "([\\w]+)|(\\\\u([\\w]{4}))");
            StringBuilder sb = new StringBuilder();
            foreach (Match m2 in mCollection2)
            {
                string v = m2.Value;
                if (v.StartsWith("\\u"))
                {
                    string word = v.Substring(2);
                    byte[] codes = new byte[2];
                    int code = System.Convert.ToInt32(word.Substring(0, 2), 16);
                    int code2 = System.Convert.ToInt32(word.Substring(2), 16);
                    codes[0] = (byte)code2;
                    codes[1] = (byte)code;
                    sb.Append(Encoding.Unicode.GetString(codes));
                }
                else
                {
                    sb.Append(v);
                }
            }
            return sb.ToString();
        }

        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string UrlDecode(string str,Encoding e)
        {
            return HttpUtility.UrlDecode(str, e);
        }

        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        public static string UrlEncode(string str, Encoding e)
        {
            return HttpUtility.UrlEncode(str, e);
        }
        public static string getStringByResponse(HttpWebResponse response)
        {
            string str = "";
            if (response != null)
            {
                if (response.ContentEncoding.IndexOf("gzip") != -1)
                {
                    str = HtmlTools.gzipDecompress(response);
                }
                else
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        str = sr.ReadToEnd();
                    }
                }
            }
            return str;
        }

        public static Bitmap getBitmapBybase64(string base64str)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(base64str);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                //ms.Close();
                return bmp;
            }  
            catch (Exception ex)  
            {  
                Console.WriteLine("Base64StringToImage 转换失败/nException："+ex.Message);
                return null;
            }  
        }  
    }
}
