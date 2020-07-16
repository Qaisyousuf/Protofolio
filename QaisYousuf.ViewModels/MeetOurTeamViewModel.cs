using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class MeetOurTeamViewModel
    {
        public MeetOurTeamViewModel()
        {
            TeamSocialMedias = new List<TeamSocialMedia>();
        }
        public int Id { get; set; }

        public string MainTitle { get; set; }

        public string ImageUrl { get; set; }

        public string ProfileImageUrl { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Content { get; set; }

        public ICollection<TeamSocialMedia> TeamSocialMedias { get; set; }
    }
}
