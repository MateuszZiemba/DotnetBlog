
using BlogWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BlogWebsite.Core.Contexts
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(string connectionString) : base(connectionString)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
