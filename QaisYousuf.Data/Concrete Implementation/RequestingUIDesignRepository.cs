using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class RequestingUIDesignRepository:Repository<RequstingUIDesign>,IRequstingUIDesignRepository
    {
        public RequestingUIDesignRepository(UIContext context):base(context)
        {

        }
    }
}
