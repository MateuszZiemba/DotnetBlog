using BlogWebsite.Core.Entities;
using BlogWebsite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.Models
{
    public class ListViewModel
    {
        private int PageSize { get { return 5; } }
        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
        public Category Category { get; private set; }
        public Tag Tag { get; private set; }
        public string Search { get; private set; }
        public int CurrentPage { get; private set; }
        public bool ShowPrevious => CurrentPage < TotalPages;
        public bool ShowNext => CurrentPage > 1;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalPosts, PageSize));

        public ListViewModel(IBlogRepository blogRepository, int pageNumber)
        {
            Posts = blogRepository.GetAllPosts(pageNumber - 1, PageSize);
            TotalPosts = blogRepository.PostsCount();
            CurrentPage = pageNumber;
        }

        public ListViewModel(IBlogRepository blogRepository, string type, string text, int pageNumber)
        {
            switch (type)
            {
                case "Tag":
                    Posts = blogRepository.PostsForTag(text, pageNumber - 1, PageSize);
                    TotalPosts = blogRepository.PostsCountForTag(text);
                    Tag = blogRepository.GetTag(text);
                    CurrentPage = pageNumber;
                    break;
                case "Category":
                    Posts = blogRepository.PostsForCategory(text, pageNumber - 1, PageSize);
                    TotalPosts = blogRepository.PostsCountForCategory(text);
                    Category = blogRepository.GetCategory(text);
                    CurrentPage = pageNumber;
                    break;
                case "Search":
                    Posts = blogRepository.PostsForSearch(text, pageNumber - 1, PageSize);
                    TotalPosts = blogRepository.PostsCountForSearch(text);
                    Search = text;
                    CurrentPage = pageNumber;
                    break;
                default:
                    break;
            }
        }

        public ListViewModel(IBlogRepository blogRepository, int year, int month, int pageNumber)
        {
            Posts = blogRepository.PostsForArchive(year, month, pageNumber, PageSize);
            TotalPosts = blogRepository.PostsCountForArchive(year, month);
        }
    }
}
