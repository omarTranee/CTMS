namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropStringDateWithValidationInAppointmentClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Date");
        }
    }
}
