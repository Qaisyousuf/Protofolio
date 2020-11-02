﻿using System;
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

            var portfolioAbout = uow.PortfolioAboutRepository.GetAll();

            List<PortfolioAboutViewModels> PortfolioViewModel = new List<PortfolioAboutViewModels>();

            foreach (var item in portfolioAbout)
            {
                PortfolioViewModel.Add(new PortfolioAboutViewModels
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }

            var workExperience = uow.WorkExperienceRepository.GetAll();

            List<WorkExperienceViewModel> ExperienceViewModel = new List<WorkExperienceViewModel>();

            foreach (var item in workExperience)
            {

                var StartDate = item.StartDate;

                var ConvertedStartDate = Convert.ToDateTime(StartDate.ToLongDateString().ToString());
                ExperienceViewModel.Add(new WorkExperienceViewModel
                {
                    Id=item.Id,
                    MainTitle=item.Maintitle,
                    JobTitle=item.JobTitle,
                    CompanyName=item.CompanyName,
                    CompanyLocation=item.CompanyLocation,
                    LogoUrl=item.LogoUrl,
                    StartDate= ConvertedStartDate,
                    EndDate =item.EndDate,
                    JobDesicription=item.JobDesicription,
                    JobSubDescription=item.JobSubDescription,
                });
            }

            var education = uow.EducationRepository.GetAll();

            List<EducationViewModel> EduViewModel = new List<EducationViewModel>();

            foreach (var item in education)
            {
                EduViewModel.Add(new EducationViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }


            var onlineCertificate = uow.OnlineCertificationRepository.GetAll();

            List<OnlineCertificateViewModel> Onlinecertificateviewmodel = new List<OnlineCertificateViewModel>();

            foreach (var item in onlineCertificate)
            {
                Onlinecertificateviewmodel.Add(new OnlineCertificateViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    ProgramName=item.ProgramName,
                    CourseLocation=item.CourseLocation,
                    IconUrl=item.IconUrl,
                    CourseDescription=item.CourseDescription,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    FinishDate=item.FinishDate,
                });
            }

            ListPortfolio ListPortfolioContent = new ListPortfolio
            {
                ListPortfolioViewModle=ViewModel,
                ListPortfolioAboutViewModel=PortfolioViewModel,
                ListWorkExperienceViewModel=ExperienceViewModel,
                ListEducationViewModel=EduViewModel,
                ListofOnlineCertificationViewModel=Onlinecertificateviewmodel,
                
            };
            return View(ListPortfolioContent);
        }
    }
}