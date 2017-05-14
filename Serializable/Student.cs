using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializable
{
    /// <summary>
    /// 支持序列化标识
    /// </summary>
    [Serializable]
    public class Student
    {
        public int StuId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Tel { get; set; }
        public override string ToString()
        {
            Console.WriteLine("我是" + this.Name + "今年" + this.Age + "岁");
            return base.ToString();
        }
    }
}
