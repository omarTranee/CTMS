namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorTableToDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "CityId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "GovermorateId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "SpecialityId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Governorate_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CityId");
            CreateIndex("dbo.AspNetUsers", "SpecialityId");
            CreateIndex("dbo.AspNetUsers", "Governorate_Id");
            AddForeignKey("dbo.AspNetUsers", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "Governorate_Id", "dbo.Governorates", "Id");
            AddForeignKey("dbo.AspNetUsers", "SpecialityId", "dbo.Specialities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.AspNetUsers", "Governorate_Id", "dbo.Governorates");
            DropForeignKey("dbo.AspNetUsers", "CityId", "dbo.Cities");
            DropIndex("dbo.AspNetUsers", new[] { "Governorate_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "SpecialityId" });
            DropIndex("dbo.AspNetUsers", new[] { "CityId" });
            DropColumn("dbo.AspNetUsers", "Governorate_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "SpecialityId");
            DropColumn("dbo.AspNetUsers", "GovermorateId");
            DropColumn("dbo.AspNetUsers", "CityId");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "User_Name");
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
