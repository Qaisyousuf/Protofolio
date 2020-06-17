using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using System.Linq;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class PortfolioRepository:Repository<Portfolio>,IPortfolioRepository
    {
        public PortfolioRepository(UIContext context):base(context)
        {

        }

        public Portfolio GetPortfolioByeSlug(string slug)
        {
            return _context.Portfolios.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.Portfolios.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.Portfolios.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
