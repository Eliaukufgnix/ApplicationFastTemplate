using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class CommonColumn
    {
        [Key]
        [Column("id")]
        [MaxLength(255)]
        public string Id { get; set; }

        [Required]
        [Column("createuser")]
        [MaxLength(100)]
        public string CreateUser { get; set; }

        [Required]
        [Column("createdata")]
        public int CreateDate { get; set; }

        [Required]
        [Column("createtime")]
        public int CreateTime { get; set; }

        [Required]
        [Column("loguser")]
        [MaxLength(100)]
        public string LogUser { get; set; }

        [Required]
        [Column("logdate")]
        public int LogDate { get; set; }

        [Required]
        [Column("logtime")]
        public int LogTime { get; set; }
    }
}