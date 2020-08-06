using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class Portfolio : EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string IsVisibleToSearchEngine { get; set; }



        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual PortfolioBanner PortfolioBanner { get; set; }

        public int PortfolioAboutId { get; set; }
        [ForeignKey("PortfolioAboutId")]
        public virtual PortfolioAbout PortfolioAbout { get; set; }

        public int WorkExperienceId { get; set; }
        [ForeignKey("WorkExperienceId")]
        public virtual WorkExperience WorkExperience { get; set; }

        public int EducationId { get; set; }
        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }

        public int OnlineCertificationId { get; set; }
        [ForeignKey("OnlineCertificationId")]
        public virtual OnlineCertification OnlineCertification { get; set; }


        public int PortfolioProjectId { get; set; }
        [ForeignKey("PortfolioProjectId")]
        public virtual PortfolioProject PortfolioProject { get; set; }

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
