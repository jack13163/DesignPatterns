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
    public class Container : XNode, IEnumerable
    {
        //结点列表
        public List<XNode> nodes = new List<XNode>();

        //只包含含参构造函数
        public Container(string tag)
        {
            this.TagName = tag;
            //向公共接口传递值
            this.Value = nodes;
        }

        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="node">子结点</param>
        public void Add(XNode node)
        {
            if (node != null)
            {
                this.nodes.Add(node);
            }
        }

        /// <summary>
        /// 删除结点
        /// </summary>
        /// <param name="tag">待移除的结点名称</param>
        public void Delete(string tag)
        {
            if (this.nodes.Exists(it => it.TagName.Equals(tag)))
            {
                //循环移除所有的结点元素
                foreach (var item in this.nodes.FindAll(it => it.TagName.Equals(tag)))
                {
                    this.nodes.Remove(item);
                }
            }
            else
            {
                throw new Exception("不存在当前结点");
            }
        }

        /// <summary>
        /// 修改结点
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        public void Modefy(string tag, object value)
        {
            if (this.nodes.Exists(it => it.TagName.Equals(tag)))
            {
                //循环修改所有的结点元素
                foreach (var item in this.nodes.FindAll(it => it.TagName.Equals(tag)))
                {
                    item.Value = value;
                }
            }
            else
            {
                throw new Exception("不存在当前结点");
            }
        }

        /// <summary>
        /// 查询结点
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<XNode> Query(string tag)
        {
            //若结点存在
            if (this.nodes.Exists(it => it.TagName.Equals(tag)))
            {
                return this.nodes.FindAll(it => it.TagName.Equals(tag));
            }
            return null;
        }
        
        /// <summary>
        /// 支持foreach遍历
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return nodes.GetEnumerator();
        }
    }
}
