using System.Collections.Generic;

namespace Models
{
    public class FuncVO
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 功能菜单名称
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 有子节点为0，无子节点为1
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 功能菜单图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 可以打开的页面值为：_iframe，否则为空
        /// </summary>
        public string openType { get; set; }

        /// <summary>
        /// 页面链接
        /// </summary>
        public string href { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<FuncVO> children { get; set; }
    }
}