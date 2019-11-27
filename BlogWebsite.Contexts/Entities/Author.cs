using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogWebsite.Core.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Login { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; } //todo
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
    }
}
