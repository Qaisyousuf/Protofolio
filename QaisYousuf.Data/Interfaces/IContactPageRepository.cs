using QaisYousuf.Models;

namespace QaisYousuf.Data.Interfaces
{
    public interface IContactPageRepository:IRepository<ContactPage>,ISlug
    {
        ContactPage GetContactPageBySlug(string slug);
    }
}
