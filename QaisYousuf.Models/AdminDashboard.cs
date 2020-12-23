using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Models
{
   public class AdminDashboard:EntityBase
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string AuthenticatedUser { get; set; }
        public DateTime LogintDateTime { get; set; }
        public string LottiAnimationUrl { get; set; }

    }
}
