using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pyystone
{
    class baiduData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="tiebaname">贴吧名称</param>
        /// <param name="time">时间格式为XXXX-XX-XX XX:XX</param>
        /// <returns></returns>
        public static bool passByTime(string username, string tiebaname, string time)
        {
            bool bret = false;
            try
             {
                string url = "http://tieba.baidu.com/f/search/ures?ie=utf-8";
                url += "&un=" + username;
                url += "&kw=" + tiebaname;
                string data = "";
                int times = 0;
                while (HtmlTools.getStringByRex(data, "百度一下，找到相关贴吧贴子([\\d]+)篇",1) == "" && times < 5) {
                    data = HtmlTools.DownHtmlPage(url);
                    times++;
                }
                if (times >= 5)
                {
                    return false;
                }
                if (time != null || time != "")
                {
                    string datatime = HtmlTools.getStringByRex(data, "p_date\">([^<]+)<", 1);
                    if (datatime == null)
                    {
                        return false;
                    }
                    if (datatime.CompareTo( time) >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e )
            {
                Console.Out.WriteLine(e.ToString());
                return bret;
            }
        }

        internal static bool passbyFNum(string username, string tiebaname, string Fnum)
        {
            bool bret = false;
            try
            {
                string url = "http://tieba.baidu.com/f/search/ures?ie=utf-8";
                url += "&un=" + username;
                url += "&kw=" + tiebaname;
                string data = "";
                int times = 0;
                string num = "";
                while ( num == "" && times < 5)
                {
                    data = HtmlTools.DownHtmlPage(url);
                    num = HtmlTools.getStringByRex(data, "百度一下，找到相关贴吧贴子([\\d]+)篇", 1);
                    times++;
                }
                if (times >= 5)
                {
                    return false;
                }
                if (num != null || num != "")
                {
                    string datatime = HtmlTools.getStringByRex(data, "p_date\">([^<]+)<", 1);
                    if (Fnum == null)
                    {
                        return true;
                    }
                    if (Fnum.CompareTo(num) >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
                return bret;
            }
        }
    }
}
