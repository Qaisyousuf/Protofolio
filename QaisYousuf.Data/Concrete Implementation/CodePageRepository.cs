using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using System.Linq;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class CodePageRepository:Repository<CodePage>,ICodePageRepository
    {
        public CodePageRepository(UIContext context):base(context)
        {
            
        }

        public CodePage GetCodePageBySlug(string slug)
        {
            return _context.CodePage.Where(x => x.Slug == slug).FirstOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.CodePage.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.CodePage.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
