using BlogWebsite.Core.Entities;
using System.Collections.Generic;

namespace BlogWebsite.Core.Repositories
{
    public interface IBlogRepository
    {
        IList<Post> GetAllPosts(int pageNumber, int pageSize);
        int PostsCount();
        IList<Post> PostsForCategory(string categorySlug, int pageNumber, int pageSize);
        int PostsCountForCategory(string categorySlug);
        Category GetCategory(string categorySlug);
        IList<Post> PostsForTag(string tagSlug, int pageNumber, int pageSize);
        int PostsCountForTag(string tagSlug);
        Tag GetTag(string tagSlug);
        IList<Post> PostsForSearch(string search, int pageNumber, int pageSize);
        int PostsCountForSearch(string search);
        IList<Post> PostsForArchive(int year, int month, int pageNumber, int pageSize);
        int PostsCountForArchive(int year, int month);
        Post GetPost(int year, int month, string postSlug);
        IList<Category> GetAllCategories();
        IList<Tag> GetAllTags();
        IList<SocialMedia> GetAllSocialMedias();
        IList<SidebarArchive> GetArchiveCategories();
    }
}