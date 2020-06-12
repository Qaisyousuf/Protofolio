using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class CodePage:EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string IsVisibleToSearchEngine { get; set; }


        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual CodeBanner CodeBanner { get; set; }


        public int ProgrammingId { get; set; }
        [ForeignKey("ProgrammingId")]
        public virtual WebProgrammingTools WebProgrammingTools { get; set; }

        public int UI_UX_Id { get; set; }
        [ForeignKey("UI_UX_Id")]
        public virtual UI_UX_Tools UI_UX_Tools { get; set; }


        public int DesignCodeId { get; set; }
        [ForeignKey("DesignCodeId")]
        public virtual DesignCodeSection DesignCodeSection { get; set; }

        public int SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        public virtual Subscribe Subscribe { get; set; }

    }
}
