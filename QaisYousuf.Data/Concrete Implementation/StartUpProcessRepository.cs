using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class StartUpProcessRepository:Repository<StartUpProcess>,IStartUpProcessRepository
    {
        public StartUpProcessRepository(UIContext context):base(context)
        {

        }
    }
}
