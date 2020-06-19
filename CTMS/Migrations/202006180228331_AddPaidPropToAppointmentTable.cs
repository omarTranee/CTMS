namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaidPropToAppointmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Paid", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Paid");
        }
    }
}
