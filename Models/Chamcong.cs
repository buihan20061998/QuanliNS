using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Chamcong
    {
        //[Key, Column(Order = 1)]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        [Key]
        public int MaNV { get; set; }
        public string Ngay { get; set; }
        public string Doanhso { get; set; }
        public string Nghi { get; set; }
        public Nhanvien Nhanvien { get; set; }
    }
}