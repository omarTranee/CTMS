namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Gender");
        }
    }
}
