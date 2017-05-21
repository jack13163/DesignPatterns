using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLParse;

namespace TestXmlHelper
{
    [TestClass]
    public class UnitTest1
    {
        public static string path = @"E:\AppSurceCode\DesignPatterns\XMLParse\TestXmlHelper\files/regdata.xml";
        string text = XmlHelper.ReadAllText(path);

        [TestMethod]
        public void TestGetValueByTagName()
        {
            string tag = "CODE";
            List<string> lists = XmlHelper.getMatchesByTagName(tag, path);
            //遍历集合
            foreach (string str in lists)
            {
                Console.WriteLine(str);
            }
        }

        [TestMethod]
        public void TestNodeCRUD()
        {
            XNode node1 = new Node("name", "张三");
            XNode node2 = new Node("sex", "男");

            Container node3 = new Container("student");
            node3.Add(node1);
            node3.Add(node2);

            Console.WriteLine("-----------------输出node3中的所有子节点----------------");
            foreach(var item in node3)
            {
                Console.WriteLine(((Node)item).TagName + ":" + ((Node)item).Value);
            }

            Console.WriteLine("-----------------查找node3中的节点----------------");
            node3.Query("name").ForEach(it => Console.WriteLine(it.Value));
            node3.Query("sex").ForEach(it => Console.WriteLine(it.Value));


            Console.WriteLine("-----------------输出修改之后的node3中的所有子节点----------------");
            node3.Modefy("name", "李四");
            node3.Modefy("sex", "女");
            foreach (var item in node3)
            {
                Console.WriteLine(((Node)item).TagName + ":" + ((Node)item).Value);
            }

            Console.WriteLine("-----------------输出删除之后的node3中的所有子节点----------------");
            node3.Delete("name"); 
            foreach (var item in node3)
            {
                Console.WriteLine(((Node)item).TagName + ":" + ((Node)item).Value);
            }
        }
        
        [TestMethod]
        public void TestReadAllText()
        {
            Console.WriteLine(text);
        }

        [TestMethod]
        public void TestCreateTree()
        {
            Container root = (Container)(XmlHelper.CreateTree(text));
            Console.WriteLine(root.TagName);
            foreach (var item in root)
            {
                Console.WriteLine(item);
            }
        }
    }
}
