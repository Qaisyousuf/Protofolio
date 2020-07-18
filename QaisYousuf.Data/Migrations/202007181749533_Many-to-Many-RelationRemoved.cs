namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManytoManyRelationRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetOurTeamSocialMedia", "MeetOutTeamId", "dbo.MeetOutTeams");
            DropForeignKey("dbo.MeetOurTeamSocialMedia", "SocialMediaId", "dbo.TeamSocialMedias");
            DropIndex("dbo.MeetOurTeamSocialMedia", new[] { "MeetOutTeamId" });
            DropIndex("dbo.MeetOurTeamSocialMedia", new[] { "SocialMediaId" });
            AddColumn("dbo.MeetOutTeams", "TeamSocialId", c => c.Int(nullable: false));
            AddColumn("dbo.TeamSocialMedias", "Title", c => c.String());
            CreateIndex("dbo.MeetOutTeams", "TeamSocialId");
            AddForeignKey("dbo.MeetOutTeams", "TeamSocialId", "dbo.TeamSocialMedias", "Id", cascadeDelete: true);
            DropTable("dbo.MeetOurTeamSocialMedia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MeetOurTeamSocialMedia",
                c => new
                    {
                        MeetOutTeamId = c.Int(nullable: false),
                        SocialMediaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MeetOutTeamId, t.SocialMediaId });
            
            DropForeignKey("dbo.MeetOutTeams", "TeamSocialId", "dbo.TeamSocialMedias");
            DropIndex("dbo.MeetOutTeams", new[] { "TeamSocialId" });
            DropColumn("dbo.TeamSocialMedias", "Title");
            DropColumn("dbo.MeetOutTeams", "TeamSocialId");
            CreateIndex("dbo.MeetOurTeamSocialMedia", "SocialMediaId");
            CreateIndex("dbo.MeetOurTeamSocialMedia", "MeetOutTeamId");
            AddForeignKey("dbo.MeetOurTeamSocialMedia", "SocialMediaId", "dbo.TeamSocialMedias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MeetOurTeamSocialMedia", "MeetOutTeamId", "dbo.MeetOutTeams", "Id", cascadeDelete: true);
        }
    }
}
