using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializable
{
    /// <summary>
    /// 这是一个计算器类，我希望在任何地方有且仅有一个该类的实例，因此，想到用到单例模式
    /// </summary>
    public class Calculator : IEquatable<Calculator>
    {
        //为了解决多线程冲突问题，我使用静态初始化方式
        private static Calculator instance = new Calculator();

        /// <summary>
        /// 定义静态构造方法，拒绝外界对其访问
        /// </summary>
        private Calculator()
        {
            i++;
            //设置j的值
            j = i;
        }

        //统计创建的对象的个数
        private static int i = 0;
        //设置判断是否属于同一个对象
        private int j = 0;

        /// <summary>
        /// 公共的访问方法
        /// </summary>
        /// <returns></returns>
        public static Calculator GetInstance()
        {
            Console.WriteLine("我是运算器" + i);
            return instance;
        }

        //定义一个委托，用来定义操作的函数格式
        public delegate double oper(double a, double b);

        /// <summary>
        /// 执行计算操作
        /// </summary>
        /// <param name="o">委托定义的操作方法</param>
        /// <param name="a">方法需要输入的参数</param>
        /// <param name="b"></param>
        /// <returns></returns>
        public void Operate(oper o, double a, double b)
        {

            Console.WriteLine("运算结果为：" + o(a, b));
        }

        /// <summary>
        /// 重写的比较是否相等的方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Calculator other)
        {
            return ((Calculator)other).j == this.j;
        }
    }
}
