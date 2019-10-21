using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebsite.Core.Helpers
{
    public static class DateHelper
    {
        public static string ArchiveDateName(int month, int year)
        {
            return String.Concat(StringHelper.TitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)), " ", year);
        }
    }
}
