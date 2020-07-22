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
    public class SubscribeController : Controller
    {
        private readonly IUnitOfWork uow;

        public SubscribeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSubscribeData()
        {
            var subScribe = uow.SubscribeRepository.GetAll();

            List<SubscribeViewModel> viewmodel = new List<SubscribeViewModel>();

            foreach (var item in subScribe)
            {
                viewmodel.Add(new SubscribeViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    Email=item.Email,
                    Buttontext=item.Buttontext,
                    ModalMessage=item.ModalMessage,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SubscribeViewModel());
        }

        [HttpPost]
        public ActionResult Create(SubscribeViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                Subscribe subScribe = new Subscribe
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    Email=viewmodel.Email,
                    Buttontext=viewmodel.Buttontext,
                    ModalMessage=viewmodel.ModalMessage,
                    ImageUrl=viewmodel.ImageUrl
                };

                uow.SubscribeRepository.Add(subScribe);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var subScribe = uow.SubscribeRepository.GetById(id);

            SubscribeViewModel viewmodel = new SubscribeViewModel
            {
                Id=subScribe.Id,
                Title=subScribe.Title,
                Content=subScribe.Content,
                Email=subScribe.Email,
                Buttontext=subScribe.Buttontext,
                ModalMessage=subScribe.ModalMessage,
                ImageUrl=subScribe.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SubscribeViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var subScribe = uow.SubscribeRepository.GetById(viewmodel.Id);

                subScribe.Id = viewmodel.Id;
                subScribe.Title = viewmodel.Title;
                subScribe.Content = viewmodel.Content;
                subScribe.Email = viewmodel.Email;
                subScribe.Buttontext = viewmodel.Buttontext;
                subScribe.ModalMessage = viewmodel.ModalMessage;
                subScribe.ImageUrl = viewmodel.ImageUrl;

                uow.SubscribeRepository.Update(subScribe);
                uow.Commit();
                
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var subScribe = uow.SubscribeRepository.GetById(id);

            SubscribeViewModel viewmodel = new SubscribeViewModel
            {
                Id=subScribe.Id,
                Title=subScribe.Title,
                Content=subScribe.Content,
                Email=subScribe.Email,
                Buttontext=subScribe.Buttontext,
                ModalMessage=subScribe.ModalMessage,
                ImageUrl=subScribe.ImageUrl,
            };

            uow.SubscribeRepository.Remove(subScribe);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var subScribe = uow.SubscribeRepository.GetById(id);

            SubscribeViewModel viewmodel = new SubscribeViewModel
            {
                Id = subScribe.Id,
                Title = subScribe.Title,
                Content = subScribe.Content,
                Email = subScribe.Email,
                Buttontext = subScribe.Buttontext,
                ModalMessage = subScribe.ModalMessage,
                ImageUrl = subScribe.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}