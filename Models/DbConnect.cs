namespace QuanliNS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbConnect : DbContext
    {
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Phongban> Phongbans { get; set; }
        public virtual DbSet<Chamcong> Chamcongs { get; set; }
        public virtual DbSet<Tamung> Tamungs { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<Dangky> Dangkys { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public DbConnect()
            : base("name=DbConnect")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
