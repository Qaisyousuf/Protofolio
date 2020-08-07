using QaisYousuf.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.ViewModels
{
    public class PortfolioProjectViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Sub Content")]
        public string SubContent { get; set; }

        [Required]
        [Display(Name ="Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name ="Project Type")]
        public string ProjectType { get; set; }

        [Required]
        [Display(Name ="Project Image Url")]
        [DataType(DataType.Url)]
        public string ProjectImageUrl { get; set; }


        [Required]
        [Display(Name ="Project Publish Date")]
        [DataType(DataType.Date)]
        public DateTime ProjectPublishDate { get; set; }

        [Required]
        [Display(Name ="Project Detials")]
        public string ProjectDetails { get; set; }

        [Required]
        [Display(Name ="Project Web Url")]
        [DataType(DataType.Url)]
        public string ProjectWebSiteUrl { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

        [Display(Name ="Project Status")]
        public int ProjectStatusId { get; set; }

        [ForeignKey("ProjectStatusId")]
        public virtual ProjectStatus ProjectStatus { get; set; }

    }
}
