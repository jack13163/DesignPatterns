using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProcessBack
{
    public class MutexProtect
    {
        /// <summary>
        /// 互斥信号量1
        /// </summary>
        public static Mutex mutex1 = new Mutex();

        /// <summary>
        /// 互斥信号量2
        /// </summary>
        public static Mutex mutex2 = new Mutex();

        /// <summary>
        /// 互斥信号量3
        /// </summary>
        public static Mutex mutex3 = new Mutex();

        /// <summary>
        /// 互斥信号量4
        /// </summary>
        public static Mutex mutex4 = new Mutex();

    }
}
