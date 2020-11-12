using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Controllers
{
    public class ProfileController : BaseController
    {
        [Route("Profile")]
        public ActionResult Index()
        {
            var portfolio = uow.PortfolioBannerRepository.GetAll();

            List<PortfolioBannerViewModel> ViewModel = new List<PortfolioBannerViewModel>();

            foreach (var item in portfolio)
            {
                ViewModel.Add(new PortfolioBannerViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    SubTitle = item.SubTitle,
                    BackgroundImage = item.BackgroundImage,
                    ButtonText = item.ButtonText,
                    ButtonUrl = item.ButtonUrl,
                });
            }

            var portfolioAbout = uow.PortfolioAboutRepository.GetAll();

            List<PortfolioAboutViewModels> PortfolioViewModel = new List<PortfolioAboutViewModels>();

            foreach (var item in portfolioAbout)
            {
                PortfolioViewModel.Add(new PortfolioAboutViewModels
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    ButtonText = item.ButtonText,
                    ButtonUrl = item.ButtonUrl,
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
                    Id = item.Id,
                    MainTitle = item.Maintitle,
                    JobTitle = item.JobTitle,
                    CompanyName = item.CompanyName,
                    CompanyLocation = item.CompanyLocation,
                    LogoUrl = item.LogoUrl,
                    StartDate = ConvertedStartDate,
                    EndDate = item.EndDate,
                    JobDesicription = item.JobDesicription,
                    JobSubDescription = item.JobSubDescription,
                });
            }
            var education = uow.EducationRepository.GetAll();

            List<EducationViewModel> EduViewModel = new List<EducationViewModel>();

            foreach (var item in education)
            {
                EduViewModel.Add(new EducationViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                });
            }

            var onlineCertificate = uow.OnlineCertificationRepository.GetAll();

            List<OnlineCertificateViewModel> Onlinecertificateviewmodel = new List<OnlineCertificateViewModel>();

            foreach (var item in onlineCertificate)
            {
                Onlinecertificateviewmodel.Add(new OnlineCertificateViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    ProgramName = item.ProgramName,
                    CourseLocation = item.CourseLocation,
                    IconUrl = item.IconUrl,
                    CourseDescription = item.CourseDescription,
                    ButtonText = item.ButtonText,
                    ButtonUrl = item.ButtonUrl,
                    FinishDate = item.FinishDate,
                });
            }

            var projectProfile = uow.PortfolioProjectRepository.GetAll();

            List<PortfolioProjectViewModel> ProjectViewModel = new List<PortfolioProjectViewModel>();

            foreach (var item in projectProfile)
            {
                ProjectViewModel.Add(new PortfolioProjectViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    Content = item.Content,
                    SubContent = item.SubContent,
                    ProjectName = item.ProjectName,
                    ProjectType = item.ProjectType,
                    ProjectImageUrl = item.ProjectImageUrl,
                    ProjectPublishDate = item.ProjectPublishDate,
                    ProjectDetails = item.ProjectDetails,
                    ProjectWebSiteUrl = item.ProjectWebSiteUrl,
                    ButtonText = item.ButtonText,
                    ProjectStatusId = item.ProjectStatusId,
                    ProjectStatus = item.ProjectStatus,
                });
            }

            var projectStatus = uow.ProjectStatusRepository.GetAll();

            List<ProjectStatusViewModel> ProjectStatus = new List<ProjectStatusViewModel>();

            foreach (var item in projectStatus)
            {
                ProjectStatus.Add(new ProjectStatusViewModel
                {
                    Id = item.Id,
                    ProjectStatusProcess = item.ProjectStatusProcess,
                });
            }

            var interest = uow.IntresetRepository.GetAll();

            List<InterestViewModel> InterestViewModelList = new List<InterestViewModel>();

            foreach (var item in interest)
            {
                InterestViewModelList.Add(new InterestViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    Subtitle = item.Subtitle,
                    UrlIcon = item.UrlIcon,
                });
            }
            ListPortfolio ListPortfolioContent = new ListPortfolio
            {
                ListPortfolioViewModle = ViewModel,
                ListPortfolioAboutViewModel = PortfolioViewModel,
                ListWorkExperienceViewModel = ExperienceViewModel,
                ListEducationViewModel = EduViewModel,
                ListofOnlineCertificationViewModel = Onlinecertificateviewmodel,
                ListPortfolioProject = ProjectViewModel,
                ListProjectStatuesViewModel = ProjectStatus,
                ListInterestViewModel = InterestViewModelList,

            };
            return PartialView(ListPortfolioContent);
        }

        

        [Route("Profile")]
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContactFormViewModel());
        }

        [HttpPost]
        [Route("Profile")]
        public ActionResult Create(ContactFormViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                ContactForm contactForm = new ContactForm
                {
                    Id = viewmodel.Id,
                    FullName = viewmodel.FullName,
                    Email = viewmodel.Email,
                    Moible = viewmodel.Moible,
                    Message = viewmodel.Message,
                    IpAddress = GetIpAddres(HttpContext.Request),

                };

                uow.ContactFormRepository.Add(contactForm);
                uow.Commit();
                TempData["Message"] = $"{contactForm.FullName}";
                return RedirectToAction(nameof(ThankYouForContact));



            }
            return View(viewmodel);
        }

        [Route("ThankYouForContact")]
        public ActionResult ThankYouForContact()
        {
            return View(new ContactFormViewModel());
        }


        [NonAction]
        private string GetIpAddres(HttpRequestBase request)
        {
            string ipaddres;
            ipaddres = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddres == "" || ipaddres == null)
            {
                ipaddres = request.ServerVariables["REMOTE_ADDR"];
            }
            return ipaddres;
        }
    }
}