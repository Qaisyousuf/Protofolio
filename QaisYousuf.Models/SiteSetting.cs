using System;

namespace QaisYousuf.Models
{
    public class SiteSetting:EntityBase
    {
        public string MainTitle { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime SiteLastUpdated { get; set; }

        public string DesinedBy { get; set; }

    }
}
