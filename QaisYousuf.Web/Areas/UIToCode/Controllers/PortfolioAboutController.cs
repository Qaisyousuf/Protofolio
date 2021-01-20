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
    public class PortfolioAboutController : Controller
    {
        private readonly IUnitOfWork uow;

        public PortfolioAboutController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPortfolioAboutData()
        {
            var portfolioAbout = uow.PortfolioAboutRepository.GetAll();

            List<PortfolioAboutViewModels> viewmodel = new List<PortfolioAboutViewModels>();

            foreach (var item in portfolioAbout)
            {
                viewmodel.Add(new PortfolioAboutViewModels
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PortfolioAboutViewModels());
        }

        [HttpPost]
        public ActionResult Create(PortfolioAboutViewModels viewmodel)
        {
           if(ModelState.IsValid)
            {
                PortfolioAbout portfolioAbout = new PortfolioAbout
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Content = viewmodel.Content,
                    ImageUrl = viewmodel.ImageUrl,
                    ButtonText = viewmodel.ButtonText,
                    ButtonUrl = viewmodel.ButtonUrl,
                };

                uow.PortfolioAboutRepository.Add(portfolioAbout);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var portfolioAbout = uow.PortfolioAboutRepository.GetById(id);

            PortfolioAboutViewModels viewmodel = new PortfolioAboutViewModels
            {
                Id=portfolioAbout.Id,
                MainTitle=portfolioAbout.MainTitle,
                Content=portfolioAbout.Content,
                ImageUrl=portfolioAbout.ImageUrl,
                ButtonText=portfolioAbout.ButtonText,
                ButtonUrl=portfolioAbout.ButtonUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(PortfolioAboutViewModels viewmodel)
        {
            if(ModelState.IsValid)
            {
                var portfolioAbout = uow.PortfolioAboutRepository.GetById(viewmodel.Id);

                portfolioAbout.Id = viewmodel.Id;
                portfolioAbout.MainTitle = viewmodel.MainTitle;
                portfolioAbout.Content = viewmodel.Content;
                portfolioAbout.ImageUrl = viewmodel.ImageUrl;
                portfolioAbout.ButtonText = viewmodel.ButtonText;
                portfolioAbout.ButtonUrl = viewmodel.ButtonUrl;

                uow.PortfolioAboutRepository.Update(portfolioAbout);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var portfolioAbout = uow.PortfolioAboutRepository.GetById(id);

            PortfolioAboutViewModels viewmodel = new PortfolioAboutViewModels
            {
                Id=portfolioAbout.Id,
                MainTitle=portfolioAbout.MainTitle,
                Content=portfolioAbout.Content,
                ButtonText=portfolioAbout.ButtonText,
                ButtonUrl=portfolioAbout.ButtonUrl,
                ImageUrl=portfolioAbout.ImageUrl,
            };

            uow.PortfolioAboutRepository.Remove(portfolioAbout);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var portfolioAbout = uow.PortfolioAboutRepository.GetById(id);

            PortfolioAboutViewModels viewmodel = new PortfolioAboutViewModels
            {
                Id = portfolioAbout.Id,
                MainTitle = portfolioAbout.MainTitle,
                Content = portfolioAbout.Content,
                ButtonText = portfolioAbout.ButtonText,
                ButtonUrl = portfolioAbout.ButtonUrl,
                ImageUrl = portfolioAbout.ImageUrl,
            };

            return View(viewmodel);
        }
        
    }
}