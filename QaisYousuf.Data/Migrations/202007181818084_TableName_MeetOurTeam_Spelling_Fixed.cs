namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableName_MeetOurTeam_Spelling_Fixed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MeetOutTeams", newName: "MeetOurTeams");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MeetOurTeams", newName: "MeetOutTeams");
        }
    }
}
