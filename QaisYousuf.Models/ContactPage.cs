using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class ContactPage:EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string IsVisibleToSearchEngine { get; set; }


        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public virtual ContactBanner ContactBanner { get; set; }

        public int CotnactDetailsId { get; set; }
        [ForeignKey("CotnactDetailsId")]
        public virtual ContactDetails ContactDetails { get; set; }

        public int ContactMattersId { get; set; }
        [ForeignKey("ContactMattersId")]
        public virtual ContactMatters ContactMatters { get; set; }


    }
}
