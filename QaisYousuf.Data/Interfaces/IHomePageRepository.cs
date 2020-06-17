using QaisYousuf.Models;

namespace QaisYousuf.Data.Interfaces
{
    public interface IHomePageRepository:IRepository<HomePage>,ISlug
    {
        HomePage GetHomePageBySlug(string slug);
    }
}
