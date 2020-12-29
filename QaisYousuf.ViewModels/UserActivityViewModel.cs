using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class UserActivityViewModel
    {
        public int Id { get; set; }

        public string Ip { get; set; }

        public string UserAgint { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public string LoginUser { get; set; }

        public string UserBrowser { get; set; }

        public DateTime DateTime { get; set; }

        public string AuthenticationActivity { get; set; }
    }
}
