namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyAppointMent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Date", c => c.String());
        }
    }
}
