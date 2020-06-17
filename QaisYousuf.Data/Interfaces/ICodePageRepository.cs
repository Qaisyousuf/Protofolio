using QaisYousuf.Models;

namespace QaisYousuf.Data.Interfaces
{
    public interface ICodePageRepository:IRepository<CodePage>,ISlug
    {
        CodePage GetCodePageBySlug(string slug);
    }
}
