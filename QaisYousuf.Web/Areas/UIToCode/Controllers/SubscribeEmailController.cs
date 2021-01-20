using QaisYousuf.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class SubscribeEmailController : Controller
    {
        private readonly IUnitOfWork uow;

        public SubscribeEmailController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSubscribeEamil()
        {
            var subscribEmail = uow.SubscriberEmailRepository.GetAll();

            List<SubscriberEmailViewModel> viewmodel = new List<SubscriberEmailViewModel>();

            foreach (var item in subscribEmail)
            {
                viewmodel.Add(new SubscriberEmailViewModel
                {
                    Id=item.Id,
                    Email=item.Email,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var subscribeEmail = uow.SubscriberEmailRepository.GetById(id);

            SubscriberEmailViewModel viewmodel = new SubscriberEmailViewModel
            {
                Id=subscribeEmail.Id,
                Email=subscribeEmail.Email,
            };

            uow.SubscriberEmailRepository.Remove(subscribeEmail);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var subscribeEmail = uow.SubscriberEmailRepository.GetById(id);

            SubscriberEmailViewModel viewmodel = new SubscriberEmailViewModel
            {
                Id = subscribeEmail.Id,
                Email = subscribeEmail.Email,
            };
            return View(viewmodel);
        }
    }
}