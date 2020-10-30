using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Controllers
{
    public class PortfolioController : BaseController
    {
        [Route("Portfolio")]
        public ActionResult Index()
        {
            var portfolio = uow.PortfolioBannerRepository.GetAll();

            List<PortfolioBannerViewModel> ViewModel = new List<PortfolioBannerViewModel>();

            foreach (var item in portfolio)
            {
                ViewModel.Add(new PortfolioBannerViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    SubTitle=item.SubTitle,
                    BackgroundImage=item.BackgroundImage,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }

            ListPortfolio ListPortfolioContent = new ListPortfolio
            {
                ListPortfolioViewModle=ViewModel,
            };
            return View(ListPortfolioContent);
        }
    }
}