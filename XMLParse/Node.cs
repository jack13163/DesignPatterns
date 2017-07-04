using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace XMLParse
{
    /// <summary>
    /// 叶子结点
    /// </summary>
    public class Node : XNode
    {
        public Node()
        { }

        public string Text { get; set; }

        public Node(string tag, string text)
        {
            this.TagName = tag;
            this.Text = text;
        }

        public override XNode Remove(XNode node)
        {
            throw new NotImplementedException();
        }

        public override XNode GetChild(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 遍历叶子结点
        /// </summary>
        public override void Traverse(XNode node)
        {
            Console.Write(node.TagName);
        }

        public override void Add(XNode node)
        {
            throw new NotImplementedException();
        }
    }
}
