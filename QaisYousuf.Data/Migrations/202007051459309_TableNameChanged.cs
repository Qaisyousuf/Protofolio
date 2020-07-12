namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableNameChanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectCountiings", newName: "ProjectCountings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProjectCountings", newName: "ProjectCountiings");
        }
    }
}
