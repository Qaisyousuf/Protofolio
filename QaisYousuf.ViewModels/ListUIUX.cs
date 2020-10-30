using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ListUIUX:BaseViewModel
    {
        public List<UIBannerViewModel> ListUIUXBannerViewModel { get; set; }
        public List<UIProcessViewModel> ListOfUIProcessViewModel { get; set; }
        public List<UIUXMatterViewModel> ListUIMatterViewModel { get; set; }
        public List<UIStepsViewModel> ListUIStepsViewModel { get; set; }

    }
}
