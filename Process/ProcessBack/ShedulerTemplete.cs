using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ProcessBack
{
    /// <summary>
    /// 进程调度模板
    /// </summary>
    public abstract class ShedulerTemplete
    {
        /// <summary>
        /// 定时周期
        /// </summary>
        public static int T;

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <param name="t_p"></param>
        public abstract void Init(int t_p);

        /// <summary>
        /// 进程调度
        /// </summary>
        public abstract void ProcessShedule();

        /// <summary>
        /// 停止进程调度
        /// </summary>
        public abstract void StopShedule();

        /// <summary>
        /// 作业调度
        /// </summary>
        public abstract void HomeworkShedule();
    }
}
