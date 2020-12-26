using QaisYousuf.Data.Context;
using System;

namespace QaisYousuf.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        UIContext Context { get; }

        IAboutPageBannerRepository AboutPageBannerRepository { get; }
        IAboutPageRepository AboutPageRepository { get; }
        ICodeBannerRepository CodeBannerRepository { get; }
        ICodePageRepository CodePageRepository { get; }
        IContactBannerRepository ContactBannerRepository { get; }
        IContactDetailsRepository ContactDetialsRepository { get; }
        IContactFormRepository ContactFormRepository { get; }
        IContactMatterRepository ContactMatterRepository { get; }
        IContactPageRepository ContactPageRepository { get; }
        IDataCollectionRepository DataCollectionRepository { get; }
        IDesignCodeSectionRepository DesignCodeSectionRepository { get; }
        IDesignStepsRepository DesignStepsRepository { get; }
        IEducationRepository EducationRepository { get; }
        IHomeBannerRepository HomeBannerRepository { get; }
        IHomePageRepository HomePageRepository { get; }
        IIntresetRepository IntresetRepository { get; }
        IMeetOurTeamRepository MeetOurTeamRepository { get; }
        IMenuRepository MenuRepository { get; }
        IOnlineCertificationRepository OnlineCertificationRepository { get; }
        IPlatformDesignRepository PlatformDesignRepository { get; }
        IPortfolioAboutRepository PortfolioAboutRepository { get; }
        IPortfolioBannerRepository PortfolioBannerRepository { get; }
        IPortfolioProjectRepository PortfolioProjectRepository { get; }
        IPortfolioRepository PortfolioRepository { get; }
        IProjectCountingRepository ProjectCountingRepository { get; }
        IRequstingUIDesignRepository RequstingUIDesignRepository { get; }
        IRequstingUIFormRepository RequstingUIFormRepository { get; }
        ISiteSettingRepository SiteSettingRepository { get; }
        IStartUpProcessRepository StartUpProcessRepository { get; }
        IStartUpProgramRepository StartUpProgramRepository { get; }
        ISubscribeRepository SubscribeRepository { get; }
        ITeamSocialMediaRepository TeamSocialMediaRepository { get; }
        ITypeOfCompanyRepository TypeOfCompanyRepository { get; }
        IUIBannerRepository UIBannerRepository { get; }
        IUIPageRepository UIPageRepository { get; }
        IUIProcessRepository UIProcessRepository { get; }
        IUIUXMatterSectionRepository UIUXMatterSectionRepository { get; }
        IUIUXStepsRepository UIUXStepsRepository { get; }
        IUIUXToolsRepository UIUXToolsRepository { get; }
        IWebProgrammingToolsRepository WebProgrammingToolsRepository { get; }
        IWorkExperienceRepository WorkExperienceRepository { get; }
        IWorkQualitySectionRepository WorkQualitySectionRepository { get; }
        IUserRepository UserRepository { get; }
        IProjectStatusRepository ProjectStatusRepository { get; }
        IRoleRepository RoleRepository { get; }
        IAdminDashboardRepository AdminDashboardRepository { get; }
        IAdminActivityRepository AdminActivityRepository { get; }
        void Commit();
    }
}
