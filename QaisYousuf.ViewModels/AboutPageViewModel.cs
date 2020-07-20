using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaisYousuf.Models;

namespace QaisYousuf.ViewModels
{
    public class AboutPageViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }


        [Required]
        [Display(Name ="Meta Keywords")]
        public string MetaKeywords { get; set; }

        [Required]
        [Display(Name ="Meta Description")]
        public string MetaDescription { get; set; }


        [Required]
        [Display(Name ="Visible To Search")]
        public bool IsVisibleToSearchEngine { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name ="Banner")]
        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual AboutPageBanner AboutPageBanner { get; set; }


        [Display(Name ="Start Up Program")]
        public int StartUpProgramId { get; set; }
        [ForeignKey("StartUpProgramId")]
        public virtual StartUpProgram StartUpProgram { get; set; }


        [Display(Name ="Start Up Process")]
        public int StartUpProcessId { get; set; }
        [ForeignKey("StartUpProcessId")]
        public virtual StartUpProcess StartUpProcess { get; set; }


        [Display(Name ="Meet Our Team")]
        public int MeetOurTeamId { get; set; }
        [ForeignKey("MeetOurTeamId")]
        public virtual MeetOurTeam MeetOurTeam { get; set; }


    }
}
