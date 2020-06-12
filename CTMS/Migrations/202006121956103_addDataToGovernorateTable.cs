namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataToGovernorateTable : DbMigration
    {
        public override void Up()
        {

            Sql(@"

                INSERT INTO Governorates(Name) VALUES  ('Cairo')
                INSERT INTO Governorates(Name) VALUES  ('Giza')
                INSERT INTO Governorates(Name) VALUES  ('Alexandria')
                INSERT INTO Governorates(Name) VALUES  ('Dakahlia')
                INSERT INTO Governorates(Name) VALUES ('Red Sea')
                INSERT INTO Governorates(Name) VALUES ('Beheira')
                INSERT INTO Governorates(Name) VALUES ('Fayoum')
                INSERT INTO Governorates(Name) VALUES ('Gharbiya')
                INSERT INTO Governorates(Name) VALUES ('Ismailia')
                INSERT INTO Governorates(Name) VALUES ('Monofia')
                INSERT INTO Governorates(Name) VALUES ('Minya')
                INSERT INTO Governorates(Name) VALUES ('Qaliubiya')
                INSERT INTO Governorates(Name) VALUES ('New Valley')
                INSERT INTO Governorates(Name) VALUES ('Suez')
                INSERT INTO Governorates(Name) VALUES ('Aswan')
                INSERT INTO Governorates(Name) VALUES ('Assiut')
                INSERT INTO Governorates(Name) VALUES ('Beni Suef')
                INSERT INTO Governorates(Name) VALUES ('Port Said')
                INSERT INTO Governorates(Name) VALUES ('Damietta')
                INSERT INTO Governorates(Name) VALUES ('Sharkia')
                INSERT INTO Governorates(Name) VALUES ('South Sinai')
                INSERT INTO Governorates(Name) VALUES ('Kafr Al sheikh')
                INSERT INTO Governorates(Name) VALUES ('Matrouh')
                INSERT INTO Governorates(Name) VALUES ('Luxor')
                INSERT INTO Governorates(Name) VALUES ('Qena')
                INSERT INTO Governorates(Name) VALUES ('North Sinai')
                INSERT INTO Governorates(Name) VALUES ('Sohag')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
