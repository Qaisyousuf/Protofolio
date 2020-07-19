using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Models;
using QaisYousuf.Data.Interfaces;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class SocialMediaTeamController : Controller
    {
        private readonly IUnitOfWork uow;

        public SocialMediaTeamController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMediaSocialTeam()
        {
            var socialMedia = uow.TeamSocialMediaRepository.GetAll();

            List<TeamSocialMediaViewModel> viewmodel = new List<TeamSocialMediaViewModel>();

            foreach (var item in socialMedia)
            {
                viewmodel.Add(new TeamSocialMediaViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    FB=item.FB,
                    FBUrl=item.FBUrl,
                    LinkedIn=item.LinkedIn,
                    LinkedInUrl=item.LinkedInUrl,
                    Twiter=item.Twiter,
                    TwiterUrl=item.TwiterUrl,
                    WebSite=item.WebSite,
                    WebsiteUrl=item.WebsiteUrl,

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TeamSocialMediaViewModel());
        }

        [HttpPost]
        public ActionResult Create(TeamSocialMediaViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                TeamSocialMedia socialMedia = new TeamSocialMedia
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    FB=viewmodel.FB,
                    FBUrl=viewmodel.FBUrl,
                    LinkedIn=viewmodel.LinkedIn,
                    LinkedInUrl=viewmodel.LinkedInUrl,
                    Twiter=viewmodel.Twiter,
                    TwiterUrl=viewmodel.TwiterUrl,
                    WebSite=viewmodel.WebSite,
                    WebsiteUrl=viewmodel.WebsiteUrl
                };
                uow.TeamSocialMediaRepository.Add(socialMedia);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var socialMedia = uow.TeamSocialMediaRepository.GetById(id);

            TeamSocialMediaViewModel viewmodel = new TeamSocialMediaViewModel
            {
                Id=socialMedia.Id,
                Title=socialMedia.Title,
                FB=socialMedia.FB,
                FBUrl=socialMedia.FBUrl,
                LinkedIn=socialMedia.LinkedIn,
                LinkedInUrl=socialMedia.LinkedInUrl,
                Twiter=socialMedia.Twiter,
                TwiterUrl=socialMedia.TwiterUrl,
                WebSite=socialMedia.WebSite,
                WebsiteUrl=socialMedia.WebsiteUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TeamSocialMediaViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var socialMedia = uow.TeamSocialMediaRepository.GetById(viewmodel.Id);

                socialMedia.Id = viewmodel.Id;
                socialMedia.Title = viewmodel.Title;
                socialMedia.FB = viewmodel.FB;
                socialMedia.FBUrl = viewmodel.FBUrl;
                socialMedia.LinkedIn = viewmodel.LinkedIn;
                socialMedia.LinkedInUrl = viewmodel.LinkedInUrl;
                socialMedia.Twiter = viewmodel.Twiter;
                socialMedia.TwiterUrl = viewmodel.TwiterUrl;
                socialMedia.WebSite = viewmodel.WebSite;
                socialMedia.WebsiteUrl = viewmodel.WebsiteUrl;


                uow.TeamSocialMediaRepository.Update(socialMedia);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var socialMedia = uow.TeamSocialMediaRepository.GetById(id);

            TeamSocialMediaViewModel viewmodel = new TeamSocialMediaViewModel
            {
                Id=socialMedia.Id,
                Title=socialMedia.Title,
                FB=socialMedia.FB,
                FBUrl=socialMedia.FBUrl,
                LinkedIn=socialMedia.LinkedIn,
                LinkedInUrl=socialMedia.LinkedInUrl,
                Twiter=socialMedia.Twiter,
                TwiterUrl=socialMedia.TwiterUrl,
                WebSite=socialMedia.WebSite,
                WebsiteUrl=socialMedia.WebsiteUrl
            };
            uow.TeamSocialMediaRepository.Remove(socialMedia);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var socialMedia = uow.TeamSocialMediaRepository.GetById(id);

            TeamSocialMediaViewModel viewmodel = new TeamSocialMediaViewModel
            {
                Id=socialMedia.Id,
                Title=socialMedia.Title,
                FB=socialMedia.FB,
                FBUrl=socialMedia.FBUrl,
                LinkedIn=socialMedia.LinkedIn,
                LinkedInUrl=socialMedia.LinkedInUrl,
                Twiter=socialMedia.Twiter,
                TwiterUrl=socialMedia.TwiterUrl,
                WebSite=socialMedia.WebSite,
                WebsiteUrl=socialMedia.WebsiteUrl,
            };

            return View(viewmodel);
        }
    }
}