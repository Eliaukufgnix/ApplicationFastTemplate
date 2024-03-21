using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("sysuser")]
    [Description("用户信息")]
    public class SysUser : CommonColumn
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Column("account")]
        [MaxLength(255)]
        [Description("账号")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        [MaxLength(255)]
        [Description("密码")]
        public string PassWord { get; set; }

        /// <summary>
        /// 盐值
        /// </summary>
        [Column("salt")]
        [MaxLength(255)]
        [Description("盐值")]
        public string Salt { get; set; }
    }
}