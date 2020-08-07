namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProptertyAddedToSiteSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "SiteName", c => c.String());
            AddColumn("dbo.Settings", "SiteOwner", c => c.String());
            AddColumn("dbo.Settings", "GoogleSiteVerfication", c => c.String());
            AddColumn("dbo.Settings", "GoogleAds", c => c.String());
            AddColumn("dbo.Settings", "SiteLastUpdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Settings", "UpdatedBy", c => c.String());
            AddColumn("dbo.Settings", "Title", c => c.String());
            AddColumn("dbo.Settings", "Content", c => c.String());
            AddColumn("dbo.Settings", "Home", c => c.String());
            AddColumn("dbo.Settings", "HomeUrl", c => c.String());
            AddColumn("dbo.Settings", "About", c => c.String());
            AddColumn("dbo.Settings", "AboutUrl", c => c.String());
            AddColumn("dbo.Settings", "UIUX", c => c.String());
            AddColumn("dbo.Settings", "UIUXURl", c => c.String());
            AddColumn("dbo.Settings", "Code", c => c.String());
            AddColumn("dbo.Settings", "CodeUrl", c => c.String());
            AddColumn("dbo.Settings", "Contact", c => c.String());
            AddColumn("dbo.Settings", "ContactUrl", c => c.String());
            AddColumn("dbo.Settings", "Support", c => c.String());
            AddColumn("dbo.Settings", "SupportUrl", c => c.String());
            AddColumn("dbo.Settings", "Profile", c => c.String());
            AddColumn("dbo.Settings", "ProfileUrl", c => c.String());
            AddColumn("dbo.Settings", "CopyrightFooter", c => c.String());
            AddColumn("dbo.Settings", "DesignBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "DesignBy");
            DropColumn("dbo.Settings", "CopyrightFooter");
            DropColumn("dbo.Settings", "ProfileUrl");
            DropColumn("dbo.Settings", "Profile");
            DropColumn("dbo.Settings", "SupportUrl");
            DropColumn("dbo.Settings", "Support");
            DropColumn("dbo.Settings", "ContactUrl");
            DropColumn("dbo.Settings", "Contact");
            DropColumn("dbo.Settings", "CodeUrl");
            DropColumn("dbo.Settings", "Code");
            DropColumn("dbo.Settings", "UIUXURl");
            DropColumn("dbo.Settings", "UIUX");
            DropColumn("dbo.Settings", "AboutUrl");
            DropColumn("dbo.Settings", "About");
            DropColumn("dbo.Settings", "HomeUrl");
            DropColumn("dbo.Settings", "Home");
            DropColumn("dbo.Settings", "Content");
            DropColumn("dbo.Settings", "Title");
            DropColumn("dbo.Settings", "UpdatedBy");
            DropColumn("dbo.Settings", "SiteLastUpdate");
            DropColumn("dbo.Settings", "GoogleAds");
            DropColumn("dbo.Settings", "GoogleSiteVerfication");
            DropColumn("dbo.Settings", "SiteOwner");
            DropColumn("dbo.Settings", "SiteName");
        }
    }
}
