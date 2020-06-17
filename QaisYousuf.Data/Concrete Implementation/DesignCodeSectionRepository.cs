using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class DesignCodeSectionRepository:Repository<DesignCodeSection>,IDesignCodeSectionRepository
    {
        public DesignCodeSectionRepository(UIContext context):base(context)
        {

        }
    }
}
