using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class DesignStepsRepository:Repository<DesignSteps>,IDesignStepsRepository
    {
        public DesignStepsRepository(UIContext context):base(context)
        {

        }
    }
}
