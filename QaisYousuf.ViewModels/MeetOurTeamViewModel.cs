using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.ViewModels
{
    public class MeetOurTeamViewModel
    {
       
        public int Id { get; set; }

        [Required]
        [Display(Name="Main Title")]
        public string MainTitle { get; set; }


        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        [Required]
        public string ImageUrl { get; set; }


        [Display(Name = "Image Url")]
        [DataType(DataType.Url)]
        [Required]
        public string ProfileImageUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        public string Content { get; set; }


        [Display(Name ="Social Media")]
        public int TeamSocialId { get; set; }
        [ForeignKey("TeamSocialId")]
        public virtual TeamSocialMedia TeamSocialMedias { get; set; }
    }
}
