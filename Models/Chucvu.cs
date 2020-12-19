using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Chucvu
    {
        [Key]
        public int MaCV { get; set; }
        public string TenCV { get; set; }
        public string LuongCB { get; set; }
        public ICollection<Nhanvien> Nhanviens { get; set; }
    }
}