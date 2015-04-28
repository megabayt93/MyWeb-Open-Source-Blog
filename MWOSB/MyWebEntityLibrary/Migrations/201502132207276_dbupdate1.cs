namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ContactsTables", "cNameSurname");
            DropColumn("dbo.ContactsTables", "cMail");
            DropColumn("dbo.ContactsTables", "cMessage");
            DropColumn("dbo.ContactsTables", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactsTables", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContactsTables", "cMessage", c => c.String(nullable: false));
            AddColumn("dbo.ContactsTables", "cMail", c => c.String(nullable: false));
            AddColumn("dbo.ContactsTables", "cNameSurname", c => c.String(nullable: false));
        }
    }
}
