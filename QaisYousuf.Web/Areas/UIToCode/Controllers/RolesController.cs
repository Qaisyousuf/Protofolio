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
    [Authorize(Roles = "Supper Admin")]
    public class RolesController : Controller
    {
        private readonly IUnitOfWork uow;

        public RolesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRolesData()
        {
            var role = uow.RoleRepository.GetAll();

            List<RolesViewModel> viewmodel = new List<RolesViewModel>();

            foreach (var item in role)
            {
                viewmodel.Add(new RolesViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Users=item.Users,
                    
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new RolesViewModel());
        }

        [HttpPost]
        public ActionResult Create(RolesViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                RoleModel role = new RoleModel
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    Users=viewmodel.Users,
                };

                uow.RoleRepository.Add(role);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var role = uow.RoleRepository.GetById(id);

            RolesViewModel viewmodel = new RolesViewModel
            {
                Id=role.Id,
                Name=role.Name,
                Users=role.Users,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(RolesViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var role = uow.RoleRepository.GetById(viewmodel.Id);

                role.Id = viewmodel.Id;
                role.Name = viewmodel.Name;
                role.Users = viewmodel.Users;

                uow.RoleRepository.Update(role);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var role = uow.RoleRepository.GetById(id);

            RolesViewModel viewmodel = new RolesViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Users=role.Users,
            };

            uow.RoleRepository.Remove(role);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var role = uow.RoleRepository.GetById(id);

            RolesViewModel viewmodel = new RolesViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Users = role.Users,
            };

            return View(viewmodel);

        }
    }
}