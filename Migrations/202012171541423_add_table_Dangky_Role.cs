namespace QuanliNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_Dangky_Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dangkies",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleID = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dangkies", "RoleID", "dbo.Roles");
            DropIndex("dbo.Dangkies", new[] { "RoleID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Dangkies");
        }
    }
}
