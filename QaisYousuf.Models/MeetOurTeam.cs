using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class MeetOurTeam:EntityBase
    {
        
        public string MainTitle { get; set; }

        public string ImageUrl { get; set; }

        public string ProfileImageUrl { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Content { get; set; }


        [Display(Name = "Social Media")]
        public int TeamSocialId { get; set; }
        [ForeignKey("TeamSocialId")]
        public virtual TeamSocialMedia TeamSocialMedias { get; set; }

    }
}
