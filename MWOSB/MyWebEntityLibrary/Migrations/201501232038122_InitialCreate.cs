namespace MyWebEntityLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminInformationsTables",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false),
                        AdminPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.ArticlesTables",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(nullable: false, maxLength: 100),
                        ArticleContent = c.String(),
                        Image = c.String(),
                        ArticleAuthor = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ArticleTags = c.String(nullable: false),
                        PublishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            CreateTable(
                "dbo.CommentsTables",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Comment = c.String(nullable: false),
                        Area = c.String(),
                        ContentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.ContactsTables",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactInformation = c.String(),
                        cNameSurname = c.String(nullable: false),
                        cMail = c.String(nullable: false),
                        cMessage = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.FilesTables",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileTitle = c.String(nullable: false, maxLength: 100),
                        FileContent = c.String(),
                        FileImage = c.String(),
                        FileStream = c.String(),
                        FileAuthor = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FileTags = c.String(nullable: false),
                        PublishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID);
            
            CreateTable(
                "dbo.SocialMediasTables",
                c => new
                    {
                        SocialMediasId = c.Int(nullable: false, identity: true),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Youtube = c.String(),
                        Instagram = c.String(),
                        Banner = c.String(),
                        Explanation = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.SocialMediasId);
            
            CreateTable(
                "dbo.WhatIDoTables",
                c => new
                    {
                        WhatIDoID = c.Int(nullable: false, identity: true),
                        WhatIDoTitle = c.String(nullable: false, maxLength: 100),
                        WhatIDoContent = c.String(),
                        WhatIDoImage = c.String(),
                        Date = c.DateTime(nullable: false),
                        WhatIDoTags = c.String(nullable: false),
                        PublishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WhatIDoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WhatIDoTables");
            DropTable("dbo.SocialMediasTables");
            DropTable("dbo.FilesTables");
            DropTable("dbo.ContactsTables");
            DropTable("dbo.CommentsTables");
            DropTable("dbo.ArticlesTables");
            DropTable("dbo.AdminInformationsTables");
        }
    }
}
