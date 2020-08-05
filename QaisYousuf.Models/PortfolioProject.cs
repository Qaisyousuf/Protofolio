using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class PortfolioProject:EntityBase
    {
        public string MainTitle { get; set; }

        public string Content { get; set; }

        public string SubContent { get; set; }

        public string ProjectName { get; set; }

        public string ProjectType { get; set; }

        public string ProjectImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProjectPublishDate { get; set; }

        public string ProjectDetails { get; set; }

        public string ProjectWebSiteUrl { get; set; }

        public string ButtonText { get; set; }

        public int ProjectStatusId { get; set; }

        [ForeignKey("ProjectStatusId")]
        public ProjectStatus ProjectStatus { get; set; }





    }
}
