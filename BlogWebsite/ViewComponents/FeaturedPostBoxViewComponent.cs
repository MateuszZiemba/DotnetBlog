using BlogWebsite.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.ViewComponents
{
    public class FeaturedPostBoxViewComponent : ViewComponent
    {
        private IBlogRepository blogRepository;
        public FeaturedPostBoxViewComponent(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = blogRepository.GetAllPosts(1, 1);
            return View(categories[0]);
        }
    }
}
