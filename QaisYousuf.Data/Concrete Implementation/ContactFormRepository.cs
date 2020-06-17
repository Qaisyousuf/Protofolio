using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class ContactFormRepository:Repository<ContactForm>,IContactFormRepository
    {
        public ContactFormRepository(UIContext context):base(context)
        {

        }
    }
}
