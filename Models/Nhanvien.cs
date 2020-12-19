using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Nhanvien
    {
        [Key]
        public int MaNV { get; set; }
        [Required, MaxLength(30)]
        public string HoTen { get; set; }
        public string NamSinh { get; set; }
        public string Diachi { get; set; }
        public string Gioitinh { get; set; }
        public string SoCMND { get; set; }
        [MinLength(8), MaxLength(15)]
        public string SoDT { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public int MaPB { get; set; }
        public int MaCV { get; set; }
        public string Quyen { get; set; }
        public Chucvu Chucvu { get; set; }
        public Phongban Phongban { get; set; }
        public ICollection<Chamcong> Chamcongs { get; set; }
        public ICollection<Tamung> Tamungs { get; set; }
        public ICollection<Luong> Luongs { get; set; }
    }
}