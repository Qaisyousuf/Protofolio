using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ListPortfolio : BaseViewModel
    {
        public List<PortfolioBannerViewModel> ListPortfolioViewModle { get; set; }
        public List<PortfolioAboutViewModels> ListPortfolioAboutViewModel { get; set; }
        public List<WorkExperienceViewModel> ListWorkExperienceViewModel { get; set; }
        public List<EducationViewModel> ListEducationViewModel { get; set; }
        public List<OnlineCertificateViewModel> ListofOnlineCertificationViewModel { get; set; }
        public List<PortfolioProjectViewModel> ListPortfolioProject { get; set; }
        public List<ProjectStatusViewModel> ListProjectStatuesViewModel { get; set; }
        public List<InterestViewModel> ListInterestViewModel { get; set; }
    }
}
