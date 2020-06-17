using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class PortfolioProjectRepository:Repository<PortfolioProject>,IPortfolioProjectRepository
    {
        public PortfolioProjectRepository(UIContext context):base(context)
        {

        }
    }
}
