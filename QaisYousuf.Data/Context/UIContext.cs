using QaisYousuf.Data.FluentAPI;
using QaisYousuf.Models;
using System;
using System.Data.Entity;

namespace QaisYousuf.Data.Context
{
    public class UIContext:DbContext
    {
        public UIContext():base("UIToCode")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<AboutPageBanner> AboutPageBanners { get; set; }
        public DbSet<CodeBanner> CodeBanners { get; set; }
        public DbSet<CodePage> CodePage { get; set; }
        public DbSet<ContactBanner> ContactBanners { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<ContactMatters> ContactMatters { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<DataCollection> DataCollections { get; set; }
        public DbSet<DesignCodeSection> DesignCodeSections { get; set; }
        public DbSet<DesignSteps> DesignSetps { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<HomeBanner> HomeBanners { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<MeetOurTeam> MeetOutTeams { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<OnlineCertification> OnlineCertifications { get; set; }
        public DbSet<PlatformDesign> PlatformsDesign { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioAbout> PortfolioAbouts { get; set; }
        public DbSet<PortfolioBanner> PortfolioBanners { get; set; }
        public DbSet<PortfolioProject> PortfolioProjects { get; set; }
        public DbSet<ProjectCounting> ProjectCountiings { get; set; }
        public DbSet<RequstingUIDesign> RequstingUIDesigns { get; set; }
        public DbSet<RequstingUIForm> RequstingUIForms { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<StartUpProcess> StartUpProcesses { get; set; }
        public DbSet<StartUpProgram> StartUpProgram { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<TeamSocialMedia> TeamSocialMedias { get; set; }
        public DbSet<TypeOfCompany> TypeOfCompanies { get; set; }
        public DbSet<UI_UX_Tools> UIUXTools { get; set; }
        public DbSet<UIBanner> UIBanners { get; set; }
        public DbSet<UIPage> UIPages { get; set; }
        public DbSet<UIProcess> UIProcess { get; set; }
        public DbSet<UIUXMatterSection> UIUXMatterSections { get; set; }
        public DbSet<UIUXSteps> UIUXSteps { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<WebProgrammingTools> WebProgrammingTools { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<WorkQualitySection> WorkQualitySections { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
           
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
