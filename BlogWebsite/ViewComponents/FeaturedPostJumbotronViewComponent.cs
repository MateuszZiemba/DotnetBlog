using BlogWebsite.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.ViewComponents
{
    public class FeaturedPostJumbotronViewComponent : ViewComponent
    {
        private IBlogRepository blogRepository;
        public FeaturedPostJumbotronViewComponent(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = blogRepository.GetAllPosts(1, 2);
            return View(categories[1]);
        }
    }
}
