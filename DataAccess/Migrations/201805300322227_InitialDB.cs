namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loais",
                c => new
                    {
                        MaLoai = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(nullable: false, maxLength: 4000),
                        TuKhoa = c.String(nullable: false, maxLength: 4000),
                        MoTa = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.Sachs",
                c => new
                    {
                        MaSach = c.Int(nullable: false, identity: true),
                        TenSach = c.String(nullable: false, maxLength: 4000),
                        NamXB = c.Int(nullable: false),
                        NhaXB = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(nullable: false),
                        MaLoai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.Loais", t => t.MaLoai, cascadeDelete: true)
                .Index(t => t.MaLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sachs", "MaLoai", "dbo.Loais");
            DropIndex("dbo.Sachs", new[] { "MaLoai" });
            DropTable("dbo.Sachs");
            DropTable("dbo.Loais");
        }
    }
}
