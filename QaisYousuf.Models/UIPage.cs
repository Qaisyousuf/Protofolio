using System.ComponentModel.DataAnnotations.Schema;
namespace QaisYousuf.Models
{
    public class UIPage:EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string IsVisibleToSearchEngine { get; set; }

        public int UIBannerId { get; set; }
        [ForeignKey("UIBannerId")]
        public virtual UIBanner UIBanner { get; set; }

        public int UIProcessId { get; set; }
        [ForeignKey("UIProcessId")]
        public virtual UIProcess  UIProcess { get; set; }


        public int UISetpsId { get; set; }
        [ForeignKey("UISetpsId")]
        public virtual UIUXSteps UIUXSteps { get; set; }

        public int UIUxMatterId { get; set; }
        [ForeignKey("UIUxMatterId")]
        public virtual UIUXMatterSection UIUXMatter { get; set; }




    }
}
