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
    [Authorize(Roles = "Supper Admin")]
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

            ViewBag.SocialMedia = uow.TeamSocialMediaRepository.GetAll();
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
                    TeamSocialId=item.TeamSocialId,
                    TeamSocialMedias=item.TeamSocialMedias,

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
          
            if(ModelState.IsValid)
            {
                MeetOurTeam meetTeam = new MeetOurTeam
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    ProfileImageUrl=viewmodel.ProfileImageUrl,
                    Name=viewmodel.Name,
                    Position=viewmodel.Position,
                    Content=viewmodel.Content,
                    TeamSocialId=viewmodel.TeamSocialId,
                    TeamSocialMedias=viewmodel.TeamSocialMedias
                };
                uow.MeetOurTeamRepository.Add(meetTeam);
                uow.Commit();
            }
           

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

       [HttpGet]
       public ActionResult Edit(int id)
        {
            var meetOurTeam = uow.MeetOurTeamRepository.GetById(id);

            MeetOurTeamViewModel viewmodel = new MeetOurTeamViewModel
            {
                Id=meetOurTeam.Id,
                MainTitle=meetOurTeam.MainTitle,
                ImageUrl=meetOurTeam.ImageUrl,
                ProfileImageUrl=meetOurTeam.ProfileImageUrl,
                Name=meetOurTeam.Name,
                Position=meetOurTeam.Position,
                Content=meetOurTeam.Content,
                TeamSocialId=meetOurTeam.TeamSocialId,
                TeamSocialMedias=meetOurTeam.TeamSocialMedias,

            };

           
            ViewBag.socialMedia = uow.TeamSocialMediaRepository.GetAll();

            return View(viewmodel);
                
        }

        [HttpPost]
        public ActionResult Edit(MeetOurTeamViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var meetOurTeam = uow.MeetOurTeamRepository.GetById(viewmodel.Id);
                meetOurTeam.Id = viewmodel.Id;
                meetOurTeam.MainTitle = viewmodel.MainTitle;
                meetOurTeam.ImageUrl = viewmodel.ImageUrl;
                meetOurTeam.ProfileImageUrl = viewmodel.ProfileImageUrl;
                meetOurTeam.Name = viewmodel.Name;
                meetOurTeam.Position = viewmodel.Position;
                meetOurTeam.Content = viewmodel.Content;
                meetOurTeam.TeamSocialId = viewmodel.TeamSocialId;
                meetOurTeam.TeamSocialMedias = viewmodel.TeamSocialMedias;
                uow.MeetOurTeamRepository.Update(meetOurTeam);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var meetTeam = uow.MeetOurTeamRepository.GetById(id);

            MeetOurTeamViewModel viewmodel = new MeetOurTeamViewModel
            {
                Id=meetTeam.Id,
                MainTitle=meetTeam.MainTitle,
                ImageUrl=meetTeam.ImageUrl,
                ProfileImageUrl=meetTeam.ProfileImageUrl,
                Name=meetTeam.Name,
                Position=meetTeam.Position,
                Content=meetTeam.Content,
                TeamSocialId=meetTeam.TeamSocialId,
                TeamSocialMedias=meetTeam.TeamSocialMedias,
         
            };

            uow.MeetOurTeamRepository.Remove(meetTeam);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var meetTeam = uow.MeetOurTeamRepository.GetById(id);

            MeetOurTeamViewModel viewmodel = new MeetOurTeamViewModel
            {
                Id=meetTeam.Id,
                MainTitle=meetTeam.MainTitle,
                ImageUrl=meetTeam.ImageUrl,
                ProfileImageUrl=meetTeam.ProfileImageUrl,
                Name=meetTeam.Name,
                Position=meetTeam.Position,
                Content=meetTeam.Content,
                TeamSocialId=meetTeam.TeamSocialId,
                TeamSocialMedias=meetTeam.TeamSocialMedias,
            };

            return View(viewmodel);
        }

    }
}