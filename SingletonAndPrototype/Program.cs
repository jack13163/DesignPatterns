using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serializable
{
    class Program
    {
        public static Serializable.Calculator.oper o;

        static void Main(string[] args)
        {
            //获取运算器对象
            Calculator cal = Calculator.GetInstance();
            //将add方法绑定到委托上
            o = new Serializable.Calculator.oper(add);
            //执行方法
            cal.Operate(o, 1.2, 8);

            //再次调用运算器对象
            Calculator cal1 = Calculator.GetInstance();
            //将减法操作绑定到委托上
            o = new Calculator.oper(sub);
            //执行减法操作
            cal1.Operate(o, 8, 9);

            //通过匿名方法实现乘法
            Calculator cal2 = Calculator.GetInstance();
            //绑定匿名方法
            o = delegate(double a, double b)
            {
                Console.WriteLine("正在执行" + a + "*" + b);
                return a * b;
            };
            //执行乘法操作
            cal2.Operate(o, 58, 9);

            ////现在因为特殊原因，我需要另外一个计算器，由C#反射方法实现
            ////1.获取当前代码所在的程序集
            //Assembly ass = Assembly.GetExecutingAssembly();
            ////2.创建一个对象,并将结果强制转换为Calculator对象
            //Calculator cal3 = (Calculator)ass.CreateInstance("SingletonAndPrototype.Calculator", true);
            ////通过lamda表达式，实现除法
            //cal3.Operate((a, b) => a / (b * 1.0), 56, 8);
            ////上述方法是失败的，因为构造方法是私有的，当执行反射时，需要一个公有的构造方法。

            //通过下面的方法，反射获取私有构造函数
            //1.获取类的类型
            Type type = typeof(Calculator);
            //2.获取所有的构造方法
            System.Reflection.ConstructorInfo[] constructorInfoArray = type.GetConstructors(System.Reflection.BindingFlags.Instance
                            | System.Reflection.BindingFlags.NonPublic
                            | System.Reflection.BindingFlags.Public);
            //3.定义并查找无参构造函数
            ConstructorInfo constructor = null;
            foreach(var item in constructorInfoArray)
            {
                //由于反射需要无参的构造函数，因此需要检查构造函数中是否含有无参的构造函数
                if (item.GetParameters().Length == 0)
                {
                    constructor = item;
                    break;
                }
            }
            //如果不存在无参构造函数
            if (constructor == null)
            {
                throw new Exception("不含有无参构造函数!");
            }
            //创建计算器对象
            Calculator cal4 = (Calculator)constructor.Invoke(null);
            //通过lamda表达式，实现除法
            cal4.Operate((a, b) => a / (b * 1.0), 56, 8);

            //上面的四个对象中，比较这四个对象是不是同一个对象
            Console.WriteLine("比较前三个对象是否相等:" + (cal == cal1 && cal == cal2 && cal1 == cal2));
            //比较第四个对象是否和前三个对象是同一个对象
            Console.WriteLine("比较第四个对象是否和前三个对象是同一个对象:" + (cal == cal4));

            //上面的四个对象中，比较这四个对象是不是同一个对象
            Console.WriteLine("比较前三个对象是否Equal:" + (cal.Equals(cal1) && cal.Equals(cal2) && cal1.Equals(cal2)));
            //比较第四个对象是否和前三个对象是同一个对象
            Console.WriteLine("比较第四个对象是否和前三个对象Equal:" + (cal.Equals(cal4)));
        }

        /// <summary>
        /// 加法操作
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double add(double a, double b)
        {
            Console.WriteLine("正在执行" + a + "+" + b);
            return a + b;
        }

        /// <summary>
        /// 减法操作
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double sub(double a, double b)
        {
            Console.WriteLine("正在执行" + a + "-" + b);
            return a - b;
        }
    }
}
