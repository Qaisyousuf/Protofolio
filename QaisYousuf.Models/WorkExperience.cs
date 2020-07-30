using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Models
{
    public class WorkExperience:EntityBase
    {
        public string Maintitle { get; set; }


        public string JobTitle { get; set; }

        public string CompanyName { get; set; }

        public string CompanyLocation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string JobDesicription { get; set; }

        public string LogoUrl { get; set; }

        public string JobSubDescription { get; set; }


    }
}
