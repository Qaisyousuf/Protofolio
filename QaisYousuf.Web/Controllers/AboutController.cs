using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Models;
using QaisYousuf.Web.Infrastructure;

namespace QaisYousuf.Web.Controllers
{

    
    public class AboutController : BaseController
    {
        [Route("About")]
        
        public ActionResult Index(string slug)
        {
           
            
            var aboutPage = Uow.AboutPageRepository.GetAll();

            
            List<AboutPageViewModel> viewmodel = new List<AboutPageViewModel>();

            foreach (var item in aboutPage)
            {
                viewmodel.Add(new AboutPageViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    MetaKeywords = item.MetaKeywords,
                    MetaDescription = item.MetaDescription,
                    IsVisibleToSearchEngine = item.IsVisibleToSearchEngine,
                    Content = item.Content,
                    BannerId = item.BannerId,
                    AboutPageBanner = item.AboutPageBanner,
                    StartUpProgramId = item.StartUpProgramId,
                    StartUpProgram = item.StartUpProgram,
                    StartUpProcessId = item.StartUpProcessId,
                    StartUpProcess = item.StartUpProcess,
                    MeetOurTeamId = item.MeetOurTeamId,
                    MeetOurTeam = item.MeetOurTeam,
                });


            }

            ListOfAboutPage aboutPageViewmodel = new ListOfAboutPage
            {
                AboutPageList = viewmodel
            };

            return View(aboutPageViewmodel);
        }
        [ChildActionOnly]
        [HttpGet]
        public ActionResult GetAboutPageBanner()
        {
            
            var aboutpage = Uow.AboutPageBannerRepository.GetAll();

            List<AboutBannerViewModel> viewmodel = new List<AboutBannerViewModel>();

            foreach (var item in aboutpage)
            {
                viewmodel.Add(new AboutBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText,
                    ImageUrl=item.ImageUrl,
                });
            }

            ListOfAboutPage BannerList = new ListOfAboutPage
            {
                AboutBanner = viewmodel
            };

            return PartialView(BannerList);
        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult StartProgram()
        {
            var startUp = Uow.StartUpProgramRepository.GetAll();

            List<StartUpProgramViewModel> viewmodel = new List<StartUpProgramViewModel>();

            foreach (var item in startUp)
            {
                viewmodel.Add(new StartUpProgramViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                });
            }

            ListOfAboutPage aboutPageStartUpProgram = new ListOfAboutPage
            {
                StartProgramListViewModel = viewmodel
            };
            return PartialView(aboutPageStartUpProgram);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult StartUpProcess()
        {
            var startUpProcess = Uow.StartUpProcessRepository.GetAll();

            List<StartUpProcessViewModel> viewmodel = new List<StartUpProcessViewModel>();

            foreach (var item in startUpProcess)
            {
                viewmodel.Add(new StartUpProcessViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                });
            }

            ListOfAboutPage startUprocessList = new ListOfAboutPage
            {
                StartProcessListViewModel=viewmodel
            };

            return PartialView(startUprocessList);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetMeetOurTeam()
        {
            var meetourTeam = Uow.MeetOurTeamRepository.GetAll();

            List<MeetOurTeamViewModel> viewmodel = new List<MeetOurTeamViewModel>();

            foreach (var item in meetourTeam)
            {
                viewmodel.Add(new MeetOurTeamViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    ImageUrl=item.ImageUrl,
                    ProfileImageUrl=item.ProfileImageUrl,
                    Name=item.Name,
                    Position=item.Position,
                    Content=item.Content,
                    TeamSocialId=item.TeamSocialId,
                    TeamSocialMedias=item.TeamSocialMedias,

                });
            }

            var socialMedia = Uow.TeamSocialMediaRepository.GetAll();

            List<TeamSocialMediaViewModel> socialmediaViewModel = new List<TeamSocialMediaViewModel>();

            foreach (var sociaMeidaitem in socialMedia)
            {
                socialmediaViewModel.Add(new TeamSocialMediaViewModel
                {
                    Id=sociaMeidaitem.Id,
                    Title=sociaMeidaitem.Title,
                    FB=sociaMeidaitem.FB,
                    FBUrl=sociaMeidaitem.FBUrl,
                    LinkedIn=sociaMeidaitem.LinkedIn,
                    LinkedInUrl=sociaMeidaitem.LinkedInUrl,
                    Twiter=sociaMeidaitem.Twiter,
                    TwiterUrl=sociaMeidaitem.TwiterUrl,
                    WebSite=sociaMeidaitem.WebSite,
                    WebsiteUrl=sociaMeidaitem.WebsiteUrl,

                });
            }
            ListOfAboutPage MeetOurTeamBout = new ListOfAboutPage
            {
                MeetoutTeamListViewmodel=viewmodel,
                SocialMeidaTeam=socialmediaViewModel,


            };
            return PartialView(MeetOurTeamBout);
        }
    }
}