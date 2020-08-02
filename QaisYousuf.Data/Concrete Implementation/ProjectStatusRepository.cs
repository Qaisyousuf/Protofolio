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
    public class ProjectStatusRepository:Repository<ProjectStatus>,IProjectStatusRepository
    {
        public ProjectStatusRepository(UIContext context):base(context)
        {

        }
    }
}
