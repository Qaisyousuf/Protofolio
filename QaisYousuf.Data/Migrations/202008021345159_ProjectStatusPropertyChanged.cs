namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectStatusPropertyChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectStatus", "ProjectStatusProcess", c => c.String());
            DropColumn("dbo.ProjectStatus", "ProjectProcess");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectStatus", "ProjectProcess", c => c.String());
            DropColumn("dbo.ProjectStatus", "ProjectStatusProcess");
        }
    }
}
