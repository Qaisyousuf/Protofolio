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
    public class DesignStepsController : Controller
    {
        private readonly IUnitOfWork uow;

        public DesignStepsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: UIToCode/DesignSteps
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDesignStepsData()
        {
            var designSteps = uow.DesignStepsRepository.GetAll();

            List<DesignStepsViewModel> viewmodel = new List<DesignStepsViewModel>();

            foreach (var item in designSteps)
            {
                viewmodel.Add(new DesignStepsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    StepIcon=item.StepIcon,
                    StepTitle=item.StepTitle,
                    StepContent=item.StepContent,
                    StepImageUrl=item.StepImageUrl
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DesignStepsViewModel());
        }

        [HttpPost]
        public ActionResult Create(DesignStepsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                DesignSteps designStep = new DesignSteps
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    StepIcon=viewmodel.StepIcon,
                    StepTitle=viewmodel.StepTitle,
                    StepContent=viewmodel.StepContent,
                    StepImageUrl=viewmodel.StepImageUrl,
                };

                uow.DesignStepsRepository.Add(designStep);
                uow.Commit();

            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var designSteps = uow.DesignStepsRepository.GetById(id);

            DesignStepsViewModel viewmodel = new DesignStepsViewModel
            {
                Id=designSteps.Id,
                MainTitle=designSteps.MainTitle,
                SubTitle=designSteps.SubTitle,
                StepIcon=designSteps.StepIcon,
                StepTitle=designSteps.StepTitle,
                StepContent=designSteps.StepContent,
                StepImageUrl=designSteps.StepImageUrl
            };
            
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(DesignStepsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var designStep = uow.DesignStepsRepository.GetById(viewmodel.Id);

                designStep.Id = viewmodel.Id;
                designStep.MainTitle = viewmodel.MainTitle;
                designStep.SubTitle = viewmodel.SubTitle;
                designStep.StepIcon = viewmodel.StepIcon;
                designStep.StepTitle = viewmodel.StepTitle;
                designStep.StepContent = viewmodel.StepContent;
                designStep.StepImageUrl = viewmodel.StepImageUrl;

                uow.DesignStepsRepository.Update(designStep);
                uow.Commit();
              
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var designSteps = uow.DesignStepsRepository.GetById(id);

            DesignStepsViewModel viewmodel = new DesignStepsViewModel
            {
                Id=designSteps.Id,
                MainTitle=designSteps.MainTitle,
                SubTitle=designSteps.SubTitle,
                StepIcon=designSteps.StepIcon,
                StepTitle=designSteps.StepTitle,
                StepContent=designSteps.StepContent,
                StepImageUrl=designSteps.StepImageUrl
            };
            uow.DesignStepsRepository.Remove(designSteps);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var designSteps = uow.DesignStepsRepository.GetById(id);

            DesignStepsViewModel viewmodel = new DesignStepsViewModel
            {
                Id=designSteps.Id,
                MainTitle=designSteps.MainTitle,
                SubTitle=designSteps.SubTitle,
                StepIcon=designSteps.StepIcon,
                StepTitle=designSteps.StepTitle,
                StepContent=designSteps.StepContent,
                StepImageUrl=designSteps.StepImageUrl,
            };

            return View(viewmodel);
        }
    }
}