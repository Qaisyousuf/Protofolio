using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;
using QaisYousuf.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QaisYousuf.Web.Controllers
{
    [UserActivityFilter]
    [AdminActivityFilter]
    public class UserDashboardController : Controller
    {
        
        private readonly IUnitOfWork uow;

        public UserDashboardController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [Route("UserDashboard")]
        // GET: UserDashboard
        public ActionResult Index()
        {
            return View(new UserDashboardViewModel());
        }

        
        public ActionResult GetUserDashboard()
        {
            var user = uow.UserRepository.GetAll();

           

            var userDashboard = uow.UserDashboardRepository.GetAll();

            List<UserDashboardViewModel> viewmodel = new List<UserDashboardViewModel>();

            foreach (var item in userDashboard)
            {
                viewmodel.Add(new UserDashboardViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    AuthenticatedUser=User.Identity.Name,
                    Content=item.Content,
                    ProjectStartDate=item.ProjectStartDate,
                    ProjectFinishDate=item.ProjectFinishDate,
                    ProjectName=item.ProjectName,
                    ProjectType=item.ProjectType,
                    
                    UserId=item.UserId,

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{

        //}
    }
}