namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTablesCityandGovernorate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Governorate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Governorates", t => t.Governorate_Id)
                .Index(t => t.Governorate_Id);
            
            CreateTable(
                "dbo.Governorates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "Governorate_Id", "dbo.Governorates");
            DropIndex("dbo.Cities", new[] { "Governorate_Id" });
            DropTable("dbo.Governorates");
            DropTable("dbo.Cities");
        }
    }
}
