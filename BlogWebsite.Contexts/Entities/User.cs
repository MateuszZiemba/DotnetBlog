using System;
using System.Collections.Generic;
using System.Text;

namespace BlogWebsite.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } //todo extract with login to credentials table? 
        public string Name { get; set; }
        public string Surname { get; set; }
        //todo add permission enum - admin, user, superadmin 
    }
}
