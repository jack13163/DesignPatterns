using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessBack
{
    /// <summary>
    /// 代表当前线程的状态(和进程一一对应，一个进程对应着一个进程上下文)
    /// </summary>
    public class Context
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        private ProcessStatus status = null;

        /// <summary>
        /// 当前进程
        /// </summary>
        public PCB current = null;

        public Context()
        {
        }

        /// <summary>
        /// 设置当前上下文进程的状态，并更新视图
        /// </summary>
        /// <param name="ps"></param>
        public void StatusChange(ProcessStatus ps)
        {
            if (status != null)
            {
                //调用更改状态前的界面更新函数
                status.UpdateView(this);
            }
            //改变当前状态
            this.status = ps;
            //调用更改状态后的界面更新函数
            status.UpdateView(this);
        }
    }
}
