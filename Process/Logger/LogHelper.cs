using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Logger
{
    /// <summary>
    /// 日志操作类，输出日志信息，可以设置多路输出
    /// </summary>
    public class LogHelper : ILog
    {
        private Stream stream = null;
        private string filepath = System.AppDomain.CurrentDomain.BaseDirectory + @"log.txt";

        /// <summary>
        /// 设置输出路径
        /// </summary>
        /// <param name="path">文件路径</param>
        public void SetOutput(string path)
        {
            this.filepath = path;
        }

        /// <summary>
        /// 设置输出的流
        /// </summary>
        /// <param name="stream">流</param>
        public void SetOutput(System.IO.Stream stream)
        {
            this.stream = stream;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">消息</param>
        public void Log(string message)
        {
            try
            {
                if (!this.filepath.Equals(""))
                {
                    if (!File.Exists(this.filepath))
                    {
                        File.Delete(this.filepath);
                    }

                    //写入文件
                    File.AppendAllText(filepath, DateTime.Now.ToString() + ":" + message + "\n", Encoding.UTF8);
                }
                if (this.stream != null)
                {
                    //写入流
                    StreamWriter sw = new StreamWriter(this.stream);
                    sw.Write(DateTime.Now.ToString() + ":" + message);
                    sw.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("日志写入出错" + ex.Message);
            }
        }
    }
}
