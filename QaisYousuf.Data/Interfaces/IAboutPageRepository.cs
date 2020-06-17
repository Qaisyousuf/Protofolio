using QaisYousuf.Models;

namespace QaisYousuf.Data.Interfaces
{
    public interface IAboutPageRepository:IRepository<AboutPage>,ISlug
    {
        AboutPage GetAboutPageBySlug(string slug);

    }
}
