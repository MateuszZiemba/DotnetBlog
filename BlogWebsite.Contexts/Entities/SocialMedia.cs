using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogWebsite.Core.Entities
{
    public class SocialMedia
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(300)]
        public string Url { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsEnabled { get; set; }

    }
}
