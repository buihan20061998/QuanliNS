using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanliNS.Models
{
    public class Role
    {
        [Key]
        [StringLength(10)]
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<Dangky> Dangkys { get; set; }
    }
}