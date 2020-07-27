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
    public class ContactMattersController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactMattersController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContactMattersData()
        {
            var contactMatters = uow.ContactMatterRepository.GetAll();

            List<ContactMattersViewModel> viewmodel = new List<ContactMattersViewModel>();

            foreach (var item in contactMatters)
            {
                viewmodel.Add(new ContactMattersViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    MapApi=item.MapApi,
                    ButtonText=item.ButtonText,
                    ImageUrl=item.ImageUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContactMattersViewModel());
        }

        [HttpPost]
        public ActionResult Create(ContactMattersViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                ContactMatters contactMatters = new ContactMatters
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    MapApi=viewmodel.MapApi,
                    ButtonText=viewmodel.ButtonText,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.ContactMatterRepository.Add(contactMatters);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactMatter = uow.ContactMatterRepository.GetById(id);

            ContactMattersViewModel viewmodel = new ContactMattersViewModel
            {
                Id=contactMatter.Id,
                Title=contactMatter.Title,
                Content=contactMatter.Content,
                MapApi=contactMatter.MapApi,
                ButtonText=contactMatter.ButtonText,
                ImageUrl=contactMatter.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactMattersViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var contactMatter = uow.ContactMatterRepository.GetById(viewmodel.Id);

                contactMatter.Id = viewmodel.Id;
                contactMatter.Title = viewmodel.Title;
                contactMatter.Content = viewmodel.Content;
                contactMatter.MapApi = viewmodel.MapApi;
                contactMatter.ButtonText = viewmodel.ButtonText;
                contactMatter.ImageUrl = viewmodel.ImageUrl;

                uow.ContactMatterRepository.Update(contactMatter);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactMatter = uow.ContactMatterRepository.GetById(id);

            ContactMattersViewModel viewmodel = new ContactMattersViewModel
            {
                Id=contactMatter.Id,
                Title=contactMatter.Title,
                Content=contactMatter.Content,
                MapApi=contactMatter.MapApi,
                ButtonText=contactMatter.ButtonText,
                ImageUrl=contactMatter.ImageUrl,
            };

            uow.ContactMatterRepository.Remove(contactMatter);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactMatter = uow.ContactMatterRepository.GetById(id);

            ContactMattersViewModel viewmodel = new ContactMattersViewModel
            {
                Id = contactMatter.Id,
                Title = contactMatter.Title,
                Content = contactMatter.Content,
                MapApi = contactMatter.MapApi,
                ButtonText = contactMatter.ButtonText,
                ImageUrl = contactMatter.ImageUrl,
            };

            return View(viewmodel);
        }
    }
}