namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediasTables",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        MediaUrl = c.String(),
                    })
                .PrimaryKey(t => t.MediaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MediasTables");
        }
    }
}
