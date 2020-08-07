namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Products", "PatientId", "dbo.Patients");
            DropIndex("dbo.Products", new[] { "DoctorId" });
            DropIndex("dbo.Products", new[] { "PatientId" });
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        PicUrl = c.String(),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Products", "PatientId");
            CreateIndex("dbo.Products", "DoctorId");
            AddForeignKey("dbo.Products", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
