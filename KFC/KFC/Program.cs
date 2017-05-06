using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace KFC
{
    class Program
    {
        static void Main(string[] args)
        {
            //荆州肯德基店
            Console.WriteLine("欢迎光临荆州肯德基店！");
            Console.WriteLine("-----------------------------------------------------------");
            IFactory fac = new JZKFC();
            //点喝的
            fac.OrderDrink();
            //点吃的
            fac.OrderMainFood();

            Console.WriteLine("\n\n\n");

            //荆州肯德基店
            Console.WriteLine("欢迎光临上海肯德基店！");
            Console.WriteLine("-----------------------------------------------------------");
            fac = new SHKFC();
            //点喝的
            fac.OrderDrink();
            //点吃的
            fac.OrderMainFood();
        }
    }
}
