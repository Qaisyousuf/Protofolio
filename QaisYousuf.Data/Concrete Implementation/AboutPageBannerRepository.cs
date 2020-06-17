using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class AboutPageBannerRepository:Repository<AboutPageBanner>,IAboutPageBannerRepository
    {
        public AboutPageBannerRepository(UIContext context):base(context)
        {

        }
    }
}
