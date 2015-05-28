namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMailPort : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MailsTables", "MailPort", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MailsTables", "MailPort");
        }
    }
}
