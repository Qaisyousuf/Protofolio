using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
   public class AdminActivityViewModel
    {
        public int Id { get; set; }

        [Display(Name ="IPAddres")]
        public string Ip { get; set; }

        [Display(Name ="User Agint")]
        public string UserAgint { get; set; }

        [Display(Name ="Action Name")]
        public string ActionName { get; set; }

        [Display(Name ="Controller Name")]
        public string ControllerName { get; set; }

        [Display(Name ="Authenticated User")]
        public string LoginUser { get; set; }

        [Display(Name ="User Browser")]
        public string UserBrowser { get; set; }

        [Display(Name ="Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name ="AuthenticationActivity")]
        public string AuthenticationActivity { get; set; }

    }
}
