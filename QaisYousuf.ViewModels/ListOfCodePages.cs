using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public  class ListOfCodePages:BaseViewModel
    {
        public List<CodeBannerViewModel> ListOfCodeBannerViewModel { get; set; }
        public List<WebProgrammingToolsViewModel> ListOfWebProgramming { get; set; }
        public List<UIUXToolsViewModel> ListUIUXToolsViewModel { get; set; }
        public List<DesignCodeViewModel> ListCodeDesignViewModel { get; set; }
    }
}
