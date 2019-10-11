using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.Contexts
{
    public class BlogContextFactory : IDbContextFactory<BlogDBContext>
    {
        public BlogDBContext Create()
        {
            return new BlogDBContext("Data Source = 031-LAP-2018; Initial Catalog = DotnetBlog; Integrated Security = false; User Id = kozak; Password = root1234"); //todo implement secure solution);
            //Configuration.GetConnectionString("DefaultConnection"))
        }
    }
}
