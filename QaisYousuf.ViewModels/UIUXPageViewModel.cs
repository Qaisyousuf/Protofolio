using QaisYousuf.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.ViewModels
{
    public class UIUXPageViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        [Display(Name ="Meta Keyword")]
        public string MetaKeywords { get; set; }


        [Required]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "Visible to Search")]
        public bool IsVisibleToSearchEngine { get; set; }


        [Display(Name ="Banner")]
        public int UIBannerId { get; set; }

        [ForeignKey("UIBannerId")]
        public virtual UIBanner UIBanner { get; set; }


        [Display(Name ="UI UX Proccess")]
        public int UIProcessId { get; set; }
        [ForeignKey("UIProcessId")]
        public virtual UIProcess UIProcess { get; set; }


        [Display(Name ="UI UX Steps")]
        public int UISetpsId { get; set; }
        [ForeignKey("UISetpsId")]
        public virtual UIUXSteps UIUXSteps { get; set; }

        [Display(Name ="UI UX Matter")]
        public int UIUxMatterId { get; set; }
        [ForeignKey("UIUxMatterId")]
        public virtual UIUXMatterSection UIUXMatter { get; set; }

    }
}
