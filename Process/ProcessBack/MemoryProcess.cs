using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Process;
using System.Threading;
using Logger;


namespace ProcessBack
{
    /// <summary>
    /// 程序加载，指令处理类（内存）
    /// </summary>
    public class MemoryProcess
    {
        public MemoryProcess()
        {
            //设置输出路径
            //logger.SetOutput("C:/log.txt");
        }

        /// <summary>
        /// 保存阻塞时间
        /// </summary>
        private static int waittime;

        /// <summary>
        /// 判断进程是否执行结束
        /// </summary>
        public static bool complete = false;

        /// <summary>
        /// 设置等待时间
        /// </summary>
        /// <param name="time"></param>
        public void SetWaitTime(int time)
        {
            waittime = time;
        }

        /// <summary>
        /// 日志记录类
        /// </summary>
        private static ILog logger = new LogHelper();

        /// <summary>
        /// 未完成（不包含阻塞情况，阻塞情况已经处理）进程
        /// </summary>
        /// <param name="process">当前要送入内存执行的进程</param>
        /// <returns>未完成（不包含阻塞情况，阻塞情况已经处理）进程</returns>
        public static PCB Running(PCB process)
        {
            //解析一个时间片的指令
            return ParseInstruction(process);
        }

        /// <summary>
        /// 解析当前指令
        /// </summary>
        /// <param name="instruction">待解析的指令</param>
        /// <returns>未完成（不包含阻塞情况，阻塞情况已经处理）进程</returns>
        public static PCB ParseInstruction(PCB RunProcess)
        {
            //初始化
            complete = false;

            //当前执行到的指令
            Instructions instruction = RunProcess.PInstructions[RunProcess.CurrentInstruction];

            //进程名
            string processname = RunProcess.PName;

            //操作符
            string cmd = instruction.IName.ToString();

            //剩余时间片
            int timepick = instruction.IRemaintime;

            //判断指令内容
            if (cmd.Equals("I"))
            {
                Console.WriteLine("进程" + processname + ":I" + "，剩余：" + timepick);
                logger.Log("进程" + processname + ":I" + "，剩余：" + timepick);
                //插入输入阻塞队列
                QueueFactory.GetInstance().InputQue.Add(RunProcess);
                //通知状态改变，并更新视图
                RunProcess.Context.StatusChange(StatusFactory.GetInstance().Input);
            }
            else if (cmd.Equals("O"))
            {
                Console.WriteLine("进程" + processname + ":O" + "，剩余：" + timepick);
                logger.Log("进程" + processname + ":O" + "，剩余：" + timepick);

                //插入输入阻塞队列
                QueueFactory.GetInstance().OutputQue.Add(RunProcess);
                //通知状态改变，并更新视图
                RunProcess.Context.StatusChange(StatusFactory.GetInstance().Output);
            }
            else if (cmd.Equals("W"))
            {
                Console.WriteLine("进程" + processname + ":W" + "，剩余：" + timepick);
                logger.Log("进程" + processname + ":W" + "，剩余：" + timepick);

                //插入输入阻塞队列
                QueueFactory.GetInstance().WaitQue.Add(RunProcess);
                //通知状态改变，并更新视图
                RunProcess.Context.StatusChange(StatusFactory.GetInstance().Wait);
            }
            //进程结束
            else if (cmd.Equals("H"))
            {
                logger.Log("进程" + processname + ":H");
                complete = true;//进程结束
            }
            else if (cmd.Equals("C"))
            {
                Console.WriteLine("进程" + processname + ":C" + "，剩余：" + timepick);
                logger.Log("进程" + processname + ":C" + "，剩余：" + timepick);
                RunProcess.Context.StatusChange(StatusFactory.GetInstance().Running);
                //休眠指定的时间，占用时间片
                Thread.Sleep(ShedulerProxy.T);

                RunProcess.PInstructions[RunProcess.CurrentInstruction].IRemaintime--;
                //当前指令执行完
                if (RunProcess.PInstructions[RunProcess.CurrentInstruction].IRemaintime <= 0)
                {
                    RunProcess.CurrentInstruction++;//指令计数器加一
                    if (RunProcess.CurrentInstruction > RunProcess.PInstructions.Count - 1)
                    {
                        complete = true;//进程结束
                    }
                }
                RunProcess.Context.StatusChange(StatusFactory.GetInstance().Ready);

                return RunProcess;
            }

            //其他的情况不需要进一步处理
            return null;
        }

        /// <summary>
        /// 加载程序
        /// </summary>
        /// <param name="filepath">程序说明文件路径</param>
        public static void LoadProcess(string filepath)
        {
            //初始化
            QueueFactory.GetInstance().AllQue.Clear();

            //读入文件
            StreamReader sr = new StreamReader(filepath);

            //字节缓冲数组
            byte[] buff = new byte[1024];
            //循环读取到AllQue队列中
            string line = "";

            //当前进程
            PCB current = null;

            while ((line = sr.ReadLine()) != null)
            {
                //判断是否是新进程
                if (line.StartsWith("P"))
                {
                    //创建进程对象
                    PCB p = new PCB();

                    //填写进程信息，初始化程序计数器
                    p.PName = line;
                    p.CurrentInstruction = 0;

                    //指向当前进程
                    current = p;
                    //将该进程添加到进程队列AllQue中
                    QueueFactory.GetInstance().AllQue.Enqueue(current);
                }
                else if (!line.Equals(""))
                {
                    //创建进程指令对象，并添加到进程队列的指令队列中
                    Instructions ins = new Instructions();

                    //填写指令信息
                    ins.IName = line[0];
                    ins.IRuntime = ins.IRemaintime = int.Parse(line.Substring(1));

                    //将当前指令添加到进程的指令队列中
                    current.PInstructions.Add(ins);
                }
            }
        }

        /// <summary>
        /// 进入后备就绪状态
        /// </summary>
        public static void OnRunning()
        {
            //将所有进程全部加载到后备就绪队列中准备调度
            foreach (var item in QueueFactory.GetInstance().AllQue)
            {
                Monitor.Enter(QueueFactory.GetInstance().BackupReadyQue);
                QueueFactory.GetInstance().BackupReadyQue.Enqueue(item);
                //设置当前进程上下文，并修改进程状态为后备就绪状态
                item.Context.current = item;
                item.Context.StatusChange(StatusFactory.GetInstance().OnReady);
                Monitor.Exit(QueueFactory.GetInstance().BackupReadyQue);
            }
        }
    }
}