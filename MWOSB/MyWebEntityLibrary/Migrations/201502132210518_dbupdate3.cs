namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessagesTables", "NameSurname", c => c.String(nullable: false));
            AddColumn("dbo.MessagesTables", "Mail", c => c.String(nullable: false));
            AddColumn("dbo.MessagesTables", "Message", c => c.String(nullable: false));
            DropColumn("dbo.MessagesTables", "cNameSurname");
            DropColumn("dbo.MessagesTables", "cMail");
            DropColumn("dbo.MessagesTables", "cMessage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MessagesTables", "cMessage", c => c.String(nullable: false));
            AddColumn("dbo.MessagesTables", "cMail", c => c.String(nullable: false));
            AddColumn("dbo.MessagesTables", "cNameSurname", c => c.String(nullable: false));
            DropColumn("dbo.MessagesTables", "Message");
            DropColumn("dbo.MessagesTables", "Mail");
            DropColumn("dbo.MessagesTables", "NameSurname");
        }
    }
}
