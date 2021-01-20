using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class UserActivityController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserActivityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: UIToCode/UserActivity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUserActivity()
        {
            var userActivity = uow.UserActivityRepository.GetAll();

            List<UserActivityViewModel> viewmodel = new List<UserActivityViewModel>();

            foreach (var item in userActivity)
            {
                var datatime = item.DateTime;
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new UserActivityViewModel
                {
                    Id=item.Id,
                    Ip=item.Ip,
                    UserAgint=item.UserAgint,
                    ActionName=item.ActionName,
                    ControllerName=item.ControllerName,
                    LoginUser=item.LoginUser,
                    UserBrowser=item.UserBrowser,
                    DateTime=item.DateTime,
                    AuthenticationActivity=item.AuthenticationActivity,

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var userActivity = uow.UserActivityRepository.GetById(id);

            UserActivityViewModel viewmodel = new UserActivityViewModel
            {
                Id=userActivity.Id,
                Ip=userActivity.Ip,
                UserAgint=userActivity.UserAgint,
                ActionName=userActivity.ActionName,
                ControllerName=userActivity.ControllerName,
                LoginUser=userActivity.LoginUser,
                UserBrowser=userActivity.UserBrowser,
                DateTime=userActivity.DateTime,
                AuthenticationActivity=userActivity.AuthenticationActivity,
            };

            uow.UserActivityRepository.Remove(userActivity);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userActivity = uow.UserActivityRepository.GetById(id);

            UserActivityViewModel viewmodel = new UserActivityViewModel
            {
                Id = userActivity.Id,
                Ip = userActivity.Ip,
                UserAgint = userActivity.UserAgint,
                ActionName = userActivity.ActionName,
                ControllerName = userActivity.ControllerName,
                LoginUser = userActivity.LoginUser,
                UserBrowser = userActivity.UserBrowser,
                DateTime = userActivity.DateTime,
                AuthenticationActivity = userActivity.AuthenticationActivity,
            };

            return View(viewmodel);
        }
    }
}