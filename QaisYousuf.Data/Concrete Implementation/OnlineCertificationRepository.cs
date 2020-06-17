using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class OnlineCertificationRepository:Repository<OnlineCertification>,IOnlineCertificationRepository
    {
        public OnlineCertificationRepository(UIContext context):base(context)
        {

        }
    }
}
