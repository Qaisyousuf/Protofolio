using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class ThankYouPageBackEndController : Controller
    {
        private readonly IUnitOfWork uow;

        public ThankYouPageBackEndController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetThankYouPageData()
        {
            var thankYou = uow.ThankYouPageRepository.GetAll();

            List<ThankYouPageViewModel> ThankYouViewModel = new List<ThankYouPageViewModel>();


            foreach (var item in thankYou)
            {
                ThankYouViewModel.Add(new ThankYouPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    
                });
            }
            return Json(new { data = ThankYouViewModel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ThankYouPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(ThankYouPageViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                ThankYouPage thankyou = new ThankYouPage
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    
                };

                uow.ThankYouPageRepository.Add(thankyou);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}