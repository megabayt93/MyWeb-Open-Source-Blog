namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailsTables",
                c => new
                    {
                        MailId = c.Int(nullable: false, identity: true),
                        MailSmtp = c.String(nullable: false),
                        MailAdress = c.String(nullable: false),
                        MailPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MailsTables");
        }
    }
}
