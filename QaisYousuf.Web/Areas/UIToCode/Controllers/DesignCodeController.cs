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
    public class DesignCodeController : Controller
    {
        private readonly IUnitOfWork uow;

        public DesignCodeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDesignCodeData()
        {
            var designCode = uow.DesignCodeSectionRepository.GetAll();

            List<DesignCodeViewModel> viewmodel = new List<DesignCodeViewModel>();

            foreach (var item in designCode)
            {
                viewmodel.Add(new DesignCodeViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    ImageUrl=item.ImageUrl
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DesignCodeViewModel());
        }

        [HttpPost]
        public ActionResult Create(DesignCodeViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                DesignCodeSection designCode = new DesignCodeSection
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    ImageUrl=viewmodel.ImageUrl,
                };
                uow.DesignCodeSectionRepository.Add(designCode);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var designCode = uow.DesignCodeSectionRepository.GetById(id);

            DesignCodeViewModel viewmodel = new DesignCodeViewModel
            {
                Id=designCode.Id,
                Title=designCode.Title,
                ImageUrl=designCode.ImageUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(DesignCodeViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var designCode = uow.DesignCodeSectionRepository.GetById(viewmodel.Id);

                designCode.Id = viewmodel.Id;
                designCode.Title = viewmodel.Title;
                designCode.ImageUrl = viewmodel.ImageUrl;

                uow.DesignCodeSectionRepository.Update(designCode);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var designCode = uow.DesignCodeSectionRepository.GetById(id);

            DesignCodeViewModel viewmodel = new DesignCodeViewModel
            {
                Id=designCode.Id,
                Title=designCode.Title,
                ImageUrl=designCode.ImageUrl,

            };
            uow.DesignCodeSectionRepository.Remove(designCode);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var designCode = uow.DesignCodeSectionRepository.GetById(id);

            DesignCodeViewModel viewmodel = new DesignCodeViewModel
            {
                Id=designCode.Id,
                Title=designCode.Title,
                ImageUrl=designCode.ImageUrl,
            };

            return View(viewmodel);
        }
    }
}