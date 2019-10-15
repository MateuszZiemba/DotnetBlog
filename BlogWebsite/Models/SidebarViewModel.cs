using BlogWebsite.Core.Entities;
using BlogWebsite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.Models
{
    public class SidebarViewModel
    {
        public IList<string> ArchiveSections { get; private set; }
        public IList<SocialMedia> SocialMedias { get; private set; }

        public SidebarViewModel(IBlogRepository blogRepository)
        {
            SocialMedias = blogRepository.GetAllSocialMedias();
            ArchiveSections = blogRepository.GetArchiveCategories();
        }
    }
}
