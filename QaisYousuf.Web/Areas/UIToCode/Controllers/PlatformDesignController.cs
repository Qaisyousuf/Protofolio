using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class PlatformDesignController : Controller
    {
        private readonly IUnitOfWork uow;

        public PlatformDesignController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: UIToCode/PlatformDesign
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPlatformDesignData()
        {
            var platformDesign = uow.PlatformDesignRepository.GetAll();

            List<PlatformDesignViewModel> viewmodel = new List<PlatformDesignViewModel>();

            foreach (var item in platformDesign)
            {
                viewmodel.Add(new PlatformDesignViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    ButtonText=item.ButtonText,
                    ImageContent=item.ImageContent,

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PlatformDesignViewModel());
        }

        [HttpPost]
        public ActionResult Create(PlatformDesignViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                PlatformDesign platformDesign = new PlatformDesign
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                    ButtonText=viewmodel.ButtonText,
                    ImageContent=viewmodel.ImageContent,
                    
      
                };
                uow.PlatformDesignRepository.Add(platformDesign);
                uow.Commit();

            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var platformDesign = uow.PlatformDesignRepository.GetById(id);

            PlatformDesignViewModel viewmodel = new PlatformDesignViewModel
            {
                Id=platformDesign.Id,
                MainTitle=platformDesign.MainTitle,
                SubTitle=platformDesign.SubTitle,
                Content=platformDesign.Content,
                ImageUrl=platformDesign.ImageUrl,
                ButtonText=platformDesign.ButtonText,
                ImageContent=platformDesign.ImageContent,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(PlatformDesignViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var platformDesign = uow.PlatformDesignRepository.GetById(viewmodel.Id);

                platformDesign.Id = viewmodel.Id;
                platformDesign.MainTitle = viewmodel.MainTitle;
                platformDesign.SubTitle = viewmodel.SubTitle;
                platformDesign.Content = viewmodel.Content;
                platformDesign.ImageUrl = viewmodel.ImageUrl;
                platformDesign.ButtonText = viewmodel.ButtonText;
                platformDesign.ImageContent = viewmodel.ImageContent;


                uow.PlatformDesignRepository.Update(platformDesign);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var platformDesign = uow.PlatformDesignRepository.GetById(id);

            PlatformDesignViewModel viewmodel = new PlatformDesignViewModel
            {
                Id=platformDesign.Id,
                MainTitle=platformDesign.MainTitle,
                SubTitle=platformDesign.SubTitle,
                Content=platformDesign.Content,
                ImageUrl=platformDesign.ImageUrl,
                ButtonText=platformDesign.ButtonText,
                ImageContent=platformDesign.ImageContent,
            };
            uow.PlatformDesignRepository.Remove(platformDesign);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var platformDesign = uow.PlatformDesignRepository.GetById(id);

            PlatformDesignViewModel viewmodel = new PlatformDesignViewModel
            {
                Id = platformDesign.Id,
                MainTitle = platformDesign.MainTitle,
                SubTitle = platformDesign.SubTitle,
                Content = platformDesign.Content,
                ImageUrl = platformDesign.ImageUrl,
                ButtonText = platformDesign.ButtonText,
                ImageContent = platformDesign.ImageContent,
            };
            return View(viewmodel);
        }
    }
}