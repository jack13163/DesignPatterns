using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProcessBack;

namespace Process
{
    public interface IObserver
    {
        /// <summary>
        /// 更新视图
        /// </summary>
        /// <param name="view"></param>
        /// <param name="data"></param>
        void UpdateView(string view, object data);
    }
}
