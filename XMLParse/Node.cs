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
        //叶子节点构造方法
        public Node(string tag, object value)
        {
            this.TagName = tag;
            this.Value = value;
        }
    }
}
