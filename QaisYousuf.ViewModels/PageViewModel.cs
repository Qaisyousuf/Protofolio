using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QaisYousuf.Models;

namespace QaisYousuf.ViewModels
{
    public class PageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        public string Content { get; set; }


        [Display(Name ="Meta Data")]
        public bool IsPageMetaDataOn { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        [Display(Name ="Search Engine")]
        public bool IsVisibleToSearchEngine { get; set; }


        [Display(Name ="Banner")]
        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual HomeBanner HomeBanner { get; set; }

        [Display(Name ="Data Collection")]
        public int DataCollectionId { get; set; }
        [ForeignKey("DataCollectionId")]
        public virtual DataCollection DataCollection { get; set; }

        [Display(Name ="Work Quality")]
        public int WorkQualityId { get; set; }
        [ForeignKey("WorkQualityId")]
        public virtual WorkQualitySection WorkQualitySection { get; set; }

        [Display(Name ="Project Counting")]
        public int ProjectCountingId { get; set; }
        [ForeignKey("ProjectCountingId")]
        public virtual ProjectCounting ProjectCountiing { get; set; }

        [Display(Name ="Platform Design")]
        public int PlatformDesignId { get; set; }
        [ForeignKey("PlatformDesignId")]
        public virtual PlatformDesign PlatformDesign { get; set; }


        [Display(Name ="Design Steps")]
        public int DesignStepsId { get; set; }
        [ForeignKey("DesignStepsId")]
        public virtual DesignSteps DesignSteps { get; set; }
    }
}
