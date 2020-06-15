namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDoctorTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUsers", "Governorate_Id", "dbo.Governorates");
            DropForeignKey("dbo.AspNetUsers", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.AspNetUsers", new[] { "CityId" });
            DropIndex("dbo.AspNetUsers", new[] { "SpecialityId" });
            DropIndex("dbo.AspNetUsers", new[] { "Governorate_Id" });
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "User_Name");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "CityId");
            DropColumn("dbo.AspNetUsers", "GovermorateId");
            DropColumn("dbo.AspNetUsers", "SpecialityId");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Governorate_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Governorate_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "SpecialityId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "GovermorateId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "CityId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "User_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            CreateIndex("dbo.AspNetUsers", "Governorate_Id");
            CreateIndex("dbo.AspNetUsers", "SpecialityId");
            CreateIndex("dbo.AspNetUsers", "CityId");
            AddForeignKey("dbo.AspNetUsers", "SpecialityId", "dbo.Specialities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "Governorate_Id", "dbo.Governorates", "Id");
            AddForeignKey("dbo.AspNetUsers", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
