using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogWebsite.Core.BusinessObjects
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(200)]
        public string Slug { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}