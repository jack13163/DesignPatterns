using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using Logger;


namespace ProcessBack
{
    /// <summary>
    /// 调度策略实现类（调度算法）
    /// </summary>
    public class ShedulerProxy : ShedulerTemplete
    {
        /// <summary>
        /// 作业调度线程
        /// </summary>
        private static Thread homeworktask = null;

        /// <summary>
        /// 进程调度线程
        /// </summary>
        private static Thread processtask = null;

        /// <summary>
        /// 阻塞调度线程
        /// </summary>
        private static Thread iotask = null;

        public ShedulerProxy()
        {
        }

        private static bool flag = true;

        /// <summary>
        /// 进程调度
        /// </summary>
        public override void ProcessShedule()
        {
            //开启新的线程开始模拟进程调度
            processtask = new Thread(ProcessSheduler);
            processtask.Start();
        }

        /// <summary>
        /// 作业调度
        /// </summary>
        public override void HomeworkShedule()
        {
            //开启新的线程开始模拟进程调度
            homeworktask = new Thread(HomeworkSheduler);
            homeworktask.Start();
        }

        /// <summary>
        /// 阻塞调度
        /// </summary>
        public override void WaitShedule()
        {
            //开始检查阻塞队列调度
            iotask = new Thread(Wakeup);
            iotask.Start();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="t_p"></param>
        public override void Init(int t_p = 1000)
        {
            //设置时间片大小
            T = t_p;

            //清空队列
            QueueFactory.GetInstance().InputQue.Clear();
            QueueFactory.GetInstance().WaitQue.Clear();
            QueueFactory.GetInstance().ReadyQue.Clear();
            QueueFactory.GetInstance().BackupReadyQue.Clear();
            QueueFactory.GetInstance().OutputQue.Clear();

            flag = true;

            //准备进程
            MemoryProcess.OnRunning();
        }

        /// <summary>
        /// 将阻塞进程唤醒
        /// </summary>
        /// <param name="obj"></param>
        private void Wakeup()
        {
            while (flag)
            {
                Monitor.Enter(QueueFactory.GetInstance().InputQue);
                CheckAndSetQueueStatus(QueueFactory.GetInstance().InputQue);
                Monitor.Exit(QueueFactory.GetInstance().InputQue);

                Monitor.Enter(QueueFactory.GetInstance().WaitQue);
                CheckAndSetQueueStatus(QueueFactory.GetInstance().WaitQue);
                Monitor.Exit(QueueFactory.GetInstance().WaitQue);

                Monitor.Enter(QueueFactory.GetInstance().OutputQue);
                CheckAndSetQueueStatus(QueueFactory.GetInstance().OutputQue);
                Monitor.Exit(QueueFactory.GetInstance().OutputQue);

                Thread.Sleep(T);
            }
        }

        /// <summary>
        /// 检查阻塞队列的队首元素的状态
        /// </summary>
        /// <param name="queue"></param>
        private void CheckAndSetQueueStatus(List<PCB> queue)
        {
            if (queue.Count > 0)
            {
                //执行IO操作
                foreach (var item in queue)
                {
                    if (item.PInstructions[item.CurrentInstruction].IRemaintime > 0)
                    {
                        item.PInstructions[item.CurrentInstruction].IRemaintime--;
                    }
                }

                //检查是否有执行完成IO的进程，倒序遍历删除
                for (int i = queue.Count - 1; i >= 0;i-- )
                {
                    PCB item = queue.ElementAt(i);

                    //如果
                    if (item.PInstructions[item.CurrentInstruction].IRemaintime <= 0)
                    {
                        //阻塞时间减少为0，则移入就绪队列
                        queue.Remove(item);
                        item.Context.StatusChange(StatusFactory.GetInstance().Ready);
                        item.CurrentInstruction++;//程序计数器加一
                        if (item.PInstructions.Count - 1 >= item.CurrentInstruction)
                        {
                            QueueFactory.GetInstance().ReadyQue.Enqueue(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 作业调度(一个线程)
        /// </summary>
        private void HomeworkSheduler()
        {
            while (flag)
            {
                Monitor.Enter(QueueFactory.GetInstance().ReadyQue);
                Monitor.Enter(QueueFactory.GetInstance().BackupReadyQue);
                //从后备就绪队列中取队首进程，粗略限制就绪进程数目为3
                if (QueueFactory.GetInstance().BackupReadyQue.Count > 0 && QueueFactory.GetInstance().ReadyQue.Count < 3)
                {
                    PCB p = QueueFactory.GetInstance().BackupReadyQue.Dequeue();

                    //插入就绪队列
                    QueueFactory.GetInstance().ReadyQue.Enqueue(p);
                }
                else
                {
                    //挂起线程（就绪进程已经足够）
                    Thread.Sleep(T);
                }
                Monitor.Exit(QueueFactory.GetInstance().BackupReadyQue);
                Monitor.Exit(QueueFactory.GetInstance().ReadyQue);
            }
        }

        /// <summary>
        /// 进程调度(一个线程),进程调度入口
        /// </summary>
        private void ProcessSheduler()
        {
            while (flag)
            {
                Monitor.Enter(QueueFactory.GetInstance().ReadyQue);
                //从就绪队列中取队首进程
                if (QueueFactory.GetInstance().ReadyQue.Count > 0)
                {
                    //取队首进程，并通知状态改变，更新视图
                    PCB p = QueueFactory.GetInstance().ReadyQue.Dequeue();
                    p.Context.current = p;

                    //运行一个时间片时间的队首进程
                    p = MemoryProcess.Running(p);

                    if (p != null)
                    {
                        QueueFactory.GetInstance().ReadyQue.Enqueue(p);
                    }
                }
                
                //判断所有的队列是否为空
                if (QueueFactory.GetInstance().QueFactoryEmpty())
                {
                    Console.WriteLine("停止调度！");
                    flag = false;
                }
                Monitor.Exit(QueueFactory.GetInstance().ReadyQue);
            }
        }

        /// <summary>
        /// 停止进程调度
        /// </summary>
        public override void StopShedule()
        {
            //最好让线程自动结束
            flag = false;
        }

        /// <summary>
        /// 停止作业调度
        /// </summary>
        public override void StopHomeworkShedule()
        {
            //最好让线程自动结束
            flag = false;
        }

        /// <summary>
        /// 停止阻塞调度
        /// </summary>
        public override void StopWaitShedule()
        {
            ////终止进程调度线程
            //this.iotask.Abort();
            //while (this.iotask.ThreadState != ThreadState.Aborted)
            //{
            //    //当调用Abort方法后，如果thread线程的状态不为Aborted，主线程就一直在这里做循环，直到thread线程的状态变为Aborted为止
            //    Thread.Sleep(100);
            //}
            //最好让线程自动结束
            flag = false;
        }
    }
}
