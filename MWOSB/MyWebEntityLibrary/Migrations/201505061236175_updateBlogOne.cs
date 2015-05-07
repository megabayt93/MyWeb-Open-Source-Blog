namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlogOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMediasTables", "LinkedIn", c => c.String());
            AddColumn("dbo.SocialMediasTables", "Github", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialMediasTables", "Github");
            DropColumn("dbo.SocialMediasTables", "LinkedIn");
        }
    }
}
