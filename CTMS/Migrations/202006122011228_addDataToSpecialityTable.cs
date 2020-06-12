namespace CTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataToSpecialityTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                 INSERT INTO Specialities (Name) VALUES (' Gastroenterology and Endoscopy')   
                 INSERT INTO Specialities (Name) VALUES ('General Practice')   
                 INSERT INTO Specialities (Name) VALUES ('General Surgery')   
                 INSERT INTO Specialities (Name) VALUES ('Geriatrics (Old People Health)')   
                 INSERT INTO Specialities (Name) VALUES ('Hepatology (Liver Doctor)')   
                 INSERT INTO Specialities (Name) VALUES ('Hematologys')   
                 INSERT INTO Specialities (Name) VALUES ('Hepatology (Liver Doctor)')   
                 INSERT INTO Specialities (Name) VALUES ('Internal Medicine')   
                 INSERT INTO Specialities (Name) VALUES ('IVF and Infertility')   
                 INSERT INTO Specialities (Name) VALUES ('Laboratories')   
                 INSERT INTO Specialities (Name) VALUES ('Nephrology')   
                 INSERT INTO Specialities (Name) VALUES ('Andrology and Male Infertility')   
                 INSERT INTO Specialities (Name) VALUES ('Audiology')   
                 INSERT INTO Specialities (Name) VALUES ('Cardiology and Thoracic Surgery (Heart & Chest)')   
                 INSERT INTO Specialities (Name) VALUES ('Chest and Respiratory')   
                 INSERT INTO Specialities (Name) VALUES ('Diabetes and Endocrinology')   
                 INSERT INTO Specialities (Name) VALUES ('Diagnostic Radiology (Scan Centers)')   
                 INSERT INTO Specialities (Name) VALUES ('Phoniatrics(Speech)')   
                 INSERT INTO Specialities (Name) VALUES ('Physiotherapy and Sport Injuries')   
                 INSERT INTO Specialities (Name) VALUES ('Plastic Surgery')   
                 INSERT INTO Specialities (Name) VALUES ('Rheumatology')   
                 INSERT INTO Specialities (Name) VALUES ('Spinal Surgery')   
                 INSERT INTO Specialities (Name) VALUES ('Urology(Urinary System)')   
                 INSERT INTO Specialities (Name) VALUES ('Vascular Surgery(Arteries and Vein Surgery)')   
                ");
            
            
            
            
                
                
            
        }
        
        public override void Down()
        {
        }
    }
}
