using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessBack
{
    /// <summary>
    /// 状态工厂
    /// </summary>
    public class StatusFactory
    {
        /// <summary>
        /// 私有成员（单例）
        /// </summary>
        private static StatusFactory instance;

        /// <summary>
        /// 就绪状态
        /// </summary>
        public ReadyStatus Ready = new ReadyStatus();

        /// <summary>
        /// 后备就绪状态
        /// </summary>
        public OnReadyStatus OnReady = new OnReadyStatus();

        /// <summary>
        /// 运行状态
        /// </summary>
        public RunningStatus Running = new RunningStatus();

        /// <summary>
        /// 输入状态
        /// </summary>
        public InputWaitStatus Input = new InputWaitStatus();

        /// <summary>
        /// 输出状态
        /// </summary>
        public OutputWaitStatus Output = new OutputWaitStatus();

        /// <summary>
        /// 其他等待状态
        /// </summary>
        public OtherWaitStatus Wait = new OtherWaitStatus();

        private StatusFactory()
        {
            
        }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static StatusFactory GetInstance()
        {
            //当实例为空时，才创建，否则，不创建
            if (instance == null)
            {
                instance = new StatusFactory();
            }

            return instance;
        }
    }
}
