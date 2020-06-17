using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UIUXToolsRepository:Repository<UI_UX_Tools>,IUIUXToolsRepository
    {
        public UIUXToolsRepository(UIContext context):base(context)
        {

        }
    }
}
