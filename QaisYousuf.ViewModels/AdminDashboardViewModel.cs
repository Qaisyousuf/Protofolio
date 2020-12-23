using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="SubTitle")]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthenticatedUser { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name ="Login Date and Time")]
        public DateTime LoginDateTime { get; set; }

        

        [Required]
        public string LottiAnimationUrl { get; set; }
    }
}
