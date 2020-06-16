namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutPageBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ButtonUrl = c.String(),
                        ButtonText = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AboutPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.String(),
                        BannerId = c.Int(nullable: false),
                        StartUpProgramId = c.Int(nullable: false),
                        StartUpProcessId = c.Int(nullable: false),
                        MeetOurTeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AboutPageBanners", t => t.BannerId, cascadeDelete: true)
                .ForeignKey("dbo.MeetOutTeams", t => t.MeetOurTeamId, cascadeDelete: true)
                .ForeignKey("dbo.StartUpProcesses", t => t.StartUpProcessId, cascadeDelete: true)
                .ForeignKey("dbo.StartUpPrograms", t => t.StartUpProgramId, cascadeDelete: true)
                .Index(t => t.BannerId)
                .Index(t => t.StartUpProgramId)
                .Index(t => t.StartUpProcessId)
                .Index(t => t.MeetOurTeamId);
            
            CreateTable(
                "dbo.MeetOutTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        ImageUrl = c.String(),
                        ProfileImageUrl = c.String(),
                        Name = c.String(),
                        Position = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamSocialMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FB = c.String(),
                        FBUrl = c.String(),
                        LinkedIn = c.String(),
                        LinkedInUrl = c.String(),
                        Twiter = c.String(),
                        TwiterUrl = c.String(),
                        WebSite = c.String(),
                        WebsiteUrl = c.String(),
                        MeetOutTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeetOutTeams", t => t.MeetOutTeam_Id)
                .Index(t => t.MeetOutTeam_Id);
            
            CreateTable(
                "dbo.StartUpProcesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StartUpPrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ButtonUrl = c.String(),
                        ButtonText = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.String(),
                        BannerId = c.Int(nullable: false),
                        ProgrammingId = c.Int(nullable: false),
                        UI_UX_Id = c.Int(nullable: false),
                        DesignCodeId = c.Int(nullable: false),
                        SubscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CodeBanners", t => t.BannerId, cascadeDelete: true)
                .ForeignKey("dbo.DesignCodeSections", t => t.DesignCodeId, cascadeDelete: true)
                .ForeignKey("dbo.Subscribes", t => t.SubscriptionId, cascadeDelete: true)
                .ForeignKey("dbo.UI_UX_Tools", t => t.UI_UX_Id, cascadeDelete: true)
                .ForeignKey("dbo.WebProgrammingTools", t => t.ProgrammingId, cascadeDelete: true)
                .Index(t => t.BannerId)
                .Index(t => t.ProgrammingId)
                .Index(t => t.UI_UX_Id)
                .Index(t => t.DesignCodeId)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.DesignCodeSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Email = c.String(),
                        Buttontext = c.String(),
                        ModalMessage = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UI_UX_Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        IconUrl = c.String(),
                        ProgramTitle = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebProgrammingTools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        ImageUrl = c.String(),
                        IconUrl = c.String(),
                        ProgramTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ButtonUrl = c.String(),
                        ButtonText = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        HomeAddress = c.String(),
                        Moible = c.String(),
                        Email = c.String(),
                        WorkingTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Moible = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactMatters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        MapApi = c.String(),
                        ButtonText = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.String(),
                        BannerId = c.Int(nullable: false),
                        CotnactDetailsId = c.Int(nullable: false),
                        ContactMattersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactBanners", t => t.BannerId, cascadeDelete: true)
                .ForeignKey("dbo.ContactDetails", t => t.CotnactDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.ContactMatters", t => t.ContactMattersId, cascadeDelete: true)
                .Index(t => t.BannerId)
                .Index(t => t.CotnactDetailsId)
                .Index(t => t.ContactMattersId);
            
            CreateTable(
                "dbo.DataCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DesignSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        StepIcon = c.String(),
                        StepTitle = c.String(),
                        StepContent = c.String(),
                        StepImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        BackgroundImage = c.String(),
                        SliderImagesUrl = c.String(),
                        ButtonUrl = c.String(),
                        ButtonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.String(),
                        BannerId = c.Int(nullable: false),
                        DataCollectionId = c.Int(nullable: false),
                        WorkQualityId = c.Int(nullable: false),
                        ProjectCountingId = c.Int(nullable: false),
                        PlatformDesignId = c.Int(nullable: false),
                        DesignStepsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataCollections", t => t.DataCollectionId, cascadeDelete: true)
                .ForeignKey("dbo.DesignSteps", t => t.DesignStepsId, cascadeDelete: true)
                .ForeignKey("dbo.HomeBanners", t => t.BannerId, cascadeDelete: true)
                .ForeignKey("dbo.PlatformDesigns", t => t.PlatformDesignId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectCountiings", t => t.ProjectCountingId, cascadeDelete: true)
                .ForeignKey("dbo.WorkQualitySections", t => t.WorkQualityId, cascadeDelete: true)
                .Index(t => t.BannerId)
                .Index(t => t.DataCollectionId)
                .Index(t => t.WorkQualityId)
                .Index(t => t.ProjectCountingId)
                .Index(t => t.PlatformDesignId)
                .Index(t => t.DesignStepsId);
            
            CreateTable(
                "dbo.PlatformDesigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTile = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        ButtonText = c.String(),
                        ModalTitle = c.String(),
                        ModalsContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectCountiings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        CountingNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkQualitySections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        ButtonText = c.String(),
                        ModalTitle = c.String(),
                        ModalsContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        UrlIcon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.OnlineCertifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                        CourseLocation = c.String(),
                        IconUrl = c.String(),
                        CourseDescription = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                        FinishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PortfolioAbouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PortfolioBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        BackgroundImage = c.String(),
                        SliderImagesUrl = c.String(),
                        ButtonUrl = c.String(),
                        ButtonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PortfolioProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        ProjectName = c.String(),
                        ProjectType = c.String(),
                        ProjectImageUrl = c.String(),
                        ProjectPublishDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.String(),
                        BannerId = c.Int(nullable: false),
                        PortfolioAboutId = c.Int(nullable: false),
                        WorkExperienceId = c.Int(nullable: false),
                        EducationId = c.Int(nullable: false),
                        OnlineCertificationId = c.Int(nullable: false),
                        PortfolioProjectId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                        PortfolioContactDetails = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId, cascadeDelete: true)
                .ForeignKey("dbo.Interests", t => t.InterestId, cascadeDelete: true)
                .ForeignKey("dbo.OnlineCertifications", t => t.OnlineCertificationId, cascadeDelete: true)
                .ForeignKey("dbo.PortfolioAbouts", t => t.PortfolioAboutId, cascadeDelete: true)
                .ForeignKey("dbo.PortfolioBanners", t => t.BannerId, cascadeDelete: true)
                .ForeignKey("dbo.ContactDetails", t => t.PortfolioContactDetails, cascadeDelete: true)
                .ForeignKey("dbo.PortfolioProjects", t => t.PortfolioProjectId, cascadeDelete: true)
                .ForeignKey("dbo.WorkExperiences", t => t.WorkExperienceId, cascadeDelete: true)
                .Index(t => t.BannerId)
                .Index(t => t.PortfolioAboutId)
                .Index(t => t.WorkExperienceId)
                .Index(t => t.EducationId)
                .Index(t => t.OnlineCertificationId)
                .Index(t => t.PortfolioProjectId)
                .Index(t => t.InterestId)
                .Index(t => t.PortfolioContactDetails);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        CompanyName = c.String(),
                        CompanyLocation = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        JobDesicription = c.String(),
                        LogoUrl = c.String(),
                        JobSubDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequstingUIDesigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        ButonText = c.String(),
                        ButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequstingUIForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComnayName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        NumberOfEmployee = c.String(),
                        CurrentWebSiteUrl = c.String(),
                        RequestDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppointmentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IdeaLink = c.String(),
                        CompanyNameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfCompanies", t => t.CompanyNameId, cascadeDelete: true)
                .Index(t => t.CompanyNameId);
            
            CreateTable(
                "dbo.TypeOfCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.UIBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UIPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.String(),
                        UIBannerId = c.Int(nullable: false),
                        UIProcessId = c.Int(nullable: false),
                        UISetpsId = c.Int(nullable: false),
                        UIUxMatterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UIBanners", t => t.UIBannerId, cascadeDelete: true)
                .ForeignKey("dbo.UIProcesses", t => t.UIProcessId, cascadeDelete: true)
                .ForeignKey("dbo.UIUXMatterSections", t => t.UIUxMatterId, cascadeDelete: true)
                .ForeignKey("dbo.UIUXSteps", t => t.UISetpsId, cascadeDelete: true)
                .Index(t => t.UIBannerId)
                .Index(t => t.UIProcessId)
                .Index(t => t.UISetpsId)
                .Index(t => t.UIUxMatterId);
            
            CreateTable(
                "dbo.UIProcesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UIUXMatterSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UIUXSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UIPages", "UISetpsId", "dbo.UIUXSteps");
            DropForeignKey("dbo.UIPages", "UIUxMatterId", "dbo.UIUXMatterSections");
            DropForeignKey("dbo.UIPages", "UIProcessId", "dbo.UIProcesses");
            DropForeignKey("dbo.UIPages", "UIBannerId", "dbo.UIBanners");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.RequstingUIForms", "CompanyNameId", "dbo.TypeOfCompanies");
            DropForeignKey("dbo.Portfolios", "WorkExperienceId", "dbo.WorkExperiences");
            DropForeignKey("dbo.Portfolios", "PortfolioProjectId", "dbo.PortfolioProjects");
            DropForeignKey("dbo.Portfolios", "PortfolioContactDetails", "dbo.ContactDetails");
            DropForeignKey("dbo.Portfolios", "BannerId", "dbo.PortfolioBanners");
            DropForeignKey("dbo.Portfolios", "PortfolioAboutId", "dbo.PortfolioAbouts");
            DropForeignKey("dbo.Portfolios", "OnlineCertificationId", "dbo.OnlineCertifications");
            DropForeignKey("dbo.Portfolios", "InterestId", "dbo.Interests");
            DropForeignKey("dbo.Portfolios", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropForeignKey("dbo.HomePages", "WorkQualityId", "dbo.WorkQualitySections");
            DropForeignKey("dbo.HomePages", "ProjectCountingId", "dbo.ProjectCountiings");
            DropForeignKey("dbo.HomePages", "PlatformDesignId", "dbo.PlatformDesigns");
            DropForeignKey("dbo.HomePages", "BannerId", "dbo.HomeBanners");
            DropForeignKey("dbo.HomePages", "DesignStepsId", "dbo.DesignSteps");
            DropForeignKey("dbo.HomePages", "DataCollectionId", "dbo.DataCollections");
            DropForeignKey("dbo.ContactPages", "ContactMattersId", "dbo.ContactMatters");
            DropForeignKey("dbo.ContactPages", "CotnactDetailsId", "dbo.ContactDetails");
            DropForeignKey("dbo.ContactPages", "BannerId", "dbo.ContactBanners");
            DropForeignKey("dbo.CodePages", "ProgrammingId", "dbo.WebProgrammingTools");
            DropForeignKey("dbo.CodePages", "UI_UX_Id", "dbo.UI_UX_Tools");
            DropForeignKey("dbo.CodePages", "SubscriptionId", "dbo.Subscribes");
            DropForeignKey("dbo.CodePages", "DesignCodeId", "dbo.DesignCodeSections");
            DropForeignKey("dbo.CodePages", "BannerId", "dbo.CodeBanners");
            DropForeignKey("dbo.AboutPages", "StartUpProgramId", "dbo.StartUpPrograms");
            DropForeignKey("dbo.AboutPages", "StartUpProcessId", "dbo.StartUpProcesses");
            DropForeignKey("dbo.AboutPages", "MeetOurTeamId", "dbo.MeetOutTeams");
            DropForeignKey("dbo.TeamSocialMedias", "MeetOutTeam_Id", "dbo.MeetOutTeams");
            DropForeignKey("dbo.AboutPages", "BannerId", "dbo.AboutPageBanners");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UIPages", new[] { "UIUxMatterId" });
            DropIndex("dbo.UIPages", new[] { "UISetpsId" });
            DropIndex("dbo.UIPages", new[] { "UIProcessId" });
            DropIndex("dbo.UIPages", new[] { "UIBannerId" });
            DropIndex("dbo.RequstingUIForms", new[] { "CompanyNameId" });
            DropIndex("dbo.Portfolios", new[] { "PortfolioContactDetails" });
            DropIndex("dbo.Portfolios", new[] { "InterestId" });
            DropIndex("dbo.Portfolios", new[] { "PortfolioProjectId" });
            DropIndex("dbo.Portfolios", new[] { "OnlineCertificationId" });
            DropIndex("dbo.Portfolios", new[] { "EducationId" });
            DropIndex("dbo.Portfolios", new[] { "WorkExperienceId" });
            DropIndex("dbo.Portfolios", new[] { "PortfolioAboutId" });
            DropIndex("dbo.Portfolios", new[] { "BannerId" });
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropIndex("dbo.HomePages", new[] { "DesignStepsId" });
            DropIndex("dbo.HomePages", new[] { "PlatformDesignId" });
            DropIndex("dbo.HomePages", new[] { "ProjectCountingId" });
            DropIndex("dbo.HomePages", new[] { "WorkQualityId" });
            DropIndex("dbo.HomePages", new[] { "DataCollectionId" });
            DropIndex("dbo.HomePages", new[] { "BannerId" });
            DropIndex("dbo.ContactPages", new[] { "ContactMattersId" });
            DropIndex("dbo.ContactPages", new[] { "CotnactDetailsId" });
            DropIndex("dbo.ContactPages", new[] { "BannerId" });
            DropIndex("dbo.CodePages", new[] { "SubscriptionId" });
            DropIndex("dbo.CodePages", new[] { "DesignCodeId" });
            DropIndex("dbo.CodePages", new[] { "UI_UX_Id" });
            DropIndex("dbo.CodePages", new[] { "ProgrammingId" });
            DropIndex("dbo.CodePages", new[] { "BannerId" });
            DropIndex("dbo.TeamSocialMedias", new[] { "MeetOutTeam_Id" });
            DropIndex("dbo.AboutPages", new[] { "MeetOurTeamId" });
            DropIndex("dbo.AboutPages", new[] { "StartUpProcessId" });
            DropIndex("dbo.AboutPages", new[] { "StartUpProgramId" });
            DropIndex("dbo.AboutPages", new[] { "BannerId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.UIUXSteps");
            DropTable("dbo.UIUXMatterSections");
            DropTable("dbo.UIProcesses");
            DropTable("dbo.UIPages");
            DropTable("dbo.UIBanners");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.TypeOfCompanies");
            DropTable("dbo.RequstingUIForms");
            DropTable("dbo.RequstingUIDesigns");
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.Portfolios");
            DropTable("dbo.PortfolioProjects");
            DropTable("dbo.PortfolioBanners");
            DropTable("dbo.PortfolioAbouts");
            DropTable("dbo.OnlineCertifications");
            DropTable("dbo.Menus");
            DropTable("dbo.Interests");
            DropTable("dbo.WorkQualitySections");
            DropTable("dbo.ProjectCountiings");
            DropTable("dbo.PlatformDesigns");
            DropTable("dbo.HomePages");
            DropTable("dbo.HomeBanners");
            DropTable("dbo.Educations");
            DropTable("dbo.DesignSteps");
            DropTable("dbo.DataCollections");
            DropTable("dbo.ContactPages");
            DropTable("dbo.ContactMatters");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.ContactBanners");
            DropTable("dbo.WebProgrammingTools");
            DropTable("dbo.UI_UX_Tools");
            DropTable("dbo.Subscribes");
            DropTable("dbo.DesignCodeSections");
            DropTable("dbo.CodePages");
            DropTable("dbo.CodeBanners");
            DropTable("dbo.StartUpPrograms");
            DropTable("dbo.StartUpProcesses");
            DropTable("dbo.TeamSocialMedias");
            DropTable("dbo.MeetOutTeams");
            DropTable("dbo.AboutPages");
            DropTable("dbo.AboutPageBanners");
        }
    }
}
