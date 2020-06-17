using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class ContactMatterRepository:Repository<ContactMatters>,IContactMatterRepository
    {
        public ContactMatterRepository(UIContext context):base(context)
        {

        }
    }
}
