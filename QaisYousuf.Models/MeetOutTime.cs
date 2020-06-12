using System.Collections.Generic;

namespace QaisYousuf.Models
{
    public class MeetOutTime:EntityBase
    {
        public MeetOutTime()
        {
            TeamSocialMedias = new List<TeamSocialMedia>();
        }
        public string MainTitle { get; set; }

        public string ImageUrl { get; set; }

        public string ProfileImageUrl { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Content { get; set; }

        public ICollection<TeamSocialMedia> TeamSocialMedias { get; set; }


    }
}
