using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Models
{
    public class Settings:EntityBase
    {
        public string SiteName { get; set; }

        public string SiteOwner { get; set; }

        public string GoogleSiteVerfication { get; set; }

        public string GoogleAds { get; set; }

        public DateTime SiteLastUpdate { get; set; }

        public string UpdatedBy { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Home { get; set; }

        public string HomeUrl { get; set; }

        public string About { get; set; }

        public string AboutUrl { get; set; }

        public string UIUX { get; set; }

        public string UIUXURl { get; set; }

        public string Code { get; set; }

        public string CodeUrl { get; set; }

        public string Contact { get; set; }

        public string ContactUrl { get; set; }

        public string Support { get; set; }

        public string SupportUrl { get; set; }

        public string Profile { get; set; }

        public string ProfileUrl { get; set; }

        public string CopyrightFooter { get; set; }


        public string DesignBy { get; set; }



    }
}
