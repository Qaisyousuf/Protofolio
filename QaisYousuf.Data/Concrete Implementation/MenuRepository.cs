using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class MenuRepository:Repository<Menu>,IMenuRepository
    {
        public MenuRepository(UIContext context):base(context)
        {

        }
    }
}
