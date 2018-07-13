using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjModel
{
    [Table("Loais")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required]
        public string TenLoai { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required]
        public String TuKhoa { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required]
        public String MoTa { get; set; }
        public virtual ICollection<Sach> Sachs { get; set; }
    }
}
