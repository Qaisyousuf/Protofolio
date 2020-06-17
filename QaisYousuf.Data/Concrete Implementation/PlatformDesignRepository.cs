using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class PlatformDesignRepository:Repository<PlatformDesign>,IPlatformDesignRepository
    {
        public PlatformDesignRepository(UIContext context):base(context)
        {

        }
    }
}
