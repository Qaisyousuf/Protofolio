using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Models
{
    public  class OnlineCertification:EntityBase
    {
        public string MainTitle { get; set; }

        public string ProgramName { get; set; }

        public string CourseLocation { get; set; }

        public string IconUrl { get; set; }

        public string CourseDescription { get; set; }

        public string ButtonText { get; set; }

        public string ButtonUrl { get; set; }

        public DateTime FinishDate { get; set; }      

    }
}
