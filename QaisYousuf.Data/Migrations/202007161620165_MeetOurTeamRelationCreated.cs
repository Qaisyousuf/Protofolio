namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetOurTeamRelationCreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamSocialMedias", "MeetOutTeam_Id", "dbo.MeetOutTeams");
            DropIndex("dbo.TeamSocialMedias", new[] { "MeetOutTeam_Id" });
            CreateTable(
                "dbo.MeetOurTeamSocialMedia",
                c => new
                    {
                        MeetOutTeamId = c.Int(nullable: false),
                        SocialMediaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MeetOutTeamId, t.SocialMediaId })
                .ForeignKey("dbo.MeetOutTeams", t => t.MeetOutTeamId, cascadeDelete: true)
                .ForeignKey("dbo.TeamSocialMedias", t => t.SocialMediaId, cascadeDelete: true)
                .Index(t => t.MeetOutTeamId)
                .Index(t => t.SocialMediaId);
            
            DropColumn("dbo.TeamSocialMedias", "MeetOutTeam_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeamSocialMedias", "MeetOutTeam_Id", c => c.Int());
            DropForeignKey("dbo.MeetOurTeamSocialMedia", "SocialMediaId", "dbo.TeamSocialMedias");
            DropForeignKey("dbo.MeetOurTeamSocialMedia", "MeetOutTeamId", "dbo.MeetOutTeams");
            DropIndex("dbo.MeetOurTeamSocialMedia", new[] { "SocialMediaId" });
            DropIndex("dbo.MeetOurTeamSocialMedia", new[] { "MeetOutTeamId" });
            DropTable("dbo.MeetOurTeamSocialMedia");
            CreateIndex("dbo.TeamSocialMedias", "MeetOutTeam_Id");
            AddForeignKey("dbo.TeamSocialMedias", "MeetOutTeam_Id", "dbo.MeetOutTeams", "Id");
        }
    }
}
