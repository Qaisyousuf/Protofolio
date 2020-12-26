using QaisYousuf.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class AdminActivityController : Controller
    {
        private readonly IUnitOfWork uow;

        public AdminActivityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: UIToCode/AdminActivity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAdminActivityData()
        {
            var adminActivity = uow.AdminActivityRepository.GetAll();

            List<AdminActivityViewModel> viewmodel = new List<AdminActivityViewModel>();

            foreach (var item in adminActivity)
            {
                var datatime = item.DateTime;
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new AdminActivityViewModel
                {
                    Id=item.Id,
                    Ip=item.Ip,
                    UserAgint=item.UserAgint,
                    ActionName=item.ActionName,
                    ControllerName=item.ControllerName,
                    LoginUser=item.LoginUser,
                    UserBrowser=item.UserBrowser,
                    Time=time,
                    Date=date,
                    AuthenticationActivity=item.AuthenticationActivity,


                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
    }
}