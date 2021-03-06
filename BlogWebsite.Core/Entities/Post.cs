﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogWebsite.Core.BusinessObjects
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [MaxLength()]
        public string Text { get; set; }
        [Required]
        [StringLength(200)]
        public string Slug { get; set; }
        [Required]
        public bool IsPublished { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Required]
        public Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
