using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        public UIContext Context { get; }

        public IAboutPageBannerRepository AboutPageBannerRepository => new AboutPageBannerRepository(Context);
       
        public IAboutPageRepository AboutPageRepository => new AboutPageRepository(Context);

        public ICodeBannerRepository CodeBannerRepository => new CodeBannerRepository(Context);

        public ICodePageRepository CodePageRepository => new CodePageRepository(Context);

        public IContactBannerRepository ContactBannerRepository => new  ContactBannerRepository(Context);

        public IContactDetailsRepository ContactDetialsRepository => new ContactDetailsRepository(Context);

        public IContactFormRepository ContactFormRepository => new ContactFormRepository(Context);

        public IContactMatterRepository ContactMatterRepository => new ContactMatterRepository(Context);

        public IContactPageRepository ContactPageRepository => new ContactPageRepository(Context);

        public IDataCollectionRepository DataCollectionRepository => new DataCollectionRepository(Context);

        public IDesignCodeSectionRepository DesignCodeSectionRepository => new DesignCodeSectionRepository(Context);

        public IDesignStepsRepository DesignStepsRepository => new DesignStepsRepository(Context);

        public IEducationRepository EducationRepository => new EducationRepository(Context);

        public IHomeBannerRepository HomeBannerRepository => new HomeBannerRepository(Context);

        public IHomePageRepository HomePageRepository => new HomePageRepository(Context);

        public IIntresetRepository IntresetRepository => new InterestRepository(Context);

        public IMeetOurTeamRepository MeetOurTeamRepository => new MeetOurTeamRepository(Context);

        public IMenuRepository MenuRepository => new MenuRepository(Context);

        public IOnlineCertificationRepository OnlineCertificationRepository => new OnlineCertificationRepository(Context);

        public IPlatformDesignRepository PlatformDesignRepository => new PlatformDesignRepository(Context);

        public IPortfolioAboutRepository PortfolioAboutRepository => new PortfolioAboutRepository(Context);

        public IPortfolioBannerRepository PortfolioBannerRepository => new PortfolioBannerRepository(Context);

        public IPortfolioProjectRepository PortfolioProjectRepository => new PortfolioProjectRepository(Context);

        public IPortfolioRepository PortfolioRepository => new PortfolioRepository(Context);

        public IProjectCountingRepository ProjectCountingRepository => new ProjectCountingRepository(Context);

        public IRequstingUIDesignRepository RequstingUIDesignRepository => new RequestingUIDesignRepository(Context);

        public IRequstingUIFormRepository RequstingUIFormRepository => new RequestingUIFormRepository(Context);

        public ISiteSettingRepository SiteSettingRepository => new SiteSettingRepository(Context);

        public IStartUpProcessRepository StartUpProcessRepository => new StartUpProcessRepository(Context);

        public IStartUpProgramRepository StartUpProgramRepository => new StartUpProgramRepository(Context);

        public ISubscribeRepository SubscribeRepository => new SubscribeRepository(Context);

        public ITeamSocialMediaRepository TeamSocialMediaRepository => new TeamSocialMediaRepository(Context);

        public ITypeOfCompanyRepository TypeOfCompanyRepository => new TypeOfCompanyRepository(Context);

        public IUIBannerRepository UIBannerRepository => new UIBannerRepository(Context);

        public IUIPageRepository UIPageRepository => new UIPageRepository(Context);

        public IUIProcessRepository UIProcessRepository => new UIProcessRepository(Context);

        public IUIUXMatterSectionRepository UIUXMatterSectionRepository => new UIUXMatterSectionRepository(Context);

        public IUIUXStepsRepository UIUXStepsRepository => new UIUXStepsRepository(Context);

        public IUIUXToolsRepository UIUXToolsRepository => new UIUXToolsRepository(Context);

        public IWebProgrammingToolsRepository WebProgrammingToolsRepository => new WebProgrammingToolsRepository(Context);

        public IWorkExperienceRepository WorkExperienceRepository => new WorkExperienceRepository(Context);

        public IWorkQualitySectionRepository WorkQualitySectionRepository => new WorkQualitySectionRepository(Context);

        public IUserRepository UserRepository => new UserRepository(Context);

        public IProjectStatusRepository ProjectStatusRepository => new ProjectStatusRepository(Context);

        public IRoleRepository RoleRepository => new RoleRepository(Context);

        public IAdminDashboardRepository AdminDashboardRepository => new AdminDashboardRepository(Context);

        public IAdminActivityRepository AdminActivityRepository => new AdminActivityRepository(Context);

        public IUserActivityRepository UserActivityRepository => new UserActivityRepository(Context);

        public IUserDashBoardRepository UserDashboardRepository => new UserDashboardRepository(Context);

        public UnitOfWork()
        {
            Context = new UIContext();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
