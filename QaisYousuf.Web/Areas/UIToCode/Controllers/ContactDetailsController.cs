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
                var dateTimeOfWeek = item.WorkingDateTimeOfWeek;

                var TimeOfWeek = Convert.ToDateTime(dateTimeOfWeek.ToShortTimeString());
                var DateOfWeek = Convert.ToDateTime(dateTimeOfWeek.ToShortDateString());
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new ContactDetailsViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    HomeAddress=item.HomeAddress,
                    CountryName=item.CountryName,
                    Moible=item.Moible,
                    Email=item.Email,
                    SaleEamil=item.SaleEamil,
                    WorkingTime=time,
                    WorkingData=date,
                    WorkingTimeofWeek=TimeOfWeek,
                    WrokingDateOfWeek=dateTimeOfWeek,
                    
                    
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
                var TimeOfWeek = Convert.ToDateTime(viewmodel.WorkingTimeofWeek.ToShortTimeString());
                var DateOfWeek = Convert.ToDateTime(viewmodel.WrokingDateOfWeek.ToShortDateString());
                var ConvertedDateTimeOfWeek = new DateTime(DateOfWeek.Year, DateOfWeek.Month, DateOfWeek.Day, TimeOfWeek.Hour, TimeOfWeek.Minute, TimeOfWeek.Second);
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
                    WorkingDateTimeOfWeek=ConvertedDateTimeOfWeek,
                    CountryName=viewmodel.CountryName,
                    SaleEamil=viewmodel.SaleEamil,
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

            var ConvertedDatTimeOfWeekFromModel = contactDetails.WorkingDateTimeOfWeek;
            var TimeOfWeek = Convert.ToDateTime(ConvertedDatTimeOfWeekFromModel.ToShortTimeString());
            var DateOfWeek = Convert.ToDateTime(ConvertedDatTimeOfWeekFromModel.ToShortDateString());

            var ConvertedDataTimeFormModel = contactDetails.WorkingTime;
            var time = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortTimeString());
            var date = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortDateString());

            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id=contactDetails.Id,
                Title=contactDetails.Title,
                HomeAddress=contactDetails.HomeAddress,
                CountryName=contactDetails.CountryName,
                SaleEamil=contactDetails.SaleEamil,
                Moible=contactDetails.Moible,
                Email=contactDetails.Email,
                WorkingTime=time,
                WorkingData=date,
                WorkingTimeofWeek=TimeOfWeek,
                WrokingDateOfWeek=DateOfWeek

            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                DateTime TimeOfWeek = Convert.ToDateTime(viewmodel.WorkingTime.ToShortTimeString());
                DateTime DateOfWeek = Convert.ToDateTime(viewmodel.WorkingData.ToShortDateString());
                DateTime ConvertedDataTimeOfWeek = new DateTime(DateOfWeek.Year, DateOfWeek.Month, DateOfWeek.Day, TimeOfWeek.Hour, TimeOfWeek.Minute, TimeOfWeek.Second);
                DateTime time = Convert.ToDateTime(viewmodel.WorkingTime.ToShortTimeString());
                DateTime date = Convert.ToDateTime(viewmodel.WorkingData.ToShortDateString());
                DateTime ConvertedDataTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

                var contactDetials = uow.ContactDetialsRepository.GetById(viewmodel.Id);
                contactDetials.Id = viewmodel.Id;
                contactDetials.Title = viewmodel.Title;
                contactDetials.HomeAddress = viewmodel.HomeAddress;
                contactDetials.CountryName = viewmodel.CountryName;
                contactDetials.Moible = viewmodel.Moible;
                contactDetials.Email = viewmodel.Email;
                contactDetials.SaleEamil = viewmodel.SaleEamil;
                contactDetials.WorkingTime = ConvertedDataTime;
                contactDetials.WorkingDateTimeOfWeek = ConvertedDataTimeOfWeek;

                uow.ContactDetialsRepository.Update(contactDetials);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactDetails = uow.ContactDetialsRepository.GetById(id);

            var ConvertedDateTimeFromModelOfWeek = contactDetails.WorkingDateTimeOfWeek;
            var timeOfWeek = Convert.ToDateTime(ConvertedDateTimeFromModelOfWeek.ToShortTimeString());
            var DateOfWeek = Convert.ToDateTime(ConvertedDateTimeFromModelOfWeek.ToShortDateString());
            var ConvertedDataTimeFormModel = contactDetails.WorkingTime;
            var time = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortTimeString());
            var date = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortDateString());
            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id = contactDetails.Id,
                Title = contactDetails.Title,
                HomeAddress = contactDetails.HomeAddress,
                CountryName=contactDetails.CountryName,
                SaleEamil=contactDetails.SaleEamil,
                Moible = contactDetails.Moible,
                Email = contactDetails.Email,
                WorkingTime = time,
                WorkingData = date,
                WorkingTimeofWeek = timeOfWeek,
                WrokingDateOfWeek = DateOfWeek,
            };
            uow.ContactDetialsRepository.Remove(contactDetails);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactDetails = uow.ContactDetialsRepository.GetById(id);

            var ConvertedDateTimeOfWeekFromModel = contactDetails.WorkingDateTimeOfWeek;
            var TimeOfWeek = Convert.ToDateTime(ConvertedDateTimeOfWeekFromModel.ToShortTimeString());
            var DateOfWeek = Convert.ToDateTime(ConvertedDateTimeOfWeekFromModel.ToShortDateString());

            var ConvertedDataTimeFormModel = contactDetails.WorkingTime;
            var time = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortTimeString());
            var date = Convert.ToDateTime(ConvertedDataTimeFormModel.ToShortDateString());
            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id = contactDetails.Id,
                Title = contactDetails.Title,
                HomeAddress = contactDetails.HomeAddress,
                CountryName=contactDetails.CountryName,
                SaleEamil=contactDetails.SaleEamil,
                Moible = contactDetails.Moible,
                Email = contactDetails.Email,
                WorkingTime = time,
                WorkingData = date,
                WorkingTimeofWeek=TimeOfWeek,
                WrokingDateOfWeek=DateOfWeek,
            };

            return View(viewmodel);
        }
        
    }
}