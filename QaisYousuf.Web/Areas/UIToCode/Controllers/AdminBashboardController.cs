using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class AdminBashboardController : Controller
    {
        private readonly IUnitOfWork uow;

        public AdminBashboardController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: UIToCode/AdminBashboard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDashBoardData()
        {
            var adminDashboard = uow.AdminDashboardRepository.GetAll();

            List<AdminDashboardViewModel> DashBoardViewModel = new List<AdminDashboardViewModel>();

            foreach (var item in adminDashboard)
            {
                DashBoardViewModel.Add(new AdminDashboardViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    AuthenticatedUser=item.AuthenticatedUser,
                    LoginDateTime=item.LogintDateTime,
                    LottiAnimationUrl=item.LottiAnimationUrl,
                    
              
                });
            }
            return Json(new { data = DashBoardViewModel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new AdminDashboardViewModel());
        }

        [HttpPost]
        public ActionResult Create(AdminDashboardViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                AdminDashboard dashBoard = new AdminDashboard
                {
                    Id=ViewModel.Id,
                    Title=ViewModel.Title,
                    SubTitle=ViewModel.SubTitle,
                    Content=ViewModel.Content,
                    AuthenticatedUser=User.Identity.Name,
                    LogintDateTime=ViewModel.LoginDateTime,
                    LottiAnimationUrl=ViewModel.LottiAnimationUrl,

                };
                uow.AdminDashboardRepository.Add(dashBoard);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dashBoard = uow.AdminDashboardRepository.GetById(id);

            AdminDashboardViewModel viewmodel = new AdminDashboardViewModel
            {
                Id = dashBoard.Id,
                Title = dashBoard.Title,
                SubTitle = dashBoard.SubTitle,
                Content = dashBoard.Content,
                AuthenticatedUser = User.Identity.Name,
                LoginDateTime=dashBoard.LogintDateTime,
                LottiAnimationUrl=dashBoard.LottiAnimationUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(AdminDashboardViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var dashBoard = uow.AdminDashboardRepository.GetById(viewmodel.Id);

                dashBoard.Id = viewmodel.Id;
                dashBoard.Title = viewmodel.Title;
                dashBoard.SubTitle = viewmodel.SubTitle;
                dashBoard.Content = viewmodel.Content;
                dashBoard.AuthenticatedUser = User.Identity.Name;
                dashBoard.LogintDateTime = DateTime.Now.ToLocalTime();
                dashBoard.LottiAnimationUrl = viewmodel.LottiAnimationUrl;

                uow.AdminDashboardRepository.Update(dashBoard);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dashBoard = uow.AdminDashboardRepository.GetById(id);

            AdminDashboardViewModel viewmodel = new AdminDashboardViewModel
            {
                Id=dashBoard.Id,
                Title=dashBoard.Title,
                SubTitle=dashBoard.SubTitle,
                Content=dashBoard.Content,
                AuthenticatedUser=dashBoard.AuthenticatedUser,
                LoginDateTime=dashBoard.LogintDateTime,
                LottiAnimationUrl=dashBoard.LottiAnimationUrl,
      
            };

            uow.AdminDashboardRepository.Remove(dashBoard);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var adminDashboard = uow.AdminDashboardRepository.GetById(id);

            AdminDashboardViewModel viewmodel = new AdminDashboardViewModel
            {
               Id=adminDashboard.Id,
               Title=adminDashboard.Title,
               SubTitle=adminDashboard.SubTitle,
               Content=adminDashboard.Content,
               AuthenticatedUser=adminDashboard.AuthenticatedUser,
               LoginDateTime=adminDashboard.LogintDateTime,
               LottiAnimationUrl=adminDashboard.LottiAnimationUrl,
            };

            return View(viewmodel);
        }
    }
}