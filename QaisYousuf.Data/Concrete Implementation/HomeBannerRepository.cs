using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class HomeBannerRepository:Repository<HomeBanner>,IHomeBannerRepository
    {
        public HomeBannerRepository(UIContext context):base(context)
        {

        }
    }
}
