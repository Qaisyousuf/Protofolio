using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Controllers
{
    public class TechnologyToolsController : BaseController
    {
        
        [Route("Technologies")]
        public ActionResult Index()
        {
            var codeBanner = Uow.CodeBannerRepository.GetAll();

            List<CodeBannerViewModel> viewmodel = new List<CodeBannerViewModel>();

            foreach (var item in codeBanner)
            {
                viewmodel.Add(new CodeBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText,
                    ImageUrl=item.ImageUrl,
                });
            }

            var programmingTools = Uow.WebProgrammingToolsRepository.GetAll();

            List<WebProgrammingToolsViewModel> WebProgrammingViewModel = new List<WebProgrammingToolsViewModel>();

            foreach (var WebItem in programmingTools)
            {
                WebProgrammingViewModel.Add(new WebProgrammingToolsViewModel
                {
                    Id=WebItem.Id,
                    MainTitle=WebItem.MainTitle,
                    ImageUrl=WebItem.ImageUrl,
                    IconUrl=WebItem.IconUrl,
                    ProgramTitle=WebItem.ProgramTitle,
                });
            }

            var uiUXTools = Uow.UIUXToolsRepository.GetAll();

            List<UIUXToolsViewModel> UIUXToolsViewModel = new List<UIUXToolsViewModel>();

            foreach (var item in uiUXTools)
            {
                UIUXToolsViewModel.Add(new ViewModels.UIUXToolsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    IconUrl=item.IconUrl,
                    ProgramTitle=item.ProgramTitle,
                    ImageUrl=item.ImageUrl

                });
            }

            var desingCode = Uow.DesignCodeSectionRepository.GetAll();

            List<DesignCodeViewModel> DesignCodeViewModel = new List<DesignCodeViewModel>();

            foreach (var item in desingCode)
            {
                DesignCodeViewModel.Add(new ViewModels.DesignCodeViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    ImageUrl = item.ImageUrl,
                });
            }

            ListOfCodePages CodeList = new ListOfCodePages
            {
                ListOfCodeBannerViewModel=viewmodel,
                ListOfWebProgramming=WebProgrammingViewModel,
                ListUIUXToolsViewModel=UIUXToolsViewModel,
                ListCodeDesignViewModel=DesignCodeViewModel,
            };

            return View(CodeList);
        }
    }
}