using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Process;
using System.Threading;

namespace ProcessBack
{
    /// <summary>
    /// 输入阻塞状态
    /// </summary>
    public class InputWaitStatus : ProcessStatus, ISubject
    {
        public void UpdateView(Context context)
        {
            //Console.WriteLine("进程" + context.current.PName + "由于输入而等待！");

            //更新视图
            Notify();
        }

        //订阅队列
        List<IObserver> objList = new List<IObserver>();

        public void Notify()
        {
            foreach(var item in objList)
            {
                item.UpdateView("I", QueueFactory.GetInstance().InputQue);
            }
        }

        public void AddListener(IObserver obj)
        {
            this.objList.Add(obj);
        }
    }
}
