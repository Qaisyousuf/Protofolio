using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public  class AboutPage:EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string IsVisibleToSearchEngine { get; set; }


        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual AboutPageBanner AboutPageBanner { get; set; }

        public int StartUpProgramId { get; set; }
        [ForeignKey("StartUpProgramId")]
        public virtual StartUpProgram StartUpProgram { get; set; }

        public int StartUpProcessId { get; set; }
        [ForeignKey("StartUpProcessId")]
        public virtual StartUpProcess StartUpProcess { get; set; }

        public int MeetOurTeamId { get; set; }
        [ForeignKey("MeetOurTeamId")]
        public virtual MeetOutTime MeetOutTime { get; set; } 


    }
}
