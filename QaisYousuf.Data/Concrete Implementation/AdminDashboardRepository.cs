using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaisYousuf.Data.Context;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class AdminDashboardRepository:Repository<AdminDashboard>,IAdminDashboardRepository
    {
        public AdminDashboardRepository(UIContext context):base(context)
        {

        }
    }
}
