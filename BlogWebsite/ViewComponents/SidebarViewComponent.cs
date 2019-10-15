using BlogWebsite.Core.Repositories;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private IBlogRepository blogRepository;
        public SidebarViewComponent(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public IViewComponentResult Invoke()
        {
            var sidebarViewModel = new SidebarViewModel(blogRepository);
            return View(sidebarViewModel);
        }
    }
}
