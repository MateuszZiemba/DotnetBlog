using BlogWebsite.Core.BusinessObjects;
using System.Collections.Generic;

namespace BlogWebsite.Core.Repositories
{
    public interface IBlogRepository
    {
        IList<Post> GetAllPosts();
    }
}