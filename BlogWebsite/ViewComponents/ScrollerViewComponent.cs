using BlogWebsite.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.ViewComponents
{
    public class ScrollerViewComponent : ViewComponent
    {
        private IBlogRepository blogRepository;
        public ScrollerViewComponent(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = blogRepository.GetAllCategories();
            return View(categories);
        }
    }
}
