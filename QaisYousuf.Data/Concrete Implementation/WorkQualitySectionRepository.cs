using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class WorkQualitySectionRepository:Repository<WorkQualitySection>,IWorkQualitySectionRepository
    {
        public WorkQualitySectionRepository(UIContext context):base(context)
        {

        }
    }
}
