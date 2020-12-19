using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Luong
    {
        [Key]
        public int MaNV { get; set; }
        public string Thang { get; set; }
        public string Tamung { get; set; }
        public string Thuong { get; set; }
        public string Tienluong { get; set; }
        public Nhanvien Nhanvien { get; set; }
    }
}