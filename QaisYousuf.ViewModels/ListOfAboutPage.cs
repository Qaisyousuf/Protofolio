using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
   public class ListOfAboutPage:BaseViewModel
    {
        public List<AboutPageViewModel> AboutPageList { get; set; }
        public List<AboutBannerViewModel> AboutBanner { get; set; }
        public List<StartUpProgramViewModel> StartProgramListViewModel { get; set; }
        public List<StartUpProcessViewModel> StartProcessListViewModel { get; set; }
        public List<MeetOurTeamViewModel> MeetoutTeamListViewmodel { get; set; }
        public List<TeamSocialMediaViewModel> SocialMeidaTeam { get; set; }
        

    }
}
