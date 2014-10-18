using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace pyystone
{
    class FileLS
    {
        /// <summary>
        /// 判断文件路径是否存在，不存在就创建
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static bool is_create(string fileurl)
        {
            bool bRet = false;
            while (true)
            {
                //判断文件是否存在
                if (!File.Exists(fileurl))
                {
                    FileStream fs = new FileStream(fileurl, FileMode.Create);
                    fs.Close();
                    fs.Dispose();
                }
                bRet = true;
                break;
            }
            return bRet;
        }
        public static void folder_is_create(string fileurl)
        {
            try
            {
                if (!Directory.Exists(fileurl))
                    Directory.CreateDirectory(fileurl);
            }
            catch (System.Exception ex)
            {
                
            }
        }
        /// <summary>
        /// 文件读取流创建
        /// 如果StreamReader 返回null的话就说明文件流创建失败
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static StreamReader fileReader(string fileurl)
        {
            if (is_create(fileurl))
            {
                return new StreamReader(fileurl);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 文件读取流创建 指定编码
        /// 如果StreamReader 返回null的话就说明文件流创建失败
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static StreamReader fileReader(string fileurl, string encoding)
        {
            if (is_create(fileurl))
            {
                return new StreamReader(fileurl, System.Text.Encoding.GetEncoding(encoding));
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 文件读取流
        /// 返回null 表示 文件流创建失败
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static StreamWriter FileWrite(string fileurl)
        {
            if (is_create(fileurl))
            {
                return new StreamWriter(fileurl);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 文件读取流,指定编码
        /// 返回null 表示 文件流创建失败
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static StreamWriter FileWrite(string fileurl, string encoding)
        {
            if (is_create(fileurl))
            {
                return new StreamWriter(fileurl, false, System.Text.Encoding.GetEncoding(encoding));
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 文件读取流,指定编码,是否追加
        /// 返回null 表示 文件流创建失败
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static StreamWriter FileWrite(string fileurl, string encoding,bool append)
        {
            if (is_create(fileurl))
            {
                return new StreamWriter(fileurl, append, System.Text.Encoding.GetEncoding(encoding));
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="url">文件路径</param>
        /// <param name="date">要存入文件的信息</param>
        /// <returns></returns>
        public static bool FileSave(string url, string date)
        {
            bool bRet = false;
            while (true)
            {
                StreamWriter sw = FileWrite(url,"utf-8",true);
                if (sw == null)
                {
                    break;
                }
                sw.WriteLine(date);
                //flush 如果不加进入的话，文件的内容是不会更新的
                sw.Flush();
                sw.Close();
                bRet = true;
                break;
            }
            return bRet;
        }

        public static void CreateFile(string fileurl) {
            if (!Directory.Exists(fileurl))
            {
                Directory.CreateDirectory(fileurl);
            }
        }
    }
}
