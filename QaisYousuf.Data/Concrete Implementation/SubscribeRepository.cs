using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class SubscribeRepository:Repository<Subscribe>,ISubscribeRepository
    {
        public SubscribeRepository(UIContext context):base(context)
        {

        }
    }
}
