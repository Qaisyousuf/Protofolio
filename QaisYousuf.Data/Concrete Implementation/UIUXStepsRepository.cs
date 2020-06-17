using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UIUXStepsRepository:Repository<UIUXSteps>,IUIUXStepsRepository
    {
        public UIUXStepsRepository(UIContext context):base(context)
        {

        }
    }
}
