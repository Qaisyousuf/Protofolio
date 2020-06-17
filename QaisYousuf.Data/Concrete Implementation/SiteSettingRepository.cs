using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class SiteSettingRepository:Repository<SiteSetting>,ISiteSettingRepository
    {
        public SiteSettingRepository(UIContext context):base(context)
        {

        }
    }
}
