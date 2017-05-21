using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XMLParse
{
    /// <summary>
    /// Xml帮助类，完成Xml的增删改查操作
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 获取匹配结果
        /// </summary>
        /// <param name="tagname">标签名字</param>
        /// <param name="path">数据源的路径</param>
        /// <returns></returns>
        public static List<string> getMatchesByTagName(string tagname, string path)
        {
            List<string> results = new List<string>();
            //模式串
            string pattern = @"<" + tagname + ">.*</" + tagname + ">";
            //新建匹配器
            Regex regex = new Regex(pattern);

            //读入文本字符串
            string content = File.ReadAllText(path, Encoding.UTF8);
            //使用匹配器进行匹配
            MatchCollection mc = regex.Matches(content);
            //获取结果
            foreach (var item in mc)
            {
                //去除标签
                string temp = item.ToString().Replace("<" + tagname + ">", "").Replace("</" + tagname + ">", "");
                results.Add(temp);
            }
            return results;
        }

        /// <summary>
        /// 从指定的xml文件中读取xml字符串
        /// </summary>
        /// <param name="path"></param>
        /// <returns>xml字符串</returns>
        public static string ReadAllText(string path)
        {
            //读取文档
            string content = File.ReadAllText(path);
            //获取根节点
            return content;
        }

        /// <summary>
        /// 匹配所有的标签
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns></returns>
        public static XNode CreateTree(string text)
        {
            //模式串，匹配根节点
            string pattern = @"(<[a-zA-Z]+>)|(</[a-zA-Z]+>)";
            //正则匹配器
            Regex regex = new Regex(pattern);
            //获取匹配结果
            string result = regex.Match(text).Value;
            //返回截取后的字符串
            MatchCollection mc = regex.Matches(text);
            //获取集合个数
            int len = mc.Count;

            //获取字符队列
            Queue<string> charqueue = new Queue<string>();
            //字符入队
            for (int i = 0; i < len; i++)
            {
                charqueue.Enqueue(mc[i].ToString());
            }

            //定义标签栈
            Stack<string> tagStack = new Stack<string>();

            //取第一个元素
            string str = charqueue.Dequeue();
            //创建根节点
            Container root = new Container(str.Substring(1, str.Length - 2));

            //当前创建的结点
            XNode node = root;

            //循环构建树
            while (charqueue.Count > 0)
            {
                //取下个字符
                string next = charqueue.Dequeue();

                XNode newnode = null;

                if (!str.StartsWith("</") && !next.StartsWith("</"))
                {
                    //当为标签时，入标签栈
                    tagStack.Push(str);
                    //创建新的结点
                    newnode = new Container(str);  //创建容器

                    //将新建的结点加入到当前容器中
                    ((Container)node).Add(newnode);
                    node = newnode;//更新容器
                }
                else if(!str.StartsWith("</"))
                {
                    //新建叶子结点
                    newnode = new Node(str, "");
                    //将新建的结点加入到当前容器中
                    ((Container)node).Add(newnode);
                }

                str = next;
            }
            return root;
        }
    }
}
