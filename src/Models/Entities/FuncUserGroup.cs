using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// 功能用户组
    /// </summary>
    [Table("funcusergroup")]
    [Description("功能用户组")]
    public class FuncUserGroup : CommonColumn
    {
        /// <summary>
        /// 功能用户组代码
        /// </summary>
        [Column("funcugcode")]
        [MaxLength(100)]
        [Description("功能用户组代码")]
        public string FuncUGCode { get; set; }

        /// <summary>
        /// 功能用户组名称
        /// </summary>
        [Column("funcugname")]
        [MaxLength(255)]
        [Description("功能用户组名称")]
        public string FuncUGName { get; set; }

        /// <summary>
        /// 功能用户组描述
        /// </summary>
        [Column("funcugdesc")]
        [MaxLength(255)]
        [Description("功能用户组描述")]
        public string FuncUGDesc { get; set; }
    }
}
