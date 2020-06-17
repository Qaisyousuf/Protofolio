using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class RequestingUIFormRepository:Repository<RequstingUIForm>,IRequstingUIFormRepository
    {
        public RequestingUIFormRepository(UIContext context):base(context)
        {

        }
    }
}
