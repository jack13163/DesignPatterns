﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace XMLParse
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        /// <summary>
        /// 获取当前执行程序的根目录
        /// </summary>
        /// <returns>当前执行程序的根目录</returns>
        public static string getSolutionPath()
        {
            //获取运行路径
            string path = AppDomain.CurrentDomain.BaseDirectory;
            StringBuilder sb = new StringBuilder(path);
            return sb.Remove(path.IndexOf(@"bin"), path.Length - path.IndexOf("bin")).ToString();
        }
    }
}
