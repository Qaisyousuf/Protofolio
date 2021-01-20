using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class ContactFormBackEndController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactFormBackEndController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContactFormData()
        {
            var contactForm = uow.ContactFormRepository.GetAll();

            List<ContactFormViewModel> viewmodel = new List<ContactFormViewModel>();


            foreach (var item in contactForm)
            {
                viewmodel.Add(new ContactFormViewModel
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    Moible = item.Moible,
                    Message = item.Message,
                    IpAddress = item.IpAddress,
                });

            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactDelete = uow.ContactFormRepository.GetById(id);

            ContactFormViewModel viemoodel = new ContactFormViewModel
            {
                Id = contactDelete.Id,
                FullName = contactDelete.FullName,
                Email = contactDelete.Email,
                Moible = contactDelete.Moible,
                Message = contactDelete.Message,
                IpAddress = contactDelete.IpAddress,
            };

            uow.ContactFormRepository.Remove(contactDelete);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactDelete = uow.ContactFormRepository.GetById(id);

            ContactFormViewModel viemoodel = new ContactFormViewModel
            {
                Id = contactDelete.Id,
                FullName = contactDelete.FullName,
                Email = contactDelete.Email,
                Moible = contactDelete.Moible,
                Message = contactDelete.Message,
                IpAddress = contactDelete.IpAddress,
            };
            return View(viemoodel);
        }
    }
}