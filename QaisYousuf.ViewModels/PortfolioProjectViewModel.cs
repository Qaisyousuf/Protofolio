using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class PortfolioProjectViewModel
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

        public string ProjectPublishDate { get; set; }

        public string ProjectDetails { get; set; }

        public string ProjectWebSiteUrl { get; set; }

        public string ButtonText { get; set; }

        public int ProjectStatusId { get; set; }

        [ForeignKey("ProjectStatusId")]
        public virtual ProjectStatus ProjectStatus { get; set; }

    }
}
