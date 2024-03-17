using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("func")]
    public class Func : CommonColumn
    {
        [Column("funcpara")]
        [MaxLength(255)]
        public string FuncPara { get; set; }

        [Column("funcname")]
        [MaxLength(255)]
        public string FuncName { get; set; }

        [Column("funcurl")]
        [MaxLength(255)]
        public string FuncUrl { get; set; }

        [Column("funcicon")]
        [MaxLength(255)]
        public string FuncIcon { get; set; }

        [Column("parentid")]
        [MaxLength(255)]
        public string PartentId { get; set; }
    }
}