namespace Process
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblC = new System.Windows.Forms.Label();
            this.lblCurrentProcess = new System.Windows.Forms.Label();
            this.lbInputWaitQueue = new System.Windows.Forms.ListBox();
            this.lbWaitQueue = new System.Windows.Forms.ListBox();
            this.lbOnReadyQueue = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbQueueStatus = new System.Windows.Forms.GroupBox();
            this.lbReadyQueue = new System.Windows.Forms.ListBox();
            this.lbOutputWaitQueue = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbQueueStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(108, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始调度";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(205, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止调度";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(316, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(119, 12);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "时间片大小（毫秒）:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(441, 14);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 21);
            this.txtTime.TabIndex = 4;
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(19, 69);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(53, 12);
            this.lblC.TabIndex = 5;
            this.lblC.Text = "当前进程";
            // 
            // lblCurrentProcess
            // 
            this.lblCurrentProcess.AutoSize = true;
            this.lblCurrentProcess.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentProcess.Location = new System.Drawing.Point(87, 69);
            this.lblCurrentProcess.Name = "lblCurrentProcess";
            this.lblCurrentProcess.Size = new System.Drawing.Size(0, 12);
            this.lblCurrentProcess.TabIndex = 6;
            // 
            // lbInputWaitQueue
            // 
            this.lbInputWaitQueue.FormattingEnabled = true;
            this.lbInputWaitQueue.ItemHeight = 12;
            this.lbInputWaitQueue.Location = new System.Drawing.Point(360, 44);
            this.lbInputWaitQueue.Name = "lbInputWaitQueue";
            this.lbInputWaitQueue.Size = new System.Drawing.Size(120, 88);
            this.lbInputWaitQueue.TabIndex = 8;
            // 
            // lbWaitQueue
            // 
            this.lbWaitQueue.FormattingEnabled = true;
            this.lbWaitQueue.ItemHeight = 12;
            this.lbWaitQueue.Location = new System.Drawing.Point(199, 170);
            this.lbWaitQueue.Name = "lbWaitQueue";
            this.lbWaitQueue.Size = new System.Drawing.Size(120, 88);
            this.lbWaitQueue.TabIndex = 9;
            // 
            // lbOnReadyQueue
            // 
            this.lbOnReadyQueue.FormattingEnabled = true;
            this.lbOnReadyQueue.ItemHeight = 12;
            this.lbOnReadyQueue.Location = new System.Drawing.Point(199, 44);
            this.lbOnReadyQueue.Name = "lbOnReadyQueue";
            this.lbOnReadyQueue.Size = new System.Drawing.Size(120, 88);
            this.lbOnReadyQueue.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "就绪队列";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "后备就绪队列";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "输入等待队列";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "其他等待队列";
            // 
            // gbQueueStatus
            // 
            this.gbQueueStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQueueStatus.Controls.Add(this.lbReadyQueue);
            this.gbQueueStatus.Controls.Add(this.label4);
            this.gbQueueStatus.Controls.Add(this.lbOutputWaitQueue);
            this.gbQueueStatus.Controls.Add(this.label5);
            this.gbQueueStatus.Controls.Add(this.lbInputWaitQueue);
            this.gbQueueStatus.Controls.Add(this.label3);
            this.gbQueueStatus.Controls.Add(this.lbWaitQueue);
            this.gbQueueStatus.Controls.Add(this.label2);
            this.gbQueueStatus.Controls.Add(this.lbOnReadyQueue);
            this.gbQueueStatus.Controls.Add(this.label1);
            this.gbQueueStatus.Location = new System.Drawing.Point(21, 108);
            this.gbQueueStatus.Name = "gbQueueStatus";
            this.gbQueueStatus.Size = new System.Drawing.Size(516, 270);
            this.gbQueueStatus.TabIndex = 15;
            this.gbQueueStatus.TabStop = false;
            this.gbQueueStatus.Text = "进程状态";
            // 
            // lbReadyQueue
            // 
            this.lbReadyQueue.FormattingEnabled = true;
            this.lbReadyQueue.ItemHeight = 12;
            this.lbReadyQueue.Location = new System.Drawing.Point(42, 44);
            this.lbReadyQueue.Name = "lbReadyQueue";
            this.lbReadyQueue.Size = new System.Drawing.Size(120, 88);
            this.lbReadyQueue.TabIndex = 7;
            // 
            // lbOutputWaitQueue
            // 
            this.lbOutputWaitQueue.FormattingEnabled = true;
            this.lbOutputWaitQueue.ItemHeight = 12;
            this.lbOutputWaitQueue.Location = new System.Drawing.Point(42, 170);
            this.lbOutputWaitQueue.Name = "lbOutputWaitQueue";
            this.lbOutputWaitQueue.Size = new System.Drawing.Size(120, 88);
            this.lbOutputWaitQueue.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "输出等待队列";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 390);
            this.Controls.Add(this.gbQueueStatus);
            this.Controls.Add(this.lblCurrentProcess);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "MainFrm";
            this.Text = "进程模拟系统";
            this.gbQueueStatus.ResumeLayout(false);
            this.gbQueueStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblCurrentProcess;
        private System.Windows.Forms.ListBox lbInputWaitQueue;
        private System.Windows.Forms.ListBox lbWaitQueue;
        private System.Windows.Forms.ListBox lbOnReadyQueue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbQueueStatus;
        private System.Windows.Forms.ListBox lbOutputWaitQueue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbReadyQueue;
    }
}

