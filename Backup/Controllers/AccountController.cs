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
            if (Session["usernamesignup"] == null && Session["usernamesignin"] == null)
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
                Int32 checkemail = 0;
                Int64 i = 0;
                checkemail = obj.CheckEmail(obj);
                if(checkemail==0)
                {
                     i=  obj.insert(obj);
                    Session["usernamesignup"] = obj.firstname + " " + obj.lastname;
                    return Json(string.Format("Success, {0} ", obj.id));
                    //return Json("", JsonRequestBehavior.AllowGet);


                }
                else
                {

                    return Json("", JsonRequestBehavior.AllowGet);

                }
               
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Update(PersonCLS obj)
        {
            try
            {
                obj.update(obj);
                Session["usernamesignin"] = obj.firstname + " " + obj.lastname;

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
                Session["userid"] = dt.Rows[0]["id"].ToString();        
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

        public ActionResult Profile() {

            return View();
        }
        public ActionResult View1()

        {

            return View();
        }




        public JsonResult GetRecordById()
        {
          
            DataTable dt = new DataTable();
            List<PersonCLS> lstObj = new List<PersonCLS>();
            if (Session["userid"] != null)
            {
                using (PersonCLS obj = new PersonCLS())
                {
                   
                    dt = obj.selectlist(Convert.ToInt32(Session["userid"].ToString()));
                   
                }
                foreach (DataRow dr in dt.Rows)
                    {
                        using (PersonCLS obj2 = new PersonCLS())
                        {

                            obj2.id = Convert.ToInt64(dr["id"].ToString());
                            obj2.username = dr["UserName"].ToString();
                            obj2.passwordhash = dr["PasswordHash"].ToString();
                            obj2.sessiontoken = dr["SessionToken"].ToString();
                            obj2.firstname = dr["FirstName"].ToString();
                            obj2.middlename = dr["MiddleName"].ToString();
                            obj2.lastname = dr["LastName"].ToString();
                            obj2.dateofbirth = Convert.ToDateTime(dr["DateOfBirth"].ToString());
                            obj2.gender = Convert.ToInt16(dr["Gender"].ToString());
                            obj2.email = dr["Email"].ToString();
                            obj2.phone1 = Convert.ToInt16(dr["Phone1"].ToString());
                            obj2.phone2 = Convert.ToInt16(dr["Phone2"].ToString());
                            obj2.phone3 = Convert.ToInt16(dr["Phone3"].ToString());
                            obj2.address = dr["Address"].ToString();
                            obj2.zipcode =Convert.ToInt16(dr["ZipCode"].ToString());
                            obj2.state= dr["State"].ToString();
                            obj2.city = dr["City"].ToString();
                            obj2.procedure = dr["Procedure"].ToString();
                            obj2.proceduredate = Convert.ToDateTime(dr["ProcedureDate"].ToString());
                            obj2.insurancecompanyname = dr["InsuranceCompanyName"].ToString();
                            obj2.insuranceeffectivedate =  Convert.ToDateTime(dr["InsuranceEffectiveDate"].ToString());
                            obj2.guarantor = dr["Guarantor"].ToString();
                            obj2.groupnumber = dr["GroupNumber"].ToString();
                            obj2.policynumber= dr["PolicyNumber"].ToString();
                            obj2.preferredpharmacy = dr["PreferredPharmacy"].ToString();
                            obj2.pharmacyphone = dr["PharmacyPhone"].ToString();
                            obj2.pharmacyaddress1 = dr["PharmacyAddress1"].ToString();
                            obj2.pharmacyaddress2 = dr["PharmacyAddress2"].ToString();
                            obj2.pharmacycity = dr["PharmacyCity"].ToString();
                            obj2.pharmacystate = dr["PharmacyState"].ToString();
                            obj2.pharmacyaddress1 = dr["PharmacyAddress1"].ToString();
                            obj2.pharmacyaddress2 =dr["PharmacyAddress2"].ToString();
                            lstObj.Add(obj2);
                        }
                    }
                  
                
            }

         return Json(lstObj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateJson(PersonCLS obj)
        {
            try
            {
                obj.update(obj);
                //Session["usernamesignup"] = obj.firstname + " " + obj.lastname;

                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
