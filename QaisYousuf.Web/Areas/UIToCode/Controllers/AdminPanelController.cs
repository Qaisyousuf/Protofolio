using QaisYousuf.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    
    public class AdminPanelController : Controller
    {
        private readonly IUnitOfWork uow;

        public AdminPanelController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: UIToCode/AdminPanel
        public ActionResult Index()
        {

            var adminPanel = uow.AdminDashboardRepository.GetAll();


            List<AdminDashboardViewModel> viewmodel = new List<AdminDashboardViewModel>();

            foreach (var item in adminPanel)
            {
                viewmodel.Add(new AdminDashboardViewModel
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



            return View(viewmodel);
        }
    }
}