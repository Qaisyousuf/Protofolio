using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class HomePage:EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string IsVisibleToSearchEngine { get; set; }


        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual HomeBanner HomeBanner { get; set; }

        public int DataCollectionId { get; set; }
        [ForeignKey("DataCollectionId")]
        public virtual DataCollection DataCollection { get; set; }

        public int WorkQualityId { get; set; }
        [ForeignKey("WorkQualityId")]
        public virtual WorkQualitySection WorkQualitySection { get; set; }

        public int ProjectCountingId { get; set; }
        [ForeignKey("ProjectCountingId")]
        public virtual ProjectCountiing ProjectCountiing { get; set; }

        public int PlatformDesignId { get; set; }
        [ForeignKey("PlatformDesignId")]
        public virtual PlatformDesign PlatformDesign { get; set; }

        public int DesignStepsId { get; set; }
        [ForeignKey("DesignStepsId")]
        public virtual DesignSteps DesignSteps { get; set; }


    }
}
