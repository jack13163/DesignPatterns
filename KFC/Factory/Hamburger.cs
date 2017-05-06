using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
    public class Hamburger : IMainFood
    {
        /// <summary>
        /// 具体的烘烤方法可能不一样
        /// </summary>
        public void Do()
        {
            Console.WriteLine("正在烘烤汉堡中...");
        }

        public void Dish()
        {
            Console.WriteLine("正在将汉堡放在盘子里...");
        }

        public void Finish()
        {
            Console.WriteLine("汉堡已做好，请慢用！");
        }
    }
}
