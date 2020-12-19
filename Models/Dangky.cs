using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Dangky
    {
        [Key]
        public string Email { get; set; }
        [Required(ErrorMessage ="Tên đăng nhập là bắt buộc")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
        [Required]
        [StringLength(10)]
        public string RoleID { get; set; }
        public Role Role { get; set; }
    }
}