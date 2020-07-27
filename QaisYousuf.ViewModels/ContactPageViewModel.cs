using QaisYousuf.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.ViewModels
{
    public class ContactPageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        [Display(Name ="Meta Keyword")]
        public string MetaKeywords { get; set; }

        [Required]
        [Display(Name ="Meta Description")]
        public string MetaDescription { get; set; }

        [Display(Name ="Visible to Search")]
        public bool IsVisibleToSearchEngine { get; set; }

        [Display(Name ="Banner")]
        public int BannerId { get; set; }

        [ForeignKey("BannerId")]
        public virtual ContactBanner ContactBanner { get; set; }

        [Display(Name ="Contact Details")]
        public int ContactDetailsId { get; set; }


        [ForeignKey("CotnactDetailsId")]
        public virtual ContactDetails ContactDetails { get; set; }

        [Display(Name ="Contact Matter")]
        public int ContactMattersId { get; set; }


        [ForeignKey("ContactMattersId")]
        public virtual ContactMatters ContactMatters { get; set; }

    }
}
