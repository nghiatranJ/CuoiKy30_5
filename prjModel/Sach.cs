using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjModel
{
    [Table("Sachs")]
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        [Column(TypeName ="nvarchar")]
        [Required]
        public string TenSach { get; set; }
        [Required]
        [Range(1900,2017)]
        public int NamXB { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required]
        public string NhaXB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public virtual Loai Loai { get; set; }
    }
}
