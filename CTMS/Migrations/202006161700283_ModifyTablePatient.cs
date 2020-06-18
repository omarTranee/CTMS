namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTablePatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Patients", "GovernorateId", "dbo.Governorates");
            DropIndex("dbo.Patients", new[] { "GovernorateId" });
            DropIndex("dbo.Patients", new[] { "CityId" });
            AlterColumn("dbo.Patients", "GovernorateId", c => c.Int(nullable:true));
            AlterColumn("dbo.Patients", "CityId", c => c.Int(nullable: true));
            CreateIndex("dbo.Patients", "GovernorateId");
            CreateIndex("dbo.Patients", "CityId");
            AddForeignKey("dbo.Patients", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Patients", "GovernorateId", "dbo.Governorates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "GovernorateId", "dbo.Governorates");
            DropForeignKey("dbo.Patients", "CityId", "dbo.Cities");
            DropIndex("dbo.Patients", new[] { "CityId" });
            DropIndex("dbo.Patients", new[] { "GovernorateId" });
            AlterColumn("dbo.Patients", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "GovernorateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "CityId");
            CreateIndex("dbo.Patients", "GovernorateId");
            AddForeignKey("dbo.Patients", "GovernorateId", "dbo.Governorates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
