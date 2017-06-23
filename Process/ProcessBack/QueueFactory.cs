using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace ProcessBack
{
    /// <summary>
    /// 队列工厂
    /// </summary>
    public class QueueFactory
    {
        /// <summary>
        /// 私有成员（单例）
        /// </summary>
        private static QueueFactory instance;

        /// <summary>
        /// 所有队列
        /// </summary>
        public Queue<PCB> AllQue = null;

        /// <summary>
        /// 就绪队列
        /// </summary>
        public Queue<PCB> ReadyQue = null;

        /// <summary>
        /// 后备就绪队列
        /// </summary>
        public Queue<PCB> BackupReadyQue = null;

        /// <summary>
        /// 输入队列
        /// </summary>
        public List<PCB> InputQue = null;

        /// <summary>
        /// 输出队列
        /// </summary>
        public List<PCB> OutputQue = null;

        /// <summary>
        /// 等待队列
        /// </summary>
        public List<PCB> WaitQue = null;

        private QueueFactory()
        {
            AllQue = new Queue<PCB>();
            ReadyQue = new Queue<PCB>();
            BackupReadyQue = new Queue<PCB>();
            InputQue = new List<PCB>();
            OutputQue = new List<PCB>();
            WaitQue = new List<PCB>(); 
        }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        /// 指定该方法是线程安全的
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static QueueFactory GetInstance()
        {
            //当实例为空时，才创建，否则，不创建
            if (instance == null)
            {
                instance = new QueueFactory();
            }
            return instance;
        }

        /// <summary>
        /// 判断是否所有的队列都为空
        /// </summary>
        /// <returns>所有队列为空</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool QueFactoryEmpty()
        {
            return instance.ReadyQue.Count == 0 && instance.BackupReadyQue.Count == 0 && instance.InputQue.Count == 0 && instance.OutputQue.Count == 0 && instance.WaitQue.Count == 0;
        }
    }
}
