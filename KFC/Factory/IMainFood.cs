using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IMainFood
    {
        /// <summary>
        /// 制作
        /// </summary>
        void Do();

        /// <summary>
        /// 装盘
        /// </summary>
        void Dish();

        /// <summary>
        /// 主食已经准备好
        /// </summary>
        void Finish();
    }
}