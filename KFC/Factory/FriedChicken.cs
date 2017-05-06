using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
    public class FriedChicken : IMainFood
    {
        public void Do()
        {
            Console.WriteLine("制作炸鸡中...");
        }

        public void Dish()
        {
            Console.WriteLine("炸鸡装盘中...");
        }

        public void Finish()
        {
            Console.WriteLine("炸鸡已做好，请慢用！");
        }
    }
}
