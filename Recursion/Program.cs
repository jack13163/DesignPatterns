using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //调用计算阶乘
            Calculator c = new Container();

            for (int i = 0; i < 19; i++)
            {
                //计算阶乘
                int result = c.Mult(i);
                //输出结果
                Console.WriteLine(i + "的阶乘为：" + result);
            }
        }
    }
}
