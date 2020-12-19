using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Tamung
    {
        [Key]
        public int MaNV { get; set; }
        public string NgayTU { get; set; }
        public string Sotien { get; set; }
        public Nhanvien Nhanvien { get; set; }
    }
}