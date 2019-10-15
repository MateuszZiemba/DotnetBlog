using System;
using System.Collections.Generic;
using System.Text;

namespace BlogWebsite.Core.POCOs
{
    public class SocialMedia
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public SocialMedia(string name, string url)
        {
            Name = name;
            Url = url; //todo validation that it starts with http:// (method to add it anyway? ) 
        }
    }
}
