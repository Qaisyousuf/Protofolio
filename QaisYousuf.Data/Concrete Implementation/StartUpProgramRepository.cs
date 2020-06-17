using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class StartUpProgramRepository:Repository<StartUpProgram>,IStartUpProgramRepository
    {
        public StartUpProgramRepository(UIContext context):base(context)
        {

        }
    }
}
