using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class MeetOurTeamRepository:Repository<MeetOutTeam>,IMeetOurTeamRepository
    {
        public MeetOurTeamRepository(UIContext context):base(context)
        {

        }
    }
}
