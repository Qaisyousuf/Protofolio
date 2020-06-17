using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class ProjectCountingRepository:Repository<ProjectCountiing>,IProjectCountingRepository
    {
        public ProjectCountingRepository(UIContext context):base(context)
        {

        }
    }
}
