using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Process;

namespace ProcessBack
{
    /// <summary>
    /// 输出阻塞状态
    /// </summary>
    public class OutputWaitStatus : ProcessStatus, ISubject
    {
        public void UpdateView(Context context)
        {
            //更新视图
            Notify();
        }

        //订阅队列
        List<IObserver> objList = new List<IObserver>();

        public void Notify()
        {
            foreach (var item in objList)
            {
                item.UpdateView("O", QueueFactory.GetInstance().InputQue);
            }
        }

        public void AddListener(IObserver obj)
        {
            this.objList.Add(obj);
        }
    }
}
