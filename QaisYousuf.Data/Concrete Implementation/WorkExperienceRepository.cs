using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class WorkExperienceRepository:Repository<WorkExperience>,IWorkExperienceRepository
    {
        public WorkExperienceRepository(UIContext context):base(context)
        {

        }
    }
}
