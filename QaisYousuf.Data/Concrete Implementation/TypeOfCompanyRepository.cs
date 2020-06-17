using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class TypeOfCompanyRepository:Repository<TypeOfCompany>,ITypeOfCompanyRepository
    {
        public TypeOfCompanyRepository(UIContext context):base(context)
        {

        }
    }
}
