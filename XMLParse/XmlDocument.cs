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
    /// 实现Xml结点的增删改查操作
    /// </summary>
    public class XmlDocument
    {
        /// <summary>
        /// 头结点
        /// </summary>
        public XNode Head { get; set; }

        /// <summary>
        /// 符号分析栈
        /// </summary>
        Stack<XNode> TagStack = new Stack<XNode>();

        /// <summary>
        /// 从指定的xml文件中读取xml字符串
        /// </summary>
        /// <param name="path"></param>
        /// <returns>xml字符串</returns>
        public string ReadAllText(string path)
        {
            //读取文档
            string content = File.ReadAllText(path);
            //获取根节点
            return content;
        }

        /// <summary>
        /// 建立解析树
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Container Parse(string str)
        {
            int i = 0;
            //识别标志
            bool flag = false;
            //标签
            StringBuilder tag = new StringBuilder();
            //文本
            StringBuilder text = new StringBuilder();
            //根节点
            Container root = null;

            //过滤掉其他字符
            str = str.Replace("\n", "").Replace("\r", "").Replace(" ", "");

            //过滤掉xml版本声明
            if (str[i] == '<' && str[i + 1] == '?')
            {
                //设置标记开关，开始读取标签
                flag = true;
            }
            while (flag)
            {
                if (str[i] == '>')
                {
                    flag = false;
                }
                i++;
            }

            //字符串的总长度
            int len = str.Length;

            do
            {
                if (str[i] == '<')
                {
                    //设置标记开关，开始读取标签
                    flag = true;
                }

                if (flag)
                {
                    //获取一个结点
                    while (flag)
                    {
                        //检测到结束标志，关闭开关
                        if (str[i] == '>')
                        {
                            flag = false;
                        }

                        //如果未结束
                        tag.Append(str[i]);
                        i++;
                    }

                    bool match = false;

                    if (TagStack.Count > 0)
                    {
                        //判断当前结点是否和栈顶结点匹配
                        match = IsMatch(TagStack.Peek().TagName, tag.ToString());
                    }

                    if (match)
                    {
                        //匹配
                        TagStack.Pop();

                        //清tag
                        tag.Clear();
                    }
                    else
                    {
                        //不匹配，即又有新的开始标签入栈

                        //检测是否有文本，即判断是否为叶子结点
                        while (str[i] != '<')
                        {
                            text.Append(str[i]);
                            i++;
                        }

                        //建立解析树
                        if (text.Length != 0)
                        {
                            //新建叶子节点
                            Node node = new Node(tag.ToString(), text.ToString());

                            //建立树形结构
                            TagStack.Peek().Add(node);

                            //入栈
                            TagStack.Push(node);

                            //清tag
                            text.Clear();
                        }
                        else
                        {
                            //容器结点
                            //root
                            if (TagStack.Count == 0)
                            {
                                //建立根节点
                                root = new Container(tag.ToString());
                                
                                //根节点入栈
                                TagStack.Push(root);
                            }
                            else
                            {
                                //建立容器结点
                                Container container = new Container(tag.ToString());

                                //建立树形结构
                                TagStack.Peek().Add(container);

                                //入栈
                                TagStack.Push(container);
                            }
                        }
                    }
                    tag.Clear();
                }
            } while (TagStack.Count != 0 || i < len);
            return root;
        }

        /// <summary>
        /// 判断标签是否匹配
        /// </summary>
        /// <param name="begin">开始标签</param>
        /// <param name="end">结束标签</param>
        /// <returns>匹配是否成功</returns>
        public bool IsMatch(string begin, string end)
        {
            string tmp = end[0].ToString() + end.Substring(2);
            return end[1] == '/' && tmp.Equals(begin);
        }
    }
}
