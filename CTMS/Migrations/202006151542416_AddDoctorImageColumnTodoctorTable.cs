namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorImageColumnTodoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DoctorImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "DoctorImage");
        }
    }
}
