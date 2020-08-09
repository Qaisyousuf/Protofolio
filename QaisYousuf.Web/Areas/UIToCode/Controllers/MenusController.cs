using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class MenusController : Controller
    {
        private readonly IUnitOfWork uow;

        public MenusController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var menu = uow.MenuRepository.GetAll();

            List<MenuViewModel> viewmodel = new List<MenuViewModel>();

            foreach (var item in menu)
            {
                viewmodel.Add(new MenuViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Url = item.Url,
                    ParentId = item.ParentId,
                    Parent = item.Parent,

                });
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult GetMenuData()
        {
            var menu = uow.MenuRepository.GetAll();

            List<MenuViewModel> viewmodel = new List<MenuViewModel>();

            foreach (var item in menu)
            {
                viewmodel.Add(new MenuViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Description=item.Description,
                    Url=item.Url,
                    ParentId=item.ParentId,
                    Parent=item.Parent,
                    
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DropDownMenu = uow.MenuRepository.GetAll();
            return View(new MenuViewModel());
        }

        [HttpPost]
        public ActionResult Create(MenuViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                Menu menu = new Menu
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Description=viewmodel.Description,
                    Url=viewmodel.Url,
                    Parent=viewmodel.Parent,
                    ParentId=viewmodel.ParentId,
                };

                uow.MenuRepository.Add(menu);
                uow.Commit();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenuViewModel viewmodel = new MenuViewModel
            {
                Id=menu.Id,
                Title=menu.Title,
                Description=menu.Description,
                Url=menu.Url,
                ParentId=menu.ParentId,
            };

            uow.Context.Entry(menu).Reference(x => x.Parent).Load();
            ViewBag.DropDownMenu = uow.MenuRepository.GetAll();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MenuViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var menu = uow.MenuRepository.GetById(viewmodel.Id);

                menu.Id = viewmodel.Id;
                menu.Title = viewmodel.Title;
                menu.Description = viewmodel.Description;
                menu.Url = viewmodel.Url;
                menu.ParentId = viewmodel.ParentId;
                menu.Parent = viewmodel.Parent;

                uow.MenuRepository.Update(menu);
                uow.Commit();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenuViewModel viewmodel = new MenuViewModel
            {
                Id = menu.Id,
                Title = menu.Title,
                Description = menu.Description,
                Url = menu.Url,
                ParentId = menu.ParentId,
                Parent=menu.Parent,
            };
            ViewBag.DropDownMenu = uow.MenuRepository.GetAll();
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenuViewModel viewmodel = new MenuViewModel
            {
                Id=menu.Id,
                Title=menu.Title,
                Description=menu.Description,
                Url=menu.Url,
                ParentId=menu.ParentId,
                Parent=menu.Parent,
            };

            uow.MenuRepository.Remove(menu);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenuViewModel viewmodel = new MenuViewModel
            {
                Id = menu.Id,
                Title = menu.Title,
                Description = menu.Description,
                Url = menu.Url,
                ParentId = menu.ParentId,
                Parent = menu.Parent,
            };
            ViewBag.DropDownMenu = uow.MenuRepository.GetAll();
            return View(viewmodel);
        }
    }
}