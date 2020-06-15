namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconfintion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "PhysicianId" });
            AddColumn("dbo.Doctors", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "DoctorInformation", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Phone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Doctors", "Address", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Doctors", "PhysicianId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Doctors", "PhysicianId");
            AddForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "PhysicianId" });
            AlterColumn("dbo.Doctors", "PhysicianId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Doctors", "Address", c => c.String());
            AlterColumn("dbo.Doctors", "Phone", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.Doctors", "DoctorInformation");
            DropColumn("dbo.Doctors", "Price");
            CreateIndex("dbo.Doctors", "PhysicianId");
            AddForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers", "Id");
        }
    }
}
