using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Process;


namespace ProcessBack
{
    /// <summary>
    /// 运行状态
    /// </summary>
    public class RunningStatus : ProcessStatus, ISubject
    {
        private string pname = "";

        public void UpdateView(Context context)
        {
            //更新视图
            this.pname = context.current.PName;            
            Notify();
        }

        //订阅队列
        private List<IObserver> objList = new List<IObserver>();

        public void Notify()
        {
            foreach (var item in objList)
            {
                item.UpdateView("L", this.pname);
            }
        }

        public void AddListener(IObserver obj)
        {
            this.objList.Add(obj);
        }
    }
}
