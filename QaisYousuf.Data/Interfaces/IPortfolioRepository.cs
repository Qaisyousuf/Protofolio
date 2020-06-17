using QaisYousuf.Models;

namespace QaisYousuf.Data.Interfaces
{
    public interface IPortfolioRepository:IRepository<Portfolio>,ISlug
    {
        Portfolio GetPortfolioByeSlug(string slug);
    }
}
