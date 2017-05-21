using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Container : Calculator
    {
        //容器计算阶乘
        public override int Mult(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("无法计算负数的阶乘");
                return -1;
            }
            else if (n == 0 || n == 1)
            {
                //0和1的阶乘为1
                return 1;
            }
            else
            {
                //递归计算阶乘
                return n * Mult(n - 1);
            }
        }
    }
}
