using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Phongban
    {
        [Key]
        public int MaPB { get; set; }
        public string TenPB { get; set; }
        public string DiaDiem { get; set; }
        public string SoDT { get; set; }
        public ICollection<Nhanvien> Nhanviens { get; set; }
    }
}