﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ListOfContact:BaseViewModel
    {
        public List<ContactBannerViewModel> ListContactBannerViewmodel { get; set; }
        public List<ContactDetailsViewModel> ListContactDetiailsViewModel { get; set; }
        public List<ContactMattersViewModel> ListContactMatterViewModel { get; set; }
        public List<ThankYouPageViewModel> ListOfThankYouPageViewModel { get; set; }
    }
}
