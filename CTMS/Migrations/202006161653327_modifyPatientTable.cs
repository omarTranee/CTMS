namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyPatientTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
