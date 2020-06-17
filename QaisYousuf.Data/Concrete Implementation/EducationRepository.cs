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
    public class EducationRepository:Repository<Education>,IEducationRepository
    {
        public EducationRepository(UIContext context):base(context)
        {

        }
    }
}
