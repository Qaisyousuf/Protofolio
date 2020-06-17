using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UIBannerRepository:Repository<UIBanner>,IUIBannerRepository
    {
        public UIBannerRepository(UIContext context):base(context)
        {

        }
    }
}
