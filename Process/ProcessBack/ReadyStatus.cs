using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Process;

namespace ProcessBack
{
    /// <summary>
    /// 就绪状态
    /// </summary>
    public class ReadyStatus : ProcessStatus, ISubject
    {
        /// <summary>
        /// 该状态下对应的行为
        /// </summary>
        /// <param name="context"></param>
        /// <param name="instruction"></param>
        public void UpdateView(Context context)
        {
            //更新视图
            Notify();
        }

        /// <summary>
        /// 视图更新
        /// </summary>
        private List<IObserver> objList = new List<IObserver>();

        /// <summary>
        /// 更新就绪队列中的
        /// </summary>
        public void Notify()
        {
            foreach (var item in objList)
            {
                item.UpdateView("R", QueueFactory.GetInstance().ReadyQue);
            }
        }

        public void AddListener(IObserver obj)
        {
            this.objList.Add(obj);
        }

    }
}
