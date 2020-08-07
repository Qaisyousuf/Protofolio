using System;
using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class SiteSettingViewMdoel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Site Name")]
        public string SiteName { get; set; }

        [Required]
        [Display(Name = "Site Owner")]
        public string SiteOwner { get; set; }

        [Display(Name = "Google Verfication")]
        public string GoogleSiteVerfication { get; set; }

        [Display(Name = "Google Ads")]
        public string GoogleAds { get; set; }

        [Display(Name = "Site Last Update")]
        public DateTime SiteLastUpdate { get; set; }


        [Display(Name = "Site Update By")]
        public string UpdatedBy { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Home { get; set; }

        [Required]
        [Display(Name = "Home Ul")]
        public string HomeUrl { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        [Display(Name = "About Url")]
        public string AboutUrl { get; set; }

        [Required]
        public string UIUX { get; set; }

        [Required]
        [Display(Name = "UIUX Url")]
        public string UIUXURl { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Code Name")]
        public string CodeUrl { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "Contact Url")]
        public string ContactUrl { get; set; }

        [Required]
        public string Support { get; set; }

        [Required]
        [Display(Name = "Support Url")]
        public string SupportUrl { get; set; }

        [Required]
        public string Profile { get; set; }

        [Required]
        [Display(Name = "Profile Url")]
        public string ProfileUrl { get; set; }

        [Required]
        [Display(Name = "Copyright")]
        public string CopyrightFooter { get; set; }

        [Required]
        [Display(Name = "Designed By")]
        public string DesignBy { get; set; }
    }
}
