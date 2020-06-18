namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientTableAsUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                        BloodType = c.Int(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        Patient_Id = c.String(maxLength: 128),
                        GovernorateId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Governorates", t => t.GovernorateId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Patient_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.GovernorateId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "GovernorateId", "dbo.Governorates");
            DropForeignKey("dbo.Patients", "CityId", "dbo.Cities");
            DropIndex("dbo.Patients", new[] { "CityId" });
            DropIndex("dbo.Patients", new[] { "GovernorateId" });
            DropIndex("dbo.Patients", new[] { "Patient_Id" });
            DropTable("dbo.Patients");
        }
    }
}
