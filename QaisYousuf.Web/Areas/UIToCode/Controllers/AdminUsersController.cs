using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using QaisYousuf.Services;
using QaisYousuf.Data.Context;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IAuthenticationServices authServer;
        private readonly UIContext context;

        public AdminUsersController(IUnitOfWork uow,IAuthenticationServices authServer,UIContext context)
        {
            this.uow = uow;
            this.authServer = authServer;
            this.context = context;
        }
        public ActionResult Index()
        {
            var user = uow.UserRepository.GetUserWithRoles();
           
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            InsertUsersViewModel viewmodel = new InsertUsersViewModel();

            List<CheckBoxViewModel> checkBoxViewModels = new List<CheckBoxViewModel>();

            var roles = uow.UserRepository.GetRoles();

            foreach (var role in roles)
            {
                checkBoxViewModels.Add(new CheckBoxViewModel
                {
                    Id = role.Id,
                    Text = role.Name,
                    Checked = false,
                });
                
            }
            viewmodel.Roles = checkBoxViewModels;
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="UserName,Password,ConfirmPassword,Email")]
        InsertUsersViewModel viewmodel, int[] Roles)
        {
            if (ModelState.IsValid)
            {

                bool registerSuccess = authServer.Register
                    (viewmodel.Email, viewmodel.UserName, viewmodel.Password, out int? userId);
                if (registerSuccess)
                {
                    if (userId != null)
                    {
                        if (Roles != null)
                        {
                            authServer.AddUserToRoles(userId, Roles);
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong please try again");
                    return View(viewmodel);
                }
            }
            List<CheckBoxViewModel> checkBoxs = new List<CheckBoxViewModel>();
            var roles = uow.UserRepository.GetRoles();

            foreach (var role in roles)
            {
                checkBoxs.Add(new CheckBoxViewModel { Id = role.Id, Text = role.Name, Checked = false });
            }
            viewmodel.Roles = checkBoxs;
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var GetEdit = GetEditUser(id);
            return View(GetEdit);

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,Email")] EditUserViewModel viewmodel, int[] roles)
        {
            if (ModelState.IsValid)
            {
                var dbUser =uow.Context.Users.Where(x => x.Id == viewmodel.Id).FirstOrDefault();

                if (dbUser != null)
                {
                    int[] currentUserRoles = dbUser.Roles.Select(x => x.Id).ToArray();
                    string[] roleName = uow.Context.Roles.Where(x => currentUserRoles.Contains(x.Id)).Select(x => x.Name).ToArray();

                    uow.RoleRepository.RemoveById(currentUserRoles);
                    uow.UserRepository.RemoveById(dbUser.Id);

                    

                    dbUser.Email = viewmodel.Email;
                    dbUser.UserName = viewmodel.UserName;
                    dbUser.PasswordHash = viewmodel.Password;

                    

                    uow.UserRepository.Update(dbUser);
                    uow.Commit();

                    if (roles != null)
                    {
                        string[] requiredRoles = uow.Context.Roles.Where(x => roles.Contains(x.Id)).Select(x => x.Name).ToArray();

                       // uow.UserRepository.AddUserToRolesEdit(dbUser.Id, requiredRoles,context);
                        

                    }
                }
            }
            return RedirectToAction(nameof(Index));

        }
        private EditUserViewModel GetEditUser(int id)
        {

            var dbUser = context.Users.Where(x => x.Id == id).FirstOrDefault();

            var currentRoles = dbUser.Roles.Select(x => x.Id).ToList();

            var allRoles = uow.RoleRepository.GetAll();


            EditUserViewModel viewmodel = new EditUserViewModel();

            viewmodel.Id = dbUser.Id;
            viewmodel.Email = dbUser.Email;
            viewmodel.UserName = dbUser.UserName;
            viewmodel.Password = dbUser.PasswordHash;

            foreach (var role in allRoles)
            {
                if(currentRoles.Contains(role.Id))
                {
                    viewmodel.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = true,
                    });
                }
                else
                {
                    viewmodel.Roles.Add(new CheckBoxViewModel
                    {
                        Id=role.Id,
                        Text=role.Name,
                        Checked=false,
                    });
                }
            }
            return viewmodel;

            //var userFromdb = uow.Context.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            //var Currentrole = userFromdb.Roles.Select(x => x.Id).ToList();

            //var RoleFromdb = uow.UserRepository.GetRoles();
            //var roleByid = context.Roles.Find(id);

            //EditUserViewModel viewmodel = new EditUserViewModel
            //{
            //    UserName = userFromdb.UserName,
            //    Email = userFromdb.Email,
                

            //};

            //foreach (var role in RoleFromdb)
            //{
            //    if (Currentrole.Contains(role.Id))
            //    {
            //        viewmodel.Roles.Add(new CheckBoxViewModel
            //        {
            //            Id = role.Id,
            //            Text = role.Name,
            //            Checked = true
            //        });
            //    }

            //    else
            //    {
            //        viewmodel.Roles.Add(new CheckBoxViewModel
            //        {
            //            Id = role.Id,
            //            Text = role.Name,
            //            Checked = false
            //        });
            //    }
            //}
            

        }
        private DeleteUserViewModel DeleteUser(int? id)
        {
            var userFromdb = uow.Context.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            var Currentrole = userFromdb.Roles.Select(x => x.Id).ToList();


            var RoleFromdb = uow.UserRepository.GetRoles();
            var roleByid = context.Roles.Find(id);

            DeleteUserViewModel viewmodelDelete = new DeleteUserViewModel
            {
                UserName = userFromdb.UserName,
                Email = userFromdb.Email,
                
                Password = userFromdb.PasswordHash,
                ConfirmPassword = userFromdb.PasswordHash,

            };

            foreach (var role in RoleFromdb)
            {
                if (Currentrole.Contains(role.Id))
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = true
                    });
                }
                else
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = false
                    });
                }
            }
            return viewmodelDelete;

        }
        private DetailsUserViewModel DetailsUser(int id)
        {
            var userFromdb = uow.Context.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            var Currentrole = userFromdb.Roles.Select(x => x.Id).ToList();


            var RoleFromdb = uow.UserRepository.GetRoles();
            var roleByid = uow.Context.Roles.Find(id);

            DetailsUserViewModel viewmodelDelete = new DetailsUserViewModel
            {
                UserName = userFromdb.UserName,
                Email = userFromdb.Email,
                Password = userFromdb.PasswordHash,


            };

            foreach (var role in RoleFromdb)
            {
                if (Currentrole.Contains(role.Id))
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = true
                    });
                }
                else
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = false
                    });
                }
            }
            return viewmodelDelete;

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var GetEdit = DeleteUser(id);


            return View(GetEdit);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var userFromdb = uow.UserRepository.GetById(id);

            uow.UserRepository.Remove(userFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var GetEdit = DetailsUser(id);


            return View(GetEdit);
        }




    }
}