namespace IIT_Faculties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacultyChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculties", "Designation", c => c.String(maxLength: 60));
            AddColumn("dbo.Faculties", "Qualtification", c => c.String(maxLength: 100));
            AddColumn("dbo.Faculties", "DBLP", c => c.String(maxLength: 60));
            AddColumn("dbo.Faculties", "GoogleScholar", c => c.String(maxLength: 60));
            AddColumn("dbo.Faculties", "Academia", c => c.String(maxLength: 60));
            AddColumn("dbo.Faculties", "ResearchGate", c => c.String(maxLength: 60));
            AddColumn("dbo.Faculties", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Faculties", "JoiningDate");
            DropColumn("dbo.Faculties", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faculties", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Faculties", "JoiningDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Faculties", "Status");
            DropColumn("dbo.Faculties", "ResearchGate");
            DropColumn("dbo.Faculties", "Academia");
            DropColumn("dbo.Faculties", "GoogleScholar");
            DropColumn("dbo.Faculties", "DBLP");
            DropColumn("dbo.Faculties", "Qualtification");
            DropColumn("dbo.Faculties", "Designation");
        }
    }
}
