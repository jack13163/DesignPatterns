using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Leaf : Calculator
    {
        //叶子结点计算阶乘
        public override int Mult(int n)
        {
            return n;
        }
    }
}
