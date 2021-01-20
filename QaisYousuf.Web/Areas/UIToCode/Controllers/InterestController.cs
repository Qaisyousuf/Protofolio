using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class InterestController : Controller
    {
        private readonly IUnitOfWork uow;

        public InterestController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetInterestData()
        {
            var interest = uow.IntresetRepository.GetAll();

            List<InterestViewModel> viewmodel = new List<InterestViewModel>();

            foreach (var item in interest)
            {
                viewmodel.Add(new InterestViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Subtitle=item.Subtitle,
                    UrlIcon=item.UrlIcon,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new InterestViewModel());
        }

        [HttpPost]
        public ActionResult Create(InterestViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {
                Interest interest = new Interest
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Subtitle=viewmodel.Subtitle,
                    UrlIcon = viewmodel.UrlIcon,
                };

                uow.IntresetRepository.Add(interest);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var interest = uow.IntresetRepository.GetById(id);

            InterestViewModel viewmodel = new InterestViewModel
            {
                Id=interest.Id,
                MainTitle=interest.MainTitle,
                Subtitle=interest.Subtitle,
                UrlIcon=interest.UrlIcon,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(InterestViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var interest = uow.IntresetRepository.GetById(viewmodel.Id);

                interest.Id = viewmodel.Id;
                interest.MainTitle = viewmodel.MainTitle;
                interest.Subtitle = viewmodel.Subtitle;
                interest.UrlIcon = viewmodel.UrlIcon;

                uow.IntresetRepository.Update(interest);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            var interest = uow.IntresetRepository.GetById(id);

            InterestViewModel viewmodel = new InterestViewModel
            {
                Id = interest.Id,
                MainTitle = interest.MainTitle,
                Subtitle = interest.Subtitle,
                UrlIcon = interest.UrlIcon,
            };

            uow.IntresetRepository.Remove(interest);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var interest = uow.IntresetRepository.GetById(id);

            InterestViewModel viewmodel = new InterestViewModel
            {
                Id = interest.Id,
                MainTitle = interest.MainTitle,
                Subtitle = interest.Subtitle,
                UrlIcon = interest.UrlIcon,
            };
            return View(viewmodel);
        }
    }
}