using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParse
{
    public abstract class XNode : IEnumerable
    {
        /// <summary>
        /// 结点标签名
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public abstract void Add(XNode node);

        /// <summary>
        /// 删除结点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public abstract XNode Remove(XNode node);

        /// <summary>
        /// 获取结点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract XNode GetChild(int index);

        /// <summary>
        /// 遍历
        /// </summary>
        public abstract void Traverse(XNode node);

        /// <summary>
        /// 支持遍历
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
