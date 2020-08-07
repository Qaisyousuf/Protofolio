using QaisYousuf.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.ViewModels
{
    public class PortfolioViewModel:BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        [Display(Name ="Meta keywrod")]
        public string MetaKeywords { get; set; }


        [Required]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }

        [Display(Name ="Visible To Search")]
        public bool IsVisibleToSearchEngine { get; set; }



        [Display(Name ="Banner")]
        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual PortfolioBanner PortfolioBanner { get; set; }


        [Display(Name = "Portfolio About")]
        public int PortfolioAboutId { get; set; }
        [ForeignKey("PortfolioAboutId")]
        public virtual PortfolioAbout PortfolioAbout { get; set; }

        [Display(Name = "Work EXperience")]
        public int WorkExperienceId { get; set; }
        [ForeignKey("WorkExperienceId")]
        public virtual WorkExperience WorkExperience { get; set; }

        [Display(Name = "Education")]
        public int EducationId { get; set; }
        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }


        [Display(Name = "Online Certification")]
        public int OnlineCertificationId { get; set; }
        [ForeignKey("OnlineCertificationId")]
        public virtual OnlineCertification OnlineCertification { get; set; }


        [Display(Name = "Project")]
        public int PortfolioProjectId { get; set; }
        [ForeignKey("PortfolioProjectId")]
        public virtual PortfolioProject PortfolioProject { get; set; }

        [Display(Name = "Interest")]
        public int InterestId { get; set; }
        [ForeignKey("InterestId")]
        public virtual Interest Interest { get; set; }

        //public int PortfolioContactId { get; set; }
        //[ForeignKey("PortfolioContactId")]
        //public virtual ContactForm ContactFormPortfolio { get; set; }

        //public int PortfolioContactDetails { get; set; }
        //[ForeignKey("PortfolioContactDetails")]
        //public virtual ContactDetails PortfolioContactDetials { get; set; }

    }
}
