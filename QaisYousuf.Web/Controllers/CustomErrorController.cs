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
    public class CustomErrorController : Controller
    {
        // GET: CustomError
        public ActionResult Index()
        {
            return View();
        }

        [Route("PageNotFount")]
        public ActionResult PageNotFount()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}