using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessBack
{
    /// <summary>
    /// 
    /// </summary>
    public class Instructions
    {
        /// <summary>
        /// 指令标识符
        /// </summary>
        public char IName{get; set;}

        /// <summary>
        /// 指令运行时间
        /// </summary>
        public int IRuntime { get; set; }

        /// <summary>
        /// 指令剩余运行时间
        /// </summary>
        public int IRemaintime { get; set; }

        public Instructions()
        { }

        public Instructions(char name, int runtime, int remaintime)
        {
            this.IName = name;
            this.IRemaintime = remaintime;
            this.IRuntime = runtime;
        }
    }
}
