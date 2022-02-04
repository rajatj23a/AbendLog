using AbendLog.BusinessAccess.Manager;
using AbendLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbendLog.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Update()
        {
            if (Session["LANID"] != null)
            {
                var userDetails = new List<SelectListItem>();
                var users = new UserManager().Getusers();
                LoginViewModel loginViewModel = new LoginViewModel();
                if (users.Count > 0)
                {
                    foreach (var item in users.OrderBy(a => a.Name))
                    {
                        userDetails.Add(new SelectListItem() { Value = item.LANID, Text = item.Name });
                    }
                }
                loginViewModel.UserDetails = userDetails;
                return View(loginViewModel);
            }
            else
            {
                return RedirectToAction("Index", "AbendLog");
            }
        }

        public JsonResult GetUserDetails(string lanId)
        {
            LoginViewModel user = new LoginViewModel();
            var users = new UserManager().Getusers().Where(a=>a.LANID==lanId).First();
            user.Active =Convert.ToBoolean(users.Active);
            user.UserType = users.UserType;
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Update(LoginViewModel model)
        {
            if (Session["LANID"] != null)
            {
                try
                {
                    new UserManager().UpdateUser(model.LanID, model.Active, model.UserType, Session["LANID"].ToString());
                    return Content("<script language='javascript' type='text/javascript'>alert('Records updated successfully.'); window.location.href='/UserManagement/Update';</script>");

                }
                catch (Exception ex)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Records not updated, Please contact administator'); window.location.href='/UserManagement/Update';</script>");
                }
            }
            else
            {
                return RedirectToAction("Index", "AbendLog");
            }
        }
    }
}