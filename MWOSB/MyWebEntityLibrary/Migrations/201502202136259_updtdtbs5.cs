namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updtdtbs5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentsTables", "ContentTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommentsTables", "ContentTitle");
        }
    }
}
