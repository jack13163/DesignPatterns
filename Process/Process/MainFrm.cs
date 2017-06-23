using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ProcessBack;
using System.Threading;
using System.Threading.Tasks;

namespace Process
{
    public partial class MainFrm : Form, IObserver
    {
        /// <summary>
        /// 进程调度器
        /// </summary>
        private ShedulerTemplete sheduler = new ShedulerProxy();

        public MainFrm()
        {
            InitializeComponent();

            this.btnStop.Enabled = false;
            this.btnStart.Enabled = false;
            this.txtTime.Text = "1000";

            //添加监听
            StatusFactory.GetInstance().Ready.AddListener(this);
            StatusFactory.GetInstance().Running.AddListener(this);
            StatusFactory.GetInstance().Wait.AddListener(this);
            StatusFactory.GetInstance().Output.AddListener(this);
            StatusFactory.GetInstance().OnReady.AddListener(this);
            StatusFactory.GetInstance().Input.AddListener(this);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            //设置文件过滤
            openfile.Filter = @"文本文件|*.txt";

            //打开
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                //获取文件名
                string filepath = openfile.FileName;

                //加载程序到所有队列中
                MemoryProcess.LoadProcess(filepath);
            }
            this.btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始调度");

            if (!this.txtTime.Text.Trim().Equals(""))
            {
                //设置按钮不可用
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;

                //设置进程调度时间片大小(毫秒)
                int ms = int.Parse(this.txtTime.Text.Trim());

                //初始化
                sheduler.Init(ms);
                //作业调度
                sheduler.HomeworkShedule();
                //进程调度
                sheduler.ProcessShedule();
                //阻塞调度
                sheduler.WaitShedule();
            }
            else
            {
                MessageBox.Show("请输入时间片大小！");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //停止进程调度
            sheduler.StopShedule();
            sheduler.StopHomeworkShedule();
            sheduler.StopWaitShedule();

            //设置按钮不可用
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
        }

        /// <summary>
        /// 更新视图
        /// </summary>
        /// <param name="data"></param>
        public void UpdateView(string view, object data)
        {
            if (view.Equals("I"))
            {
                DataBinding(this.lbInputWaitQueue, data);
            }
            else if (view.Equals("O"))
            {
                DataBinding(this.lbOutputWaitQueue, data);
            }
            else if (view.Equals("W"))
            {
                DataBinding(this.lbWaitQueue, data);
            }
            else if (view.Equals("R"))
            {
                DataBinding(this.lbReadyQueue, data);
            }
            else if (view.Equals("OR"))
            {
                DataBinding(this.lbOnReadyQueue, data);
            }
            else if (view.Equals("L"))
            {
                DataBinding(this.lblCurrentProcess, data);
            }
        }

        /// <summary>
        /// 将数据绑定到控件
        /// </summary>
        /// <param name="view"></param>
        /// <param name="data"></param>
        private void DataBinding(object view, object data)
        {
            if (view is ListBox)
            {
                ListBox lb = ((ListBox)view);
                lb.Items.Clear();

                //判断结点类型，加入元素，不能使用foreach进行遍历
                if (data is Queue<PCB>)
                {
                    //添加到列表中显示
                    for (int i = 0; i < ((Queue<PCB>)data).Count; i++)
                    {
                        //添加到对应队列
                        lb.Items.Add(((Queue<PCB>)data).ElementAt(i).PName);
                    }
                }
                else if (data is List<PCB>)
                {
                    //添加到列表中显示
                    for (int i = 0; i < ((List<PCB>)data).Count; i++)
                    {
                        //添加到对应队列
                        lb.Items.Add(((List<PCB>)data).ElementAt(i).PName);
                    }
                }
            }
            else if (view is Label)
            {
                if (data is string)
                {
                    Label lbl = ((Label)view);

                    lbl.Text = data.ToString();
                }
            }
        }
    }
}
