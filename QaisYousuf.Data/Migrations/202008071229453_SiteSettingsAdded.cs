namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSettingsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteName = c.String(),
                        SiteOwner = c.String(),
                        GoogleSiteVerfication = c.String(),
                        GoogleAds = c.String(),
                        SiteLastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        Home = c.String(),
                        HomeUrl = c.String(),
                        About = c.String(),
                        AboutUrl = c.String(),
                        UIUX = c.String(),
                        UIUXURl = c.String(),
                        Code = c.String(),
                        CodeUrl = c.String(),
                        Contact = c.String(),
                        ContactUrl = c.String(),
                        Support = c.String(),
                        SupportUrl = c.String(),
                        Profile = c.String(),
                        ProfileUrl = c.String(),
                        CopyrightFooter = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.SiteSettings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        SiteLastUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DesinedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.SiteSettings");
        }
    }
}
