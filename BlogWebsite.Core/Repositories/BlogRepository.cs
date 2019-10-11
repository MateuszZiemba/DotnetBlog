using System;
using System.Collections.Generic;
using System.Text;
using BlogWebsite.Core.BusinessObjects;

namespace BlogWebsite.Core.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public BlogRepository(BlogDbContext)
        {

        }
        public IList<Post> GetAllPosts()
        {

        }
    }
}
