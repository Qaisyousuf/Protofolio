namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UIBannerPropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UIBanners", "MainTitle", c => c.String());
            AddColumn("dbo.UIBanners", "SubTitle", c => c.String());
            AddColumn("dbo.UIBanners", "ButtonUrl", c => c.String());
            AddColumn("dbo.UIBanners", "ButtonText", c => c.String());
            AddColumn("dbo.UIBanners", "ImageUrl", c => c.String());
            AlterColumn("dbo.UIPages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UIPages", "IsVisibleToSearchEngine", c => c.String());
            DropColumn("dbo.UIBanners", "ImageUrl");
            DropColumn("dbo.UIBanners", "ButtonText");
            DropColumn("dbo.UIBanners", "ButtonUrl");
            DropColumn("dbo.UIBanners", "SubTitle");
            DropColumn("dbo.UIBanners", "MainTitle");
        }
    }
}
