using QaisYousuf.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class HomeBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var banner = uow.HomeBannerRepository.GetAll();
            return View(banner);
        }
    }
}