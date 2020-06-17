using QaisYousuf.Models;

namespace QaisYousuf.Data.Interfaces
{
    public interface IUIPageRepository:IRepository<UIPage>,ISlug
    {
        UIPage GetUIPageBySlug(string slug);
    }
}
