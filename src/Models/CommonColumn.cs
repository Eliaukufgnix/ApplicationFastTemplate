using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class CommonColumn
    {
        [Key]
        [Column("id")]
        [MaxLength(255)]
        [Description("主键id")]
        public virtual string Id { get; set; }

        [Required]
        [Column("createuser")]
        [MaxLength(100)]
        [Description("创建人")]
        public string CreateUser { get; set; }

        [Required]
        [Column("createdata")]
        [Description("创建日期")]
        public int CreateDate { get; set; }

        [Required]
        [Column("createtime")]
        [Description("创建时间")]
        public int CreateTime { get; set; }

        [Required]
        [Column("loguser")]
        [MaxLength(100)]
        [Description("更新人")]
        public string LogUser { get; set; }

        [Required]
        [Column("logdate")]
        [Description("更新日期")]
        public int LogDate { get; set; }

        [Required]
        [Column("logtime")]
        [Description("更新时间")]
        public int LogTime { get; set; }
    }
}