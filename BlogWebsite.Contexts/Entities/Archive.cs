using BlogWebsite.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogWebsite.Core.Entities
{
    public class SidebarArchive
    {
        public string ArchiveSectionName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public SidebarArchive(int year, int month)
        {
            Year = year;
            Month = month;
            ArchiveSectionName = DateHelper.ArchiveDateName(Month, Year);
        }
    }
}
