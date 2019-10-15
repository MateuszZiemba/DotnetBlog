using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using BlogWebsite.Core.Entities;
using BlogWebsite.Core.Contexts;

namespace BlogWebsite.Core.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private BlogDBContext blogContext;
        public BlogRepository(BlogDBContext blogContext)
        {
            this.blogContext = blogContext;
        }
        public IList<Post> GetAllPosts(int pageNumber, int pageSize)
        {
            var posts = blogContext.Posts.Where(p => p.IsPublished)
                    .OrderByDescending(p => p.PublishedOn)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .Include(p => p.Category)
                    .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return blogContext.Posts.Where(p => postIds.Contains(p.Id))
                               .OrderByDescending(p => p.PublishedOn)
                               .Include(p => p.Tags)
                               .ToList();
        }
        public int PostsCount()
        {
            return (from p in blogContext.Posts
                    where p.IsPublished == true
                    select p).Count();
        }

        public IList<Post> PostsForCategory(string categorySlug, int pageNumber, int pageSize)
        {
            var posts = blogContext.Posts.Where(p => p.IsPublished && p.Category.Slug.Equals(categorySlug))
                                .OrderByDescending(p => p.PublishedOn)
                                .Skip(pageNumber * pageSize)
                                .Take(pageSize)
                                .Include(p => p.Category)
                                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return blogContext.Posts.Where(p => postIds.Contains(p.Id))
                           .OrderByDescending(p => p.PublishedOn)
                           .Include(p => p.Tags)
                           .ToList();
        }

        public int PostsCountForCategory(string categorySlug)
        {
            return (from p in blogContext.Posts
                    where p.IsPublished == true && p.Category.Slug.Equals(categorySlug)
                    select p).Count();
        }

        public Category GetCategory(string categorySlug)
        {
            return blogContext.Categories.Where(c => c.Slug.Equals(categorySlug)).FirstOrDefault();
        }

        public IList<Post> PostsForTag(string tagSlug, int pageNumber, int pageSize)
        {
            var posts = blogContext.Posts.Where(p => p.IsPublished && p.Tags.Any(t => t.Slug.Equals(tagSlug)))
                                .OrderByDescending(p => p.PublishedOn)
                                .Skip(pageNumber * pageSize)
                                .Take(pageSize)
                                .Include(p => p.Category)
                                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return blogContext.Posts.Where(p => postIds.Contains(p.Id))
                           .OrderByDescending(p => p.PublishedOn)
                           .Include(p => p.Tags)
                           .ToList();
        }

        public int PostsCountForTag(string tagSlug)
        {
            return blogContext.Tags.Where(t => t.Slug.Equals(tagSlug)).SelectMany(p => p.Posts).Count();
        }

        public Tag GetTag(string tagSlug)
        {
            return blogContext.Tags.Where(t => t.Slug.Equals(tagSlug)).FirstOrDefault();
        }

        public IList<Post> PostsForSearch(string search, int pageNumber, int pageSize)
        {
            var posts = blogContext.Posts.Where(p => p.IsPublished && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search))))
                    .OrderByDescending(p => p.PublishedOn)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .Include(p => p.Category)
                    .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return blogContext.Posts.Where(p => postIds.Contains(p.Id))
                           .OrderByDescending(p => p.PublishedOn)
                           .Include(p => p.Tags)
                           .ToList();
        }

        public int PostsCountForSearch(string search)
        {
            return (from p in blogContext.Posts
                    where p.IsPublished == true && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search)))
                    select p).Count();
        }

        public Post GetPost(int year, int month, string postSlug)
        {
            return blogContext.Posts.Where(p => p.Slug.Equals(postSlug)
                               && p.PublishedOn.Year.Equals(year)
                               && p.PublishedOn.Month.Equals(month))
                               .Include(c => c.Category)
                               .FirstOrDefault();
        }
        public IList<Category> GetAllCategories()
        {
            return blogContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public IList<Tag> GetAllTags()
        {
            return blogContext.Tags.OrderBy(t => t.Name).ToList();
        }

        public IList<SocialMedia> GetAllSocialMedias()
        {
            var socialMedias = new List<SocialMedia>(); //todo manage via AdminPage
            return blogContext.SocialMedias.Where(s => s.IsEnabled).OrderBy(s => s.DisplayOrder).ToList();
        }

        public IList<string> GetArchiveCategories()
        {
            var result = blogContext.Posts.Select(p => new { p.PublishedOn.Year, p.PublishedOn.Month }).GroupBy(g => new { g.Year, g.Month }).Select(p => p.Key).ToList();
            var archives = new List<string>();
            foreach (var element in result)
            {
                archives.Add(String.Concat(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(element.Month), " ", element.Year)); //todo handle with selected culture
            }
            return archives; //todo return more complex type, with slug to search for those posts? 
        }
    }
}