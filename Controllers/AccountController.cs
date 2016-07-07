using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PatientMaster.Models;
using System.Data;

namespace PatientMaster.Controllers
{
    public class AccountController : Controller
    {
         public ActionResult SignIn()
        {
            if (Session["usernamesignin"] == null && Session["usernamesignup"] == null)
            {

                return View();

            }
            else
            {
               
                return RedirectToAction("WelcomeBack", "Account");
               
            }
        }

        public ActionResult SignUp()
        {
            if (Session["usernamesignin"] == null && Session["usernamesignup"] == null)
            {
               
                return View();

            }
            else
            {
              
                return RedirectToAction("WelcomeBack", "Account");
            }

           
        }

        public ActionResult WelcomeBack()
        {
            if (Session["usernamesignup"]==null && Session["usernamesignin"] == null)
            {
                return RedirectToAction("SignUp", "Account");

            }
            else
            {
                return View();
            }
          
        }

        public JsonResult SignUpJson(PersonCLS obj)
        {
            try
            {

                obj.insert(obj);
                Session["usernamesignup"] = obj.firstname + " " + obj.lastname;
              
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch
            {

                return Json("", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult CheckUserPass(PersonCLS obj)
        {
            DataTable dt = new DataTable();
            List<PersonCLS> viewModelList = new List<PersonCLS>();
            dt = obj.CheckUserNamePass(obj);
            if (dt != null && dt.Rows.Count > 0)
            {
                Session["usernamesignin"] = dt.Rows[0]["firstname"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
             
                //Session["username"] = dt.Rows[0]["firstname"] + " " + dt.Rows[0]["lastname"];         
                return Json(string.Format("Success, {0} ", dt.Rows[0]["id"].ToString()));

            }
            else
            {
                return Json(viewModelList, JsonRequestBehavior.AllowGet);

            }


        }

        public ActionResult SignOut()

        {
            Session.RemoveAll();
            return RedirectToAction("SignIn", "Account");

        }
    }
}
