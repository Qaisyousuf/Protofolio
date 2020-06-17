using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class DataCollectionRepository:Repository<DataCollection>,IDataCollectionRepository
    {
        public DataCollectionRepository(UIContext context):base(context)
        {

        }
    }
}
