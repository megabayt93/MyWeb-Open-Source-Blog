namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticlesTables", "SeoTitle", c => c.String());
            AddColumn("dbo.FilesTables", "SeoTitle", c => c.String());
            AddColumn("dbo.WhatIDoTables", "SeoTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WhatIDoTables", "SeoTitle");
            DropColumn("dbo.FilesTables", "SeoTitle");
            DropColumn("dbo.ArticlesTables", "SeoTitle");
        }
    }
}
