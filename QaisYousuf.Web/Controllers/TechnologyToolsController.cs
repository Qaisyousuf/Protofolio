﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;
using QaisYousuf.Models;
using QaisYousuf.Web.Infrastructure;

namespace QaisYousuf.Web.Controllers
{
    [UserActivityFilter]
    [AdminActivityFilter]
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

            var subscribe = Uow.SubscribeRepository.GetAll();

            List<SubscribeViewModel> ViewModelSubscribe = new List<SubscribeViewModel>();

            foreach (var item in subscribe)
            {
                ViewModelSubscribe.Add(new SubscribeViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    Email=item.Email,
                    Buttontext=item.Buttontext,
                    ModalMessage=item.ModalMessage,
                    ImageUrl=item.ImageUrl,
                });
            }

            ListOfCodePages CodeList = new ListOfCodePages
            {
                ListOfCodeBannerViewModel=viewmodel,
                ListOfWebProgramming=WebProgrammingViewModel,
                ListUIUXToolsViewModel=UIUXToolsViewModel,
                ListCodeDesignViewModel=DesignCodeViewModel,
                ListOfSubscribeViewModel=ViewModelSubscribe,
            };

            return View(CodeList);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View(new SubscriberEmailViewModel());
        }
        [HttpPost]
        public ActionResult Create(SubscriberEmailViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                SubscriberEmail email = new SubscriberEmail
                {
                    Id=viewmodel.Id,
                    Email=viewmodel.Email,
                };

                Uow.SubscriberEmailRepository.Add(email);
                Uow.Commit();
                TempData["Success"] ="Your Email : " + email.Email  + "  subscribed successfully";
                
                
            }
            return View(viewmodel);
        }
    }
}