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
        public IList<SidebarArchive> ArchiveSections { get; private set; }
        public IList<SocialMedia> SocialMedias { get; private set; }
        public IList<Post> LatestPosts { get; private set; }

        public SidebarViewModel(IBlogRepository blogRepository)
        {
            LatestPosts = blogRepository.GetAllPosts(1, 5);
            ArchiveSections = blogRepository.GetArchiveCategories();
            SocialMedias = blogRepository.GetAllSocialMedias();
        }
    }
}
