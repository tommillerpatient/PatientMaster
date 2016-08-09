using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PatientMaster.Models;
using System.Net.Mail;
using System.Web.Configuration;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI;
namespace PatientMaster.Controllers
{
    public class XpanelAdminController : Controller
    {
        //
        // GET: /XpanelAdmin/

        public ActionResult Index()
        {
            return View();
        }
   
        public ActionResult UserList()



        {
            return View();
        }


        public ActionResult ChangePassword()

        {
            return View();
        }
        public ActionResult UserProfile()

        {
            Session["patientuserid"] = Convert.ToString(Request["id"]);
            return View();
        }
        public ActionResult Staff()

        {
            return View();
        }

        public JsonResult GetRecordById()
        {

            DataTable dt = new DataTable();
            List<PersonCLS> lstObj = new List<PersonCLS>();

       
            

                using (PersonCLS obj = new PersonCLS())
                {
                    
                        dt = obj.selectlist(Convert.ToInt32(Session["patientuserid"].ToString()));
                    
                 

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
                        obj2.gender = Convert.ToInt32(dr["Gender"].ToString());
                        obj2.email = dr["Email"].ToString();
                        obj2.phone1 = Convert.ToInt32(dr["Phone1"].ToString());
                        obj2.phone2 = Convert.ToInt32(dr["Phone2"].ToString());
                        obj2.phone3 = Convert.ToInt32(dr["Phone3"].ToString());
                        obj2.address = dr["Address"].ToString();
                        obj2.address1 = dr["Address1"].ToString();
                        obj2.zipcode = Convert.ToInt32(dr["ZipCode"].ToString());
                        obj2.state = dr["State"].ToString();
                        obj2.city = dr["City"].ToString();
                        obj2.procedure = dr["Procedure"].ToString();
                        obj2.proceduredate = Convert.ToDateTime(dr["ProcedureDate"].ToString());
                        obj2.insurancecompanyname = dr["InsuranceCompanyName"].ToString();
                        obj2.insuranceeffectivedate = Convert.ToDateTime(dr["InsuranceEffectiveDate"].ToString());
                        obj2.guarantor = dr["Guarantor"].ToString();
                        obj2.groupnumber = dr["GroupNumber"].ToString();
                        obj2.policynumber = dr["PolicyNumber"].ToString();
                        obj2.preferredpharmacy = dr["PreferredPharmacy"].ToString();
                        obj2.pharmacyphone = dr["PharmacyPhone"].ToString();
                        obj2.pharmacyaddress1 = dr["PharmacyAddress1"].ToString();
                        obj2.pharmacyaddress2 = dr["PharmacyAddress2"].ToString();
                        obj2.pharmacycity = dr["PharmacyCity"].ToString();
                        obj2.pharmacystate = dr["PharmacyState"].ToString();
                        obj2.pharmacyaddress1 = dr["PharmacyAddress1"].ToString();
                        obj2.pharmacyaddress2 = dr["PharmacyAddress2"].ToString();
                        obj2.country = dr["country"].ToString();
                        if (dr["Profileimage"].ToString() != "")
                        {
                            obj2.profileimage = "/UploadImages/" + dr["Profileimage"].ToString();

                        }
                        else
                        {
                            obj2.profileimage = "/Content/images/user_profile.jpg";
                        }

                        obj2.maritalstatus = dr["maritalstatus"].ToString();

                        obj2.weight = dr["weight"].ToString();
                        obj2.mobile = dr["mobile"].ToString();
                        obj2.preferredcommunication = dr["preferredcommunication"].ToString();
                        obj2.socialnetworks = dr["socialnetworks"].ToString();
                        obj2.language = dr["language"].ToString();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["CareGiver"])))
                            obj2.CareGiver = Convert.ToInt32(dr["CareGiver"].ToString());
                        else
                            obj2.CareGiver = 0;
                        try
                        {
                            obj2.HasCareGiver = Convert.ToInt32(dr["HasCareGiver"].ToString());
                        }
                        catch (Exception ex)
                        {
                        }
                        lstObj.Add(obj2);
                    }
                }


            

            return Json(lstObj, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetMyCareGivers()
        {
            DataTable dt = new DataTable();
            List<PersonCLS> lstObj = new List<PersonCLS>();
           
                using (PersonCLS obj = new PersonCLS())
                {
                    dt = obj.getMyCareGivers(Convert.ToInt32(Session["patientuserid"].ToString()));
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
                        obj2.gender = Convert.ToInt32(dr["Gender"].ToString());
                        obj2.genderVal = Convert.ToString(dr["Gender"].ToString());
                        obj2.email = dr["Email"].ToString();
                        obj2.phone1 = Convert.ToInt32(dr["Phone1"].ToString());
                        obj2.phone2 = Convert.ToInt32(dr["Phone2"].ToString());
                        obj2.phone3 = Convert.ToInt32(dr["Phone3"].ToString());
                        obj2.address = dr["Address"].ToString();
                        obj2.address1 = dr["Address1"].ToString();
                        obj2.zipcode = Convert.ToInt32(dr["ZipCode"].ToString());
                        obj2.state = dr["State"].ToString();
                        obj2.city = dr["City"].ToString();
                        obj2.procedure = dr["Procedure"].ToString();
                        obj2.proceduredate = Convert.ToDateTime(dr["ProcedureDate"].ToString());
                        obj2.insurancecompanyname = dr["InsuranceCompanyName"].ToString();
                        obj2.insuranceeffectivedate = Convert.ToDateTime(dr["InsuranceEffectiveDate"].ToString());
                        obj2.guarantor = dr["Guarantor"].ToString();
                        obj2.groupnumber = dr["GroupNumber"].ToString();
                        obj2.policynumber = dr["PolicyNumber"].ToString();
                        obj2.preferredpharmacy = dr["PreferredPharmacy"].ToString();
                        obj2.pharmacyphone = dr["PharmacyPhone"].ToString();
                        obj2.pharmacyaddress1 = dr["PharmacyAddress1"].ToString();
                        obj2.pharmacyaddress2 = dr["PharmacyAddress2"].ToString();
                        obj2.pharmacycity = dr["PharmacyCity"].ToString();
                        obj2.pharmacystate = dr["PharmacyState"].ToString();
                        obj2.pharmacyaddress1 = dr["PharmacyAddress1"].ToString();
                        obj2.pharmacyaddress2 = dr["PharmacyAddress2"].ToString();
                        obj2.ConfirmedByEmail = Convert.ToBoolean(Convert.ToString(dr["ConfirmedByEmail"]));
                        obj2.relationship = Convert.ToString(dr["relationship"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["CareGiver"])))
                            obj2.CareGiver = Convert.ToInt32(dr["CareGiver"].ToString());
                        else
                            obj2.CareGiver = 0;
                        try
                        {
                            obj2.HasCareGiver = Convert.ToInt32(dr["HasCareGiver"].ToString());
                        }
                        catch (Exception ex)
                        {
                        }
                        lstObj.Add(obj2);
                    }
                }
            
            return Json(lstObj, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CareGiverProfileUpdate(PersonCLS[] obj)
        {
            try
            {
                foreach (PersonCLS myobj in obj)
                {
                    Int64 i = myobj.updateCareGiverProfile1(myobj);
                }


                return Json(string.Format("Success, {0} ", 1));
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CheckUserPass(StaffCLS obj)
        {
            DataTable dt = new DataTable();
            List<StaffCLS> viewModelList = new List<StaffCLS>();
       

            dt = obj.CheckUserNamePass(obj);
            if (dt != null && dt.Rows.Count > 0)
            {

                Session["usernameadmin"] = dt.Rows[0]["firstname"].ToString();
                Session["adminid"] = dt.Rows[0]["id"].ToString();
                Session["roles"]=dt.Rows[0]["roleid"].ToString();
               
                return Json(string.Format("Success, {0} ", dt.Rows[0]["id"].ToString()));
            }
            else
                return Json(viewModelList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Login()
        {
            Session.RemoveAll();
            return View();



        }

        [HttpPost]
        public ActionResult UpdatePerson(PersonCLS obj)
        {
            using (PersonCLS obj1 = new PersonCLS())
            {

                obj1.updatePerson(obj);

            }
            return Json(string.Format("Success, {0} ", obj.id));
        }

        [HttpPost]
        public ActionResult Insert(StaffCLS obj)
        {
            using(StaffCLS obj1=new StaffCLS())
            {
                obj.roleid = 2;
                obj1.insert(obj);

            }

            return Json(string.Format("Success, {0} ", obj.id));
        }

        [HttpPost]
        public ActionResult Update(StaffCLS obj)

        {
            using (StaffCLS obj1 = new StaffCLS())
            {
                obj1.update(obj);

            }

            return Json(string.Format("Success, {0} ", obj.id));
        }



        [HttpPost]
        public ActionResult DeleteStaff(int id)
        {
            using (StaffCLS obj = new StaffCLS())
            {
                obj.delete(id);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }


        public JsonResult UpdatePassword(StaffCLS obj)
        {
            try
            {

                Int64 i = 0, j = 0;
                obj.id = Convert.ToInt64(Session["adminid"]);
                i = obj.CheckOldPassword(obj);

                if (i > 0)
                {
                    obj.id = Convert.ToInt64(Session["adminid"]);

                    j = obj.UpdatePassword(obj);
                    if (j > 0)
                    {
                        Session["ChangePassword"] = "ChangePassword";

                    }
                    return Json("1", JsonRequestBehavior.AllowGet);
                }


                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult staffData()
        {
            List<StaffCLS> viewmodellist = new List<StaffCLS>();
            DataTable dt = new DataTable();
            using (StaffCLS obj = new StaffCLS())
            {
                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (StaffCLS obj2 = new StaffCLS())
                {

                    obj2.id = Convert.ToInt64(dr["id"].ToString());
                    obj2.firstname = dr["firstname"].ToString();
                    obj2.lastname =dr["lastname"].ToString();
                    obj2.emailid = dr["emailid"].ToString();
                    obj2.password = Convert.ToString(dr["password"].ToString());
                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);



        }



        public ActionResult View2()

        {
            return View();
        }
        public JsonResult GetAll()
        {


            List<person> viewmodellist = new List<person>();
            DataTable dt = new DataTable();
            using (PersonCLS obj = new PersonCLS())
            {


                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (person obj2 = new person())
                {

                    obj2.id = Convert.ToInt64(dr["id"].ToString());

                    obj2.firstname = dr["firstname"].ToString();

                     obj2.lastname= dr["lastname"].ToString();
                  
                    obj2.email = dr["email"].ToString();


                
                    obj2.phone1=Convert.ToInt32(dr["phone1"].ToString());

                    obj2.dateofbirth = Convert.ToDateTime(dr["dateofbirth"].ToString());
                    obj2.proceduredate = Convert.ToDateTime(dr["proceduredate"].ToString());
                    obj2.proceduredatestr = obj2.proceduredate.ToShortDateString();
                    obj2.active=Convert.ToBoolean(dr["active"].ToString());

                    obj2.gender = Convert.ToInt32(dr["gender"].ToString());

                    obj2.address = dr["address"].ToString();

                    obj2.address1 = dr["address1"].ToString();

                    obj2.city = dr["city"].ToString();
                    obj2.state = dr["state"].ToString();
                    obj2.zipcode = Convert.ToInt32(dr["zipcode"].ToString());
                    viewmodellist.Add(obj2);
                }
            }


           return  Json(viewmodellist,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllwithProgress()

        {


            List<person> viewmodellist = new List<person>();
            DataTable dt = new DataTable();
            using (PersonCLS obj = new PersonCLS())
            {


                dt = obj.getAllwithprogress();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (person obj2 = new person())
                {

                    obj2.id = Convert.ToInt64(dr["id"].ToString());

                    obj2.firstname = dr["firstname"].ToString();

                     obj2.lastname= dr["lastname"].ToString();
                  
                    obj2.email = dr["email"].ToString();

                    obj2.contentid = dr["List_Output"].ToString();
                    string[] splitdata = obj2.contentid.Split(',');

                    string length = splitdata.Length.ToString();
                   if(length!="")
                   {

                       obj2.percentage = ((8 * Convert.ToDecimal(length)) / 100)*100;
                   }
                   

                    obj2.phone1=Convert.ToInt32(dr["phone1"].ToString());

                    obj2.dateofbirth = Convert.ToDateTime(dr["dateofbirth"].ToString());
                    obj2.proceduredate = Convert.ToDateTime(dr["proceduredate"].ToString());
                    obj2.proceduredatestr = obj2.proceduredate.ToShortDateString();
                    obj2.active=Convert.ToBoolean(dr["active"].ToString());

                    obj2.gender = Convert.ToInt32(dr["gender"].ToString());

                    obj2.address = dr["address"].ToString();

                    obj2.address1 = dr["address1"].ToString();

                    obj2.city = dr["city"].ToString();
                    obj2.state = dr["state"].ToString();
                    obj2.zipcode = Convert.ToInt32(dr["zipcode"].ToString());
                    viewmodellist.Add(obj2);
                }
            }


           return  Json(viewmodellist,JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Delete(int id)
        {
            using(PersonCLS obj=new PersonCLS())
            {

                try
                {
                    obj.delete(id);

                }
                catch (Exception ex)
                {
                    return Json("Exception: "+ex.Message, JsonRequestBehavior.AllowGet);
                }

            }

         return  Json("Success",JsonRequestBehavior.AllowGet);

        }



        public ActionResult ExporttoPDF()
        {
        
            return View();
        }
            
        

        public ActionResult ChangeStatus(int id,bool status)
        {

            using (PersonCLS obj = new PersonCLS())
            {

                if (status == true)
                {
                    status = false;
                }
                else
                {
                    status = true;

                }
             
                 
                obj.changestatus(id,status);

                if(status==true)
                {
                    sendaprooval(id);

                }

            }

            return Json("Success", JsonRequestBehavior.AllowGet);


        }

        public void sendaprooval(int id)
        {
            DataTable dt = new DataTable();
            using(PersonCLS obj=new PersonCLS())
            {
              
                dt = obj.selectlist(id);
            }
            string name = "",email="";

            if(dt.Rows.Count>0)
            {
                name = dt.Rows[0]["firstname"].ToString() + "  "+dt.Rows[0]["lastname"].ToString();
                email = dt.Rows[0]["email"].ToString();
            }
            string mailBody = "";

            mailBody += "Hello, " + "<br /><br />" + name + "<br /><br />" + " your account activate requested has been approved by admin.";
            string myLink = "";
          
            try
            {
                myLink = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.ToLower().IndexOf("xpaneladmin/changestatus")) + "Account/SignIn";
              
            }
            catch (Exception ex)
            {
                myLink = "";
               
            }
            mailBody += "<br /><a href = '" + myLink + "'>Click here to login your account.</a>";
            mailBody += "<br /><br />Thank You!";

            MailMessage MyMailMessage = new MailMessage();
            MyMailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["From"].ToString());
            MyMailMessage.To.Add(Convert.ToString(email));
            MyMailMessage.Subject = "Request Approuval";// "Care giver invitation from " + obj.address.Split(',')[0];
            MyMailMessage.IsBodyHtml = true;
            MyMailMessage.Body = mailBody;

            SmtpClient SMTPServer = new SmtpClient();
            SMTPServer.Host = WebConfigurationManager.AppSettings["Host"].ToString();
            SMTPServer.EnableSsl = Convert.ToBoolean(Convert.ToInt32(WebConfigurationManager.AppSettings["ssl"].ToString()));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
            credentials.UserName = WebConfigurationManager.AppSettings["UserName"].ToString();
            credentials.Password = WebConfigurationManager.AppSettings["Password"].ToString();
            SMTPServer.UseDefaultCredentials = true;
            SMTPServer.Credentials = credentials;
            SMTPServer.Port = Convert.ToInt32(WebConfigurationManager.AppSettings["port"].ToString());
            try
            {

                SMTPServer.Send(MyMailMessage);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
