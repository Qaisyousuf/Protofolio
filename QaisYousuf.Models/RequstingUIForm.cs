using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class RequstingUIForm:EntityBase
    {
        
        public string ComnayName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string NumberOfEmployee { get; set; }

        public string CurrentWebSiteUrl { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string IdeaLink { get; set; }

        public int CompanyNameId { get; set; }
        [ForeignKey("CompanyNameId")]
        public virtual TypeOfCompany TypeOfCompany { get; set; }

    }
}
