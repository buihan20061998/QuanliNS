namespace QuanliNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chamcongs",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        Ngay = c.String(),
                        Doanhso = c.String(),
                        Nghi = c.String(),
                        Nhanvien_MaNV = c.Int(),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.Nhanviens", t => t.Nhanvien_MaNV)
                .Index(t => t.Nhanvien_MaNV);
            
            CreateTable(
                "dbo.Nhanviens",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 30),
                        NamSinh = c.String(),
                        Diachi = c.String(),
                        Gioitinh = c.String(),
                        SoCMND = c.String(),
                        SoDT = c.String(maxLength: 15),
                        Email = c.String(nullable: false),
                        MaPB = c.Int(nullable: false),
                        MaCV = c.Int(nullable: false),
                        Quyen = c.String(),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.Chucvus", t => t.MaCV, cascadeDelete: true)
                .ForeignKey("dbo.Phongbans", t => t.MaPB, cascadeDelete: true)
                .Index(t => t.MaPB)
                .Index(t => t.MaCV);
            
            CreateTable(
                "dbo.Chucvus",
                c => new
                    {
                        MaCV = c.Int(nullable: false, identity: true),
                        TenCV = c.String(),
                        LuongCB = c.String(),
                    })
                .PrimaryKey(t => t.MaCV);
            
            CreateTable(
                "dbo.Luongs",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        Thang = c.String(),
                        Tamung = c.String(),
                        Thuong = c.String(),
                        Tienluong = c.String(),
                        Nhanvien_MaNV = c.Int(),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.Nhanviens", t => t.Nhanvien_MaNV)
                .Index(t => t.Nhanvien_MaNV);
            
            CreateTable(
                "dbo.Phongbans",
                c => new
                    {
                        MaPB = c.Int(nullable: false, identity: true),
                        TenPB = c.String(),
                        DiaDiem = c.String(),
                        SoDT = c.String(),
                    })
                .PrimaryKey(t => t.MaPB);
            
            CreateTable(
                "dbo.Tamungs",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        NgayTU = c.String(),
                        Sotien = c.String(),
                        Nhanvien_MaNV = c.Int(),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.Nhanviens", t => t.Nhanvien_MaNV)
                .Index(t => t.Nhanvien_MaNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tamungs", "Nhanvien_MaNV", "dbo.Nhanviens");
            DropForeignKey("dbo.Nhanviens", "MaPB", "dbo.Phongbans");
            DropForeignKey("dbo.Luongs", "Nhanvien_MaNV", "dbo.Nhanviens");
            DropForeignKey("dbo.Nhanviens", "MaCV", "dbo.Chucvus");
            DropForeignKey("dbo.Chamcongs", "Nhanvien_MaNV", "dbo.Nhanviens");
            DropIndex("dbo.Tamungs", new[] { "Nhanvien_MaNV" });
            DropIndex("dbo.Luongs", new[] { "Nhanvien_MaNV" });
            DropIndex("dbo.Nhanviens", new[] { "MaCV" });
            DropIndex("dbo.Nhanviens", new[] { "MaPB" });
            DropIndex("dbo.Chamcongs", new[] { "Nhanvien_MaNV" });
            DropTable("dbo.Tamungs");
            DropTable("dbo.Phongbans");
            DropTable("dbo.Luongs");
            DropTable("dbo.Chucvus");
            DropTable("dbo.Nhanviens");
            DropTable("dbo.Chamcongs");
        }
    }
}
