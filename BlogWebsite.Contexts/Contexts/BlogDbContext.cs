using BlogWebsite.Core.BusinessObjects;
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
    }
}
