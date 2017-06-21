using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logger
{
    /// <summary>
    /// 日志操作类，输出日志信息，可以设置多路输出
    /// </summary>
    public class LogHelper : ILog
    {
        private Stream stream = null;
        private string filepath = "";

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
            if (this.filepath.Equals(""))
            {
                //创建文件
                FileInfo f = new FileInfo(this.filepath);
                //获取流写入器
                StreamWriter sw = f.AppendText();

                //写入流
                sw.WriteLine(DateTime.Now.ToString() + ":" + message);

                sw.Flush();
                sw.Close();
            }
            if(this.stream != null)
            {
                StreamWriter sw = new StreamWriter(this.stream);
                sw.Write(DateTime.Now.ToString() + ":" + message);
            }
        }
    }
}
