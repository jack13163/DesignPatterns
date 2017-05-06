using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IDrink
    {
        /// <summary>
        /// 制作
        /// </summary>
        void Do();

        /// <summary>
        /// 装瓶子里面
        /// </summary>
        void Bottle();

        /// <summary>
        /// 饮品已经准备好
        /// </summary>
        void Finish();
    }
}
