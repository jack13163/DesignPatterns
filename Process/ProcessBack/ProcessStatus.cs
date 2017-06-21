using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessBack
{
    /// <summary>
    /// 进程状态
    /// </summary>
    public interface ProcessStatus
    {
        /// <summary>
        /// 更新视图
        /// </summary>
        /// <param name="context"></param>
        void UpdateView(Context context);
    }
}
