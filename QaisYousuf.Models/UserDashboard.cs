using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Models
{
    public class UserDashboard:EntityBase
    {

        public string Title { get; set; }
        public string AuthenticatedUser { get; set; }
        public string Content { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectFinishDate { get; set; }
        public string ProjectType { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }

    }
}
