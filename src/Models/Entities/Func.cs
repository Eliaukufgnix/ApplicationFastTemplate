using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// 菜单功能
    /// </summary>
    [Table("func")]
    [Description("菜单功能")]
    public class Func : CommonColumn
    {
        /// <summary>
        /// 菜单代码
        /// </summary>
        [Column("funccode")]
        [MaxLength(255)]
        [Description("菜单代码")]
        public string FuncCode { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("funcname")]
        [MaxLength(255)]
        [Description("菜单名称")]
        public string FuncName { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [Column("funcurl")]
        [MaxLength(255)]
        [Description("Url")]
        public string FuncUrl { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Column("funcicon")]
        [MaxLength(255)]
        [Description("图标")]
        public string FuncIcon { get; set; }

        /// <summary>
        /// 父节点：ROOT代表根节点
        /// </summary>
        [Column("parentid")]
        [MaxLength(255)]
        [Description("父节点：ROOT代表根节点")]
        public string ParentId { get; set; }
    }
}