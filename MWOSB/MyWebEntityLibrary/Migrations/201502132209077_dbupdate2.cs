namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessagesTables",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        cNameSurname = c.String(nullable: false),
                        cMail = c.String(nullable: false),
                        cMessage = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MessagesTables");
        }
    }
}
