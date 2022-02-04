using AbendLog.BusinessAccess.Manager;
using AbendLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbendLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session["Name"] = null;
            Session["LANID"] = null;
            Session["UserType"] = null;
            return RedirectToAction("Index", "Home");
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            BusinessAccess.Model.User user = new UserManager().Vaildate(model.Email, model.Password);

            if (user.ID == 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You have entered the Invalid Credentials'); window.location.href='/Home/Index';</script>");
            }
            Session["ID"] = user.ID;
            Session["Name"] = user.Name;
            Session["LANID"] = user.LANID;
            Session["EmailId"] = user.EmailID;
            Session["UserType"] = user.UserType;
            return RedirectToAction("Index", "AbendLog");
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (new UserManager().VaildateUser(model.LanID, model.Email).ID == 0)
                    {
                        new UserManager().AddUser(model.Name, model.Email, model.LanID, model.Password);
                        return Content("<script language='javascript' type='text/javascript'>alert('Your account successfully.'); window.location.href='/Home/Index';</script>");
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('UserName or Email is already exists'); window.location.href='/Home/Index';</script>");
                    }
                }
                catch (Exception ex)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Account creation failed, Please contact administator'); window.location.href='/Home/Index';</script>");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}