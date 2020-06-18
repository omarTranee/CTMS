namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailPropToPatientAndDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DoctorEmail", c => c.String());
            AddColumn("dbo.Patients", "PatientEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PatientEmail");
            DropColumn("dbo.Doctors", "DoctorEmail");
        }
    }
}
