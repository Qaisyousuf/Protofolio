using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Models
{
    public class PortfolioBanner:EntityBase
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string BackgroundImage { get; set; }

        public string SliderImagesUrl { get; set; }

        public string ButtonUrl { get; set; }

        public string ButtonText { get; set; }

    }
}
