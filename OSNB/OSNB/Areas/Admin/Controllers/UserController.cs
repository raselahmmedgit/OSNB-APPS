using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OSNB.Helpers;
using OSNB.Models;
using OSNB.ViewModels;
using OSNB.ViewModels.DataTableViewModels;

namespace OSNB.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        private AppDbContext _db = new AppDbContext();
        //
        // GET: /Admin/User/

        public ActionResult Index()
        {
            return View();
        }

        // for display datatable
        public ActionResult GetUsers(DataTableParamModel param)
        {
            var users = _db.Users.ToList();

            var viewUsers = users.Select(usr => new UserTableModel() { UserId = Convert.ToString(usr.UserName), UserName = usr.UserName, Email = usr.Email, IsApproved = usr.IsApproved == true ? "Yes" : "No" });

            IEnumerable<UserTableModel> filteredUsers;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredUsers = viewUsers.Where(usr => (usr.UserName ?? "").Contains(param.sSearch)).ToList();
            }
            else
            {
                filteredUsers = viewUsers;
            }

            var viewOdjects = filteredUsers.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from usrMdl in viewOdjects
                         select new[] { usrMdl.UserName, usrMdl.UserName, usrMdl.Email, usrMdl.IsApproved, usrMdl.UserName };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = users.Count(),
                iTotalDisplayRecords = filteredUsers.Count(),
                aaData = result
            },
                            JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /User/Details/By ID

        public ActionResult Details(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user != null)
                {
                    var userViewModel = new UserViewModel { UserName = user.UserName, Email = user.Email };

                    //return View(userViewModel);
                    return PartialView("_Details", userViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "User");
            }
        }

        //
        // GET: /User/Add

        public ActionResult Add()
        {
            try
            {
                return PartialView("_Add");
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "User");
            }
        }

        //
        // POST: /User/Add

        [HttpPost]
        public ActionResult Add(UserViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User { UserName = viewModel.UserName };

                    //MembershipCreateStatus createStatus;
                    //Membership.CreateUser(viewModel.UserName, viewModel.Password, viewModel.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);

                    _db.Users.Add(user);
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return Content("Sorry! Unable to add this user.");
            }

        }

        //
        // GET: /User/Edit/By ID

        public ActionResult Edit(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user != null)
                {
                    var userViewModel = new UserViewModel { UserName = user.UserName, Email = user.Email };

                    return PartialView("_Edit", userViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "User");
            }
        }

        //
        // POST: /User/Edit/By ID

        [HttpPost]
        public ActionResult Edit(UserViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User { UserName = viewModel.UserName };

                    _db.Entry(user).State = EntityState.Modified;
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return Content("Sorry! Unable to edit this user.");
            }
        }

        //
        // GET: /User/Delete/By ID

        public ActionResult Delete(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user != null)
                {
                    var userViewModel = new UserViewModel { UserName = user.UserName, Email = user.Email };

                    return PartialView("_Delete", userViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "User");
            }
        }

        //
        // POST: /User/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                User user = _db.Users.Find(id);
                if (user != null)
                {
                    _db.Users.Remove(user);
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return Content("Sorry! Unable to delete this user.");
            }
        }

        public PartialViewResult GetRoles(string id)
        {
            string userName = id;

            var user = _db.Users.Where(x => x.UserName == userName).FirstOrDefault();

            var roles = user.Roles.ToList();

            IEnumerable<RoleTableModel> productTableModels = roles.Count() == 0 ? null : (roles.Select(pro => new RoleTableModel
            {
                RoleName = pro.RoleName,
            }).ToList());


            return PartialView("_RoleList", productTableModels);
        }
    }
}
