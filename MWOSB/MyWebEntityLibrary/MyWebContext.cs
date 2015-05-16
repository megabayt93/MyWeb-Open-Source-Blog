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
using MyWebEntityLibrary.MediasEntity;
using MyWebEntityLibrary.MessageEntity;
namespace MyWebEntityLibrary
{
    public class MyWebContext:DbContext
    {
        
        public DbSet<ArticlesTable> Articles { get; set; }

        public DbSet<FilesTable> Files { get; set; }

        public DbSet<WhatIDoTable> WhatIDos { get; set; }

        public DbSet<CommentsTable> Comments { get; set; }

        public DbSet<AdminInformationsTable> AdminInformations { get; set; }

        public DbSet<SocialMediasTable> SocialMedias { get; set; }

        public DbSet<ContactsTable> Contacts { get; set; }

        public DbSet<MessagesTable> Messages { get; set; }

        public DbSet<MediasTable> Medias { get; set; }
 

    }
}
