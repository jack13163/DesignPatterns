using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logger
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 设置输出文件路径（txt文件）
        /// </summary>
        /// <param name="path">路径</param>
        void SetOutput(string path);

        /// <summary>
        /// 设置日志的输出流
        /// </summary>
        /// <param name="stream"></param>
        void SetOutput(Stream stream);

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">日志信息</param>
        void Log(string message);
    }
}
