using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaisYousuf.Models;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Data.Context;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UserDashboardRepository:Repository<UserDashboard>,IUserDashBoardRepository
    {
        public UserDashboardRepository(UIContext context):base(context)
        {

        }
    }
}
