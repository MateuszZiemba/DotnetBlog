using BlogWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.Models
{
    public class FeaturedPostViewModel
    {
        IList<FeaturedPost> FeaturedPosts { get; set; }
    }
}
