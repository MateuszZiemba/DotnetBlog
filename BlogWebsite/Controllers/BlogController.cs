using BlogWebsite.Core.Contexts;
using BlogWebsite.Core.Repositories;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Posts(int p = 1)
        {
            var posts = new ListViewModel(blogRepository, p);
            return View(posts);
        }

        public IActionResult Category(string category, int p = 1)
        {
            var posts = new ListViewModel(blogRepository, "Category", category, p);
            return View();
        }

        public ViewResult Tag(string tag, int p = 1)
        {
            string type = "Tag";
            var listViewModel = new ListViewModel(blogRepository, type, tag, p);
            //if (listViewModel.Tag == null)
            //    throw new HttpException(404, "Tag not found!");

            ViewBag.Title = String.Concat("Latest Posts from tag ", listViewModel.Tag.Name);
            return View("List", listViewModel);
        }

        //public ViewResult Search(string s, int p = 1) //todo app.js not working
        //{
        //    string type = "Search";
        //    var listViewModel = new ListViewModel(blogRepository, type, s, p);

        //    ViewBag.Title = String.Concat("List of posts found for ", s);
        //    return View("List", listViewModel);
        //}

        public ViewResult Post(int year, int month, string title)
        {
            var post = blogRepository.GetPost(year, month, title);
            //var post = blogRepository.GetPost(2019, 10, "first");

            //if (post == null)
            //    throw new HttpException(404, "Post not found");

            //if (post.IsPublished == false && User.Identity.IsAuthenticated == false)
            //    throw new HttpException(401, "The post is not published");
            return View(post);
        }

        public ViewResult Home()
        {
            return View();
        }
    }
}
