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
    public class EducationController : Controller
    {
        private readonly IUnitOfWork uow;

        public EducationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEducationData()
        {
            var education = uow.EducationRepository.GetAll();

            List<EducationViewModel> viewmodel = new List<EducationViewModel>();

            foreach (var item in education)
            {
                viewmodel.Add(new EducationViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EducationViewModel());
        }

        [HttpPost]
        public ActionResult Create(EducationViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {
                Education education = new Education
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Content = viewmodel.Content,
                    ImageUrl = viewmodel.ImageUrl,
                };

                uow.EducationRepository.Add(education);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var education = uow.EducationRepository.GetById(id);

            EducationViewModel viewmodel = new EducationViewModel
            {
                Id=education.Id,
                MainTitle=education.MainTitle,
                Content=education.Content,
                ImageUrl=education.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(EducationViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var education = uow.EducationRepository.GetById(viewmodel.Id);

                education.Id = viewmodel.Id;
                education.MainTitle = viewmodel.MainTitle;
                education.Content = viewmodel.Content;
                education.ImageUrl = viewmodel.ImageUrl;

                uow.EducationRepository.Update(education);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var education = uow.EducationRepository.GetById(id);

            EducationViewModel viewmodel = new EducationViewModel
            {
                Id=education.Id,
                MainTitle=education.MainTitle,
                Content=education.Content,
                ImageUrl=education.ImageUrl,
            };

            uow.EducationRepository.Remove(education);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var education = uow.EducationRepository.GetById(id);

            EducationViewModel viewmodel = new EducationViewModel
            {
                Id = education.Id,
                MainTitle = education.MainTitle,
                Content = education.Content,
                ImageUrl = education.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}