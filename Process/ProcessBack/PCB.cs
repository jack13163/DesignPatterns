using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessBack
{
    /// <summary>
    /// 进程控制块
    /// </summary>
    public class PCB
    {
        /// <summary>
        /// //进程名称
        /// </summary>
        public string PName { get; set; }

        /// <summary>
        /// 进程指令列表
        /// </summary>
        public List<Instructions> PInstructions { get; set; }

        /// <summary>
        /// 程序计数器
        /// </summary>
        public int CurrentInstruction { get; set; }

        /// <summary>
        /// 进程上下文
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PCB()
        {
            PInstructions = new List<Instructions>();

            //初始化进程上下文
            Context = new Context();
        }
    }
}
