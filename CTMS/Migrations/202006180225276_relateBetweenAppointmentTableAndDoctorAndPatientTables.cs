namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relateBetweenAppointmentTableAndDoctorAndPatientTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "AppointmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "AppointmentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "AppointmentId");
            DropColumn("dbo.Doctors", "AppointmentId");
        }
    }
}
