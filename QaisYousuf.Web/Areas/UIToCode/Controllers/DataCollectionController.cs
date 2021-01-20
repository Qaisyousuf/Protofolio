using QaisYousuf.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class DataCollectionController : Controller
    {
        private readonly IUnitOfWork uow;

        public DataCollectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataCollectin()
        {
            var dataCollection = uow.DataCollectionRepository.GetAll();

            List<DataCollectionViewModel> viewmodel = new List<DataCollectionViewModel>();

            foreach (var item in dataCollection)
            {
                viewmodel.Add(new DataCollectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.Image
                });
            }

            return Json(new { data=viewmodel}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DataCollectionViewModel());
        }

        [HttpGet]
        public ActionResult AddNewRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DataCollectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                DataCollection dataCollection = new DataCollection
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    Content=viewmodel.Content,
                    Image=viewmodel.ImageUrl,
                };
                uow.DataCollectionRepository.Add(dataCollection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dataCollection = uow.DataCollectionRepository.GetById(id);

            DataCollectionViewModel viewmodel = new DataCollectionViewModel
            {
                Id= dataCollection.Id,
                MainTitle= dataCollection.MainTitle,
                SubTitle= dataCollection.SubTitle,
                Content= dataCollection.Content,
                ImageUrl= dataCollection.Image
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(DataCollectionViewModel viewmodel)
        {

            if(ModelState.IsValid)
            {
                var dataCollection = uow.DataCollectionRepository.GetById(viewmodel.Id);

                dataCollection.Id = viewmodel.Id;
                dataCollection.MainTitle = viewmodel.MainTitle;
                dataCollection.SubTitle = viewmodel.SubTitle;
                dataCollection.Content = viewmodel.Content;
                dataCollection.Image = viewmodel.ImageUrl;

                uow.DataCollectionRepository.Update(dataCollection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dataCollection = uow.DataCollectionRepository.GetById(id);

            DataCollectionViewModel viewmodel = new DataCollectionViewModel
            {

                Id=dataCollection.Id,
                MainTitle=dataCollection.MainTitle,
                SubTitle=dataCollection.SubTitle,
                Content=dataCollection.Content,
                ImageUrl=dataCollection.Image
            };
            uow.DataCollectionRepository.Remove(dataCollection);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dataCollection = uow.DataCollectionRepository.GetById(id);

            DataCollectionViewModel viewmodel = new DataCollectionViewModel
            {
                Id=dataCollection.Id,
                MainTitle=dataCollection.MainTitle,
                SubTitle=dataCollection.SubTitle,
                Content=dataCollection.Content,
                ImageUrl=dataCollection.Image,
            };

            return View(viewmodel);
        }

        
    }
}