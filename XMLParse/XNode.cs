using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParse
{
    public abstract class XNode
    {
        //结点标签名
        public string TagName { get; set; }

        //结点内部内容
        public object Value { get; set; }

        public XNode()
        {
        }
    }
}
