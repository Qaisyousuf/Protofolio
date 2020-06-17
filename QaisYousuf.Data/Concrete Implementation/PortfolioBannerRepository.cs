using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class PortfolioBannerRepository:Repository<PortfolioBanner>,IPortfolioBannerRepository
    {
        public PortfolioBannerRepository(UIContext context):base(context)
        {

        }
    }
}
