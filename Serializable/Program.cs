using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace Serializable
{
    class Program
    {
        static void Main(string[] args)
        {
            //对象的序列化
            //1.创建对象，并初始化
            Student stu1 = new Student();
            stu1.StuId = 201403732;
            stu1.Name = "张三";
            stu1.Age = 21;
            stu1.Tel = "18131312586";

            //2.定义格式化类
            IFormatter formatter = new BinaryFormatter();
            //3.定义输出流
            Stream stream = new FileStream("s1.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //4.序列化输出对象stu1到文件中
            formatter.Serialize(stream, stu1);

            //对象的反序列化
            //1.创建文件输入流
            Stream stream1 = new FileStream("s1.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            //2.创建格式化工具类
            IFormatter formatter2 = new BinaryFormatter();
            //3.对象反序列化
            Object obj = formatter2.Deserialize(stream1);
            //4.拆箱
            Student stu2 = (Student)obj;

            //显示学生信息
            stu2.ToString();
        }
    }
}
