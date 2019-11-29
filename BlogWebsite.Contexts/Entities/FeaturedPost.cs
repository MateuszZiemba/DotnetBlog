using BlogWebsite.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogWebsite.Core.Entities
{
    public class FeaturedPost
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        //[Required]
        public Post Post { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        [Required]
        public FeaturedPostType FeaturedPostType { get; set; }
    }
}
