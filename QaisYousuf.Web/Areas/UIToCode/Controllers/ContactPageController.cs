using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using QaisYousuf.Services;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class ContactPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public void GetContactPageRelatedData()
        {
            ViewBag.ContactBanner = uow.ContactBannerRepository.GetAll();
            ViewBag.ContactDetails = uow.ContactDetialsRepository.GetAll();
            ViewBag.ContactMatter = uow.ContactMatterRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetContactPageData()
        {
            var contactPage = uow.ContactPageRepository.GetAll("ContactBanner","ContactDetails", "ContactMatters");

            List<ContactPageViewModel> viewmodel = new List<ContactPageViewModel>();

            foreach (var item in contactPage)
            {
                viewmodel.Add(new ContactPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    MetaKeywords=item.MetaKeywords,
                    MetaDescription=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    BannerId=item.BannerId,
                    ContactBanner=item.ContactBanner,
                    ContactDetailsId=item.CotnactDetailsId,
                    ContactDetails=item.ContactDetails,
                    ContactMattersId=item.ContactMattersId,
                    ContactMatters=item.ContactMatters,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetContactPageRelatedData();
            return View(new ContactPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(ContactPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetContactPageRelatedData();
                return View(viewmodel);
            }
            string slug;

            ContactPage contactPage = new ContactPage();

            contactPage.Id = viewmodel.Id;
            contactPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.ContactPageRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                GetContactPageRelatedData();
                return View(viewmodel);
            }

            contactPage.Slug = slug;
            contactPage.MetaKeywords = viewmodel.MetaKeywords;
            contactPage.MetaDescription = viewmodel.MetaDescription;
            contactPage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            contactPage.BannerId = viewmodel.BannerId;
            contactPage.ContactBanner = viewmodel.ContactBanner;
            contactPage.CotnactDetailsId = viewmodel.ContactDetailsId;
            contactPage.ContactDetails = viewmodel.ContactDetails;
            contactPage.ContactMattersId = viewmodel.ContactMattersId;
            contactPage.ContactMatters = viewmodel.ContactMatters;

            uow.ContactPageRepository.Add(contactPage);
            uow.Commit();

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactPage = uow.ContactPageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id=contactPage.Id,
                Title=contactPage.Title,
                Slug=contactPage.Slug,
                MetaKeywords=contactPage.MetaKeywords,
                MetaDescription=contactPage.MetaDescription,
                IsVisibleToSearchEngine=contactPage.IsVisibleToSearchEngine,
                BannerId=contactPage.BannerId,
                ContactBanner=contactPage.ContactBanner,
                ContactDetailsId=contactPage.CotnactDetailsId,
                ContactDetails=contactPage.ContactDetails,
                ContactMattersId=contactPage.ContactMattersId,
                ContactMatters=contactPage.ContactMatters,
            };
            GetContactPageRelatedData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetContactPageRelatedData();
                return View(viewmodel);
            }

            var contactPage = uow.ContactPageRepository.GetById(viewmodel.Id);

            string slug;
            contactPage.Id = viewmodel.Id;
            contactPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.ContactPageRepository.SlugExists(viewmodel.Id, slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                GetContactPageRelatedData();
                return View(viewmodel);
            }

            contactPage.Slug = slug;
            contactPage.MetaKeywords = viewmodel.MetaKeywords;
            contactPage.MetaDescription = viewmodel.MetaDescription;
            contactPage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            contactPage.BannerId = viewmodel.BannerId;
            contactPage.ContactBanner = viewmodel.ContactBanner;
            contactPage.CotnactDetailsId = viewmodel.ContactDetailsId;
            contactPage.ContactDetails = viewmodel.ContactDetails;
            contactPage.ContactMattersId = viewmodel.ContactMattersId;
            contactPage.ContactMatters = viewmodel.ContactMatters;

            uow.ContactPageRepository.Update(contactPage);
            uow.Commit();

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactPage = uow.ContactPageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id = contactPage.Id,
                Title = contactPage.Title,
                Slug = contactPage.Slug,
                MetaKeywords = contactPage.MetaKeywords,
                MetaDescription = contactPage.MetaDescription,
                IsVisibleToSearchEngine = contactPage.IsVisibleToSearchEngine,
                BannerId = contactPage.BannerId,
                ContactBanner = contactPage.ContactBanner,
                ContactDetailsId = contactPage.CotnactDetailsId,
                ContactDetails = contactPage.ContactDetails,
                ContactMattersId = contactPage.ContactMattersId,
                ContactMatters = contactPage.ContactMatters,
            };

            uow.ContactPageRepository.Remove(contactPage);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactPage = uow.ContactPageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id = contactPage.Id,
                Title = contactPage.Title,
                Slug = contactPage.Slug,
                MetaKeywords = contactPage.MetaKeywords,
                MetaDescription = contactPage.MetaDescription,
                IsVisibleToSearchEngine = contactPage.IsVisibleToSearchEngine,
                BannerId = contactPage.BannerId,
                ContactBanner = contactPage.ContactBanner,
                ContactDetailsId = contactPage.CotnactDetailsId,
                ContactDetails = contactPage.ContactDetails,
                ContactMattersId = contactPage.ContactMattersId,
                ContactMatters = contactPage.ContactMatters,
            };
            return View(viewmodel);
        }

    }
}