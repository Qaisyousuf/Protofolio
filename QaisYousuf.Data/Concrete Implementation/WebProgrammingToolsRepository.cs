using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class WebProgrammingToolsRepository:Repository<WebProgrammingTools>,IWebProgrammingToolsRepository
    {
        public WebProgrammingToolsRepository(UIContext context):base(context)
        {

        }
    }
}
