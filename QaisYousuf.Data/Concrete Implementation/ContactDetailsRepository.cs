using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class ContactDetailsRepository:Repository<ContactDetails>,IContactDetailsRepository
    {
        public ContactDetailsRepository(UIContext context):base(context)
        {

        }
    }
}
