namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        SpecialityId = c.Int(nullable: false),
                        PhysicianId = c.String(maxLength: 128),
                        CityId = c.Int(nullable: false),
                        GovernorateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Governorates", t => t.GovernorateId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PhysicianId)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId, cascadeDelete: true)
                .Index(t => t.SpecialityId)
                .Index(t => t.PhysicianId)
                .Index(t => t.CityId)
                .Index(t => t.GovernorateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Doctors", "GovernorateId", "dbo.Governorates");
            DropForeignKey("dbo.Doctors", "CityId", "dbo.Cities");
            DropIndex("dbo.Doctors", new[] { "GovernorateId" });
            DropIndex("dbo.Doctors", new[] { "CityId" });
            DropIndex("dbo.Doctors", new[] { "PhysicianId" });
            DropIndex("dbo.Doctors", new[] { "SpecialityId" });
            DropTable("dbo.Doctors");
        }
    }
}
