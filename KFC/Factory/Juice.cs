using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /// <summary>
    /// 果汁
    /// </summary>
    public class Juice : IDrink
    {
        public void Do()
        {
            Console.WriteLine("果汁制作中...");
        }

        public void Bottle()
        {
            Console.WriteLine("果汁装瓶中...");
        }

        public void Finish()
        {
            Console.WriteLine("果汁已做好，请慢用！");
        }
    }
}
