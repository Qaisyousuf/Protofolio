using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class TeamSocialMediaViewModel
    {
     
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        [Display(Name ="Facebook")]
        public string FB { get; set; }

        [Required]
        [Display(Name ="Facebook Url")]
        [DataType(DataType.Url)]
        public string FBUrl { get; set; }

        [Required]
        public string LinkedIn { get; set; }

        [DataType(DataType.Url)]
        [Required]
        [Display(Name ="LinkedIn Url")]
        public string LinkedInUrl { get; set; }


        [Required]
        public string Twiter { get; set; }

        [Required]
        [Display(Name = "Twiter Url")]
        [DataType(DataType.Url)]
        public string TwiterUrl { get; set; }

        [Required]
        public string WebSite { get; set; }

        [Required]
        [Display(Name = "Website Url")]
        [DataType(DataType.Url)]
        public string WebsiteUrl { get; set; }

       
    }
}
