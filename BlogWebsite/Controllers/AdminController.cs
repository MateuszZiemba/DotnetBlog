//using BlogWebsite.Core.DbContexts;
using BlogWebsite.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.Controllers
{
    public class AdminController : Controller
    {
        private BlogDBContext blogContext;
        public AdminController(BlogDBContext blogContext)
        {
            this.blogContext = blogContext;
        }
        public IActionResult Login()
        {
            ViewBag.DbTest = blogContext.Posts.Select(p => p.Description).FirstOrDefault();
            return View();
        }
    }
}
