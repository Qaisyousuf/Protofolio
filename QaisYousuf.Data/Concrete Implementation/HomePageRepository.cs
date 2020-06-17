using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class HomePageRepository:Repository<HomePage>,IHomePageRepository
    {
        public HomePageRepository(UIContext context):base(context)
        {

        }

        public HomePage GetHomePageBySlug(string slug)
        {
            return _context.HomePages.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.HomePages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.HomePages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
