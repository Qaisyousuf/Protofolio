using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using System.Linq;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UIPageRepository:Repository<UIPage>,IUIPageRepository
    {
        public UIPageRepository(UIContext context):base(context)
        {

        }

        public UIPage GetUIPageBySlug(string slug)
        {
            return _context.UIPages.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.UIPages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.UIPages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
