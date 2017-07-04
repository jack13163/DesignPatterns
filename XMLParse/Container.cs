using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParse
{
    /// <summary>
    /// 结点列表
    /// </summary>
    public class Container : XNode
    {
        /// <summary>
        /// 当前容器结点
        /// </summary>
        public List<XNode> Childrens = new List<XNode>();

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="node"></param>
        public Container(string tag)
        {
            this.TagName = tag;
        }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public Container() { }


        public override XNode Remove(XNode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取指定索引处的孩子结点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override XNode GetChild(int index)
        {
            return this.Childrens[index];
        }

        private void Trave(XNode node)
        {
            //遍历当前结点
            Console.WriteLine(node.TagName + "： ");
            //遍历子结点
            foreach(var item in ((Container)node).Childrens)
            {
                if (item is Container)
                {
                    //递归遍历
                    Trave((Container)item);
                }
                else if(item is Node)
                {
                    Console.WriteLine("  " + ((Node)item).TagName + ": " + ((Node)item).Text);
                }
            }
        }

        /// <summary>
        /// 遍历结点
        /// </summary>
        /// <param name="node"></param>
        public override void Traverse(XNode node)
        {
            Trave(node);
        }

        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="node"></param>
        public override void Add(XNode node)
        {
            this.Childrens.Add(node);
        }
    }
}
