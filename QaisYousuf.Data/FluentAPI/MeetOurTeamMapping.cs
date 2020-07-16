using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using QaisYousuf.Models;

namespace QaisYousuf.Data.FluentAPI
{
    public class MeetOurTeamMapping:EntityTypeConfiguration<MeetOutTeam>
    {
        public MeetOurTeamMapping()
        {
            HasMany(m => m.TeamSocialMedias)
                .WithMany(t => t.MeetOutTeams)
                .Map(mt =>
                {
                    mt.MapLeftKey("MeetOutTeamId");
                    mt.MapRightKey("SocialMediaId");
                    mt.ToTable("MeetOurTeamSocialMedia");
                });
        }
    }
}
