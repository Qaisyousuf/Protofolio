using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UIProcessRepository:Repository<UIProcess>,IUIProcessRepository
    {
        public UIProcessRepository(UIContext context):base(context)
        {

        }
    }
}
