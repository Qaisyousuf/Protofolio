using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Controllers
{
    public class UIUXController :BaseController
    {
        [Route("UIUX")]
        public ActionResult Index()
        {
            var uiUXPage = uow.UIBannerRepository.GetAll();

            List<UIBannerViewModel> UIUXBannerViewModle = new List<UIBannerViewModel>();

            foreach (var item in uiUXPage)
            {
                UIUXBannerViewModle.Add(new UIBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText,
                    ImageUrl=item.ImageUrl,
                });
            }


            var uiProcess = uow.UIProcessRepository.GetAll();

            List<UIProcessViewModel> uIprocessViewModel = new List<UIProcessViewModel>();

            foreach (var item in uiProcess)
            {
                uIprocessViewModel.Add(new UIProcessViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }
            ListUIUX UIUXViewModel = new ListUIUX
            {
                ListUIUXBannerViewModel = UIUXBannerViewModle,
                ListOfUIProcessViewModel=uIprocessViewModel,
                
            };

            return View(UIUXViewModel);
        }
    }
}