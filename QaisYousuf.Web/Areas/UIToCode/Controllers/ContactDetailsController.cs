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
    public class ContactDetailsController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactDetailsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContactDetailsData()
        {
            var contactDetails = uow.ContactDetialsRepository.GetAll();

            List<ContactDetailsViewModel> viewmodel = new List<ContactDetailsViewModel>();

            foreach (var item in contactDetails)
            {
                var datatime = item.WorkingTime;
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new ContactDetailsViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    HomeAddress=item.HomeAddress,
                    Moible=item.Moible,
                    Email=item.Email,
                    WorkingTime=time,
                    WorkingData=date
                    
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContactDetailsViewModel());
        }

        [HttpPost]
        public ActionResult Create(ContactDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                
                //Data Time Converstion From Viewmodel
                var time = Convert.ToDateTime(viewmodel.WorkingTime.ToShortTimeString());
                var date = Convert.ToDateTime(viewmodel.WorkingData.ToShortDateString());
                var ConvertedDataTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                ContactDetails contactDetails = new ContactDetails
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    HomeAddress=viewmodel.HomeAddress,
                    Moible=viewmodel.Moible,
                    Email=viewmodel.Email,
                    WorkingTime=ConvertedDataTime,
                };

                uow.ContactDetialsRepository.Add(contactDetails);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactDetails = uow.ContactDetialsRepository.GetById(id);

            var ConvertedDataTimeFormModel = contactDetails.WorkingTime;
            var time = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortTimeString());
            var date = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortDateString());

            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id=contactDetails.Id,
                Title=contactDetails.Title,
                HomeAddress=contactDetails.HomeAddress,
                Moible=contactDetails.Moible,
                Email=contactDetails.Email,
                WorkingTime=time,
                WorkingData=date,
                
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                DateTime time = Convert.ToDateTime(viewmodel.WorkingTime.ToShortTimeString());
                DateTime date = Convert.ToDateTime(viewmodel.WorkingData.ToShortDateString());
                DateTime ConvertedDataTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                var contactDetials = uow.ContactDetialsRepository.GetById(viewmodel.Id);

                contactDetials.Id = viewmodel.Id;
                contactDetials.Title = viewmodel.Title;
                contactDetials.HomeAddress = viewmodel.HomeAddress;
                contactDetials.Moible = viewmodel.Moible;
                contactDetials.Email = viewmodel.Email;
                contactDetials.WorkingTime = ConvertedDataTime;

                uow.ContactDetialsRepository.Update(contactDetials);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactDetails = uow.ContactDetialsRepository.GetById(id);

            var ConvertedDataTimeFormModel = contactDetails.WorkingTime;
            var time = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortTimeString());
            var date = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortDateString());
            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id=contactDetails.Id,
                Title=contactDetails.Title,
                HomeAddress=contactDetails.HomeAddress,
                Moible=contactDetails.Moible,
                Email=contactDetails.Email,
                WorkingTime=time,
                WorkingData=date,
            };
            uow.ContactDetialsRepository.Remove(contactDetails);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactDetails = uow.ContactDetialsRepository.GetById(id);

            var ConvertedDataTimeFormModel = contactDetails.WorkingTime;
            var time = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortTimeString());
            var date = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortDateString());
            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id = contactDetails.Id,
                Title = contactDetails.Title,
                HomeAddress = contactDetails.HomeAddress,
                Moible = contactDetails.Moible,
                Email = contactDetails.Email,
                WorkingTime = time,
                WorkingData = date,
            };

            return View(viewmodel);
        }
        
    }
}