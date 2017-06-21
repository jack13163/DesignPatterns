using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Process
{
    public interface ISubject
    {
        //通知观察者对象
        void Notify();

        //添加监听者
        void AddListener(IObserver obj);
    }
}
