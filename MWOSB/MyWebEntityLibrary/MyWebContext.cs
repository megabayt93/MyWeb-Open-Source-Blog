using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MyWebEntityLibrary.ArticlesEntity;
using MyWebEntityLibrary.FilesEntity;
using MyWebEntityLibrary.WhatIDoEntity;
using MyWebEntityLibrary.CommentsEntity;
using MyWebEntityLibrary.AdminInformationsEntity;
using MyWebEntityLibrary.SocialMediasEntity;
using MyWebEntityLibrary.ContactsEntity;
using MyWebEntityLibrary.MailEntity;
using MyWebEntityLibrary.MediasEntity;
using MyWebEntityLibrary.MessageEntity;
using MyWebEntityLibrary.SeoContent;

namespace MyWebEntityLibrary
{
    public class MyWebContext : DbContext
    {

        public MyWebContext()
        {
            Database.SetInitializer<MyWebContext>(new MyWebInitializer());
        }

        public DbSet<ArticlesTable> Articles { get; set; }

        public DbSet<FilesTable> Files { get; set; }

        public DbSet<WhatIDoTable> WhatIDos { get; set; }

        public DbSet<CommentsTable> Comments { get; set; }

        public DbSet<AdminInformationsTable> AdminInformations { get; set; }

        public DbSet<SocialMediasTable> SocialMedias { get; set; }

        public DbSet<ContactsTable> Contacts { get; set; }

        public DbSet<MessagesTable> Messages { get; set; }

        public DbSet<MediasTable> Medias { get; set; }

        public DbSet<MailsTable> Mails { get; set; }

        public DbSet<SeoContentsTable> SeoContentsTables { get; set; } 


    }
}
