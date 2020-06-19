using System.Web.Mvc;

namespace QaisYousuf.Web.Areas.UIToCode
{
    public class UIToCodeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UIToCode";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UIToCode_default",
                "UIToCode/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}