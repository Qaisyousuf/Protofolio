using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class TeamSocialMediaRepository:Repository<TeamSocialMedia>,ITeamSocialMediaRepository
    {
        public TeamSocialMediaRepository(UIContext context):base(context)
        {

        }
    }
}
