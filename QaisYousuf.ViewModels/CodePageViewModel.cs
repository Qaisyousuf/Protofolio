using QaisYousuf.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.ViewModels
{
    public class CodePageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        [Display(Name ="Meta Keywords")]
        public string MetaKeywords { get; set; }

        [Required]
        [Display(Name ="Meta Describption")]
        public string MetaDescription { get; set; }

        [Required]
        [Display(Name ="Visible to Search")]
        public bool IsVisibleToSearchEngine { get; set; }


        [Display(Name ="Banner")]
        public int BannerId { get; set; }

        [ForeignKey("BannerId")]
        public virtual CodeBanner CodeBanner { get; set; }


        [Display(Name ="Programming Tools")]
        public int ProgrammingId { get; set; }

        [ForeignKey("ProgrammingId")]
        public virtual WebProgrammingTools WebProgrammingTools { get; set; }

        [Display(Name ="UI UX Tools")]
        public int UI_UX_Id { get; set; }

        [ForeignKey("UI_UX_Id")]
        public virtual UI_UX_Tools UI_UX_Tools { get; set; }


        [Display(Name ="Design Code")]
        public int DesignCodeId { get; set; }

        [ForeignKey("DesignCodeId")]
        public virtual DesignCodeSection DesignCodeSection { get; set; }

        [Display(Name ="Subscribe")]
        public int SubscriptionId { get; set; }

        [ForeignKey("SubscriptionId")]
        public virtual Subscribe Subscribe { get; set; }
    }
}
