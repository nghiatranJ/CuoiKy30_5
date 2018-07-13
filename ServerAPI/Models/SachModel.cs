using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class SachModel
    {
        [Required]
        public int MaSach { get; set; }
        [Required]
        public string TenSach { get; set; }
        [Required]
        [Range(1900, 2017)]
        public int NamXB { get; set; }
        [Required]
        public string NhaXB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int MaLoai { get; set; }
    }
}