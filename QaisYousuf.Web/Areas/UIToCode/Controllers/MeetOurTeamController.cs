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
    public class MeetOurTeamController : Controller
    {
        private readonly IUnitOfWork uow;

        public MeetOurTeamController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMeetOurTeamData()
        {
            var meetOurTeam = uow.MeetOurTeamRepository.GetAll("TeamSocialMedias");

            List<MeetOurTeamViewModel> viewmodel = new List<MeetOurTeamViewModel>();

            foreach (var item in meetOurTeam)
            {
                viewmodel.Add(new MeetOurTeamViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    ImageUrl=item.ImageUrl,
                    ProfileImageUrl=item.ProfileImageUrl,
                    Name=item.Name,
                    Position=item.Position,
                    Content=item.Content,

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.SocialMedia = uow.TeamSocialMediaRepository.GetAll();

            return View(new MeetOurTeamViewModel());
        }

        [HttpPost]
        public ActionResult Create(MeetOurTeamViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.SocialMedia = uow.TeamSocialMediaRepository.GetAll();
                return View(viewmodel);

            }

            MeetOutTeam meetTeam = new MeetOutTeam();

            meetTeam.Id = viewmodel.Id;
            meetTeam.MainTitle = viewmodel.MainTitle;
            meetTeam.ImageUrl = viewmodel.ImageUrl;
            meetTeam.ProfileImageUrl = viewmodel.ProfileImageUrl;
            meetTeam.Name = viewmodel.Name;
            meetTeam.Position = viewmodel.Position;
            meetTeam.Content = viewmodel.Content;

           

            uow.MeetOurTeamRepository.Add(meetTeam);
            uow.Commit();

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

       [HttpGet]
       public ActionResult Edit(int id)
        {
            var meetOurTeam = uow.Context.MeetOutTeams.Include("TeamSocialMedias").SingleOrDefault(x => x.Id==id);

            MeetOurTeamViewModel viewmodel = new MeetOurTeamViewModel
            {
                Id=meetOurTeam.Id,
                MainTitle=meetOurTeam.MainTitle,
                ImageUrl=meetOurTeam.ImageUrl,
                ProfileImageUrl=meetOurTeam.ProfileImageUrl,
                Name=meetOurTeam.Name,
                Position=meetOurTeam.Position,
                Content=meetOurTeam.Content,

            };

           
            ViewBag.socialMedia = uow.TeamSocialMediaRepository.GetAll();

            return View(viewmodel);
                
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,MainTitle,ImageUrl,ProfileImageUrl,Name,Position,Content")] MeetOurTeamViewModel viewmodel,int[] socialIds)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.SocialMedia = uow.TeamSocialMediaRepository.GetAll();
                return View(viewmodel);
            }

            var meetOurTeam = uow.Context.MeetOutTeams.Include("TeamSocialMedias").SingleOrDefault(x => x.Id == viewmodel.Id);

            meetOurTeam.Id = viewmodel.Id;
            meetOurTeam.MainTitle = viewmodel.MainTitle;
            meetOurTeam.ImageUrl = viewmodel.ImageUrl;
            meetOurTeam.ProfileImageUrl = viewmodel.ProfileImageUrl;
            meetOurTeam.Name = viewmodel.Name;
            meetOurTeam.Position = viewmodel.Position;
            meetOurTeam.Content = viewmodel.Content;

            var socialMedia = uow.Context.TeamSocialMedias.Where(x => socialIds.Contains(x.Id)).ToList();

           

            uow.MeetOurTeamRepository.Update(meetOurTeam);
            uow.Commit();


            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

    }
}