namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientPicTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientPics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        PicUrl = c.String(),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientPics", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientPics", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PatientPics", new[] { "PatientId" });
            DropIndex("dbo.PatientPics", new[] { "DoctorId" });
            DropTable("dbo.PatientPics");
        }
    }
}
