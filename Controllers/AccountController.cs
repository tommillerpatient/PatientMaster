using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PatientMaster.Models;
using System.Data;
using System.Net.Mail;
using System.Web.Configuration;
using System.Drawing;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
namespace PatientMaster.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult UserProfile1()

        {
            return View();
        }
        public ActionResult MyPatientProfile()

        {
            return View();
        }


        public ActionResult GetMyPatient()
        {

             DataTable dt = new DataTable();
            List<PersonCLS> lstObj = new List<PersonCLS>();

            if (Session["userid"] != null)
            {
                using (PersonCLS obj = new PersonCLS())
                {
                    dt = obj.getmypatient(Convert.ToInt32(Session["IsCareGiver"].ToString()));

                }

                foreach (DataRow dr in dt.Rows)
                {
                    using (PersonCLS obj2 = new PersonCLS())
                    {

                        obj2.id = Convert.ToInt64(dr["id"].ToString());
                        obj2.firstname = dr["FirstName"].ToString();
                        obj2.lastname = dr["LastName"].ToString();
                        obj2.email = dr["Email"].ToString();
                          obj2.phone1=Convert.ToInt32(dr["phone1"].ToString());
                        obj2.mobile=dr["mobile"].ToString();
                        //obj2.contactmethod=dr["mobile"].ToString();
                          //obj2.alerts=dr["alerts"].ToString();
                        if (dr["Profileimage"].ToString() != "")
                        {
                            obj2.profileimage = "/UploadImages/" + dr["Profileimage"].ToString();

                        }
                        else
                        {
                            obj2.profileimage = "/Content/images/user_profile.jpg";
                        }
                        lstObj.Add(obj2);
                    }
                }


            }

            return Json(lstObj, JsonRequestBehavior.AllowGet);
        }


        

        public ActionResult SignIn()
        {
            if (Session["usernamesignin"] == null && Session["usernamesignup"] == null)
            {
                Session.Remove("Activateuser");
                if (!string.IsNullOrEmpty(Convert.ToString(Request["confirm"])))
                {
                    Session["Activateuser"] = Convert.ToString(Request["confirm"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Request["msg"])))
                {
                    ViewBag.Message = "Please check your email and verify your email address to activate your account.";
                }
                return View();
            }
            else
            {
                return RedirectToAction("WelcomeBack", "Account");

            }
        }

        public ActionResult Settings()
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

        public ActionResult ForgotPassword()
        {
            return View();


        }

        public ActionResult ResetPassword()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Request["confirm"])))
            {

                Session["ResetPSd"] = Convert.ToString(Request["confirm"]);
            }

            return View();


        }

        public ActionResult ResetUpdatePassword(PersonCLS obj)
        {
            Int64 j = 0;
            using (PersonCLS obj1 = new PersonCLS())
            {
                string guid = "";
                guid = Convert.ToString(Session["ResetPSd"]);
                Session.Remove("ResetPSd");
                obj.id = Convert.ToInt64(Session["userid"]);
                DataTable dt = new DataTable();
                dt = obj.UpdateResetPassword(obj, guid);


                if (dt.Rows[0]["Column1"].ToString() == "0")
                {
                    Session["InvalidURl"] = "Seems you have invalid link. Please check your link again.";
                    return Json("", JsonRequestBehavior.AllowGet);

                }
                else
                {
                    Session["ResetPassMeseg"] = "Your password reset successfully.";
                    return Json(string.Format("Success, {0} ", j));

                }

            }

        }

        public ActionResult GetPassword(PersonCLS obj)
        {


            sendForgotPassword(obj);
            if (Session["PasswordSend"] != null)
            {

                return Json(string.Format("Success, {0} ", obj.id));
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);

            }



        }

        public void sendForgotPassword(PersonCLS obj)
        {
            string mailBody = "";

            DataTable dt = new DataTable();
            dt = obj.getpassword(obj);

            string myGuid = System.Guid.NewGuid().ToString().ToString();

            if (dt.Rows.Count > 0)
            {
                using (ConfirmedEmailCtl dbMail = new ConfirmedEmailCtl())
                {
                    ConfirmedEmailClass objEmail = new ConfirmedEmailClass();
                    objEmail.Personid = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    objEmail.Guid = myGuid;
                    objEmail.Requestdate = System.DateTime.Now;
                    objEmail.Isused = false;
                    objEmail.Confirmemailid = dbMail.insert(objEmail);
                }

                obj.firstname = dt.Rows[0]["lastname"].ToString();
                obj.lastname = dt.Rows[0]["firstname"].ToString();
                obj.passwordhash = dt.Rows[0]["passwordhash"].ToString();

            }
            else
            {
                Session["NotRegister"] = "";
                return;
            }

            mailBody = "Hello " + obj.lastname + " " + obj.firstname + ",";
            mailBody += "<br /><br />You have lost your password, you can reset it now. Please click on below link to reset your password";
            //Your  Password  is "+obj.passwordhash;

            string myLink = "";

            try
            {
                myLink = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("GetPassword/")) + "ResetPassword?confirm=" + myGuid;
            }
            catch (Exception ex)
            {
                myLink = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("getpassword/")) + "ResetPassword?confirm=" + myGuid;
            }

            mailBody += "<br /><a href = '" + myLink + "'>Click here to reset your account.</a>";

            MailMessage MyMailMessage = new MailMessage();
            MyMailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["From"].ToString());
            MyMailMessage.To.Add(Convert.ToString(obj.email));
            MyMailMessage.Subject = "Reset  Password";
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
                //smtp.Send(mailmsg);
                SMTPServer.Send(MyMailMessage);
                Session["PasswordSend"] = "Reset password instruction has been sent to your email address";
            }
            catch (Exception ex)
            {
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
                if (!string.IsNullOrEmpty(Convert.ToString(Session["Activateuser"])))
                {
                    ViewBag.Activated = Convert.ToString(Session["Activateuser"]);
                    Session.Remove("Activateuser");
                }
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
                if (checkemail == 0)
                {
                    obj.ConfirmedByEmail = false;
                    i = obj.insert(obj);
                    string myGuid = RandomDigits(5).ToString();
                    sendConfirmMail(obj, myGuid);
                    using (ConfirmedEmailCtl dbMail = new ConfirmedEmailCtl())
                    {
                        ConfirmedEmailClass objEmail = new ConfirmedEmailClass();
                        objEmail.Personid = Convert.ToInt32(i);
                        objEmail.Guid = myGuid.Substring(0, 5);
                        objEmail.Requestdate = System.DateTime.Now;
                        objEmail.Isused = false;
                        objEmail.Confirmemailid = dbMail.insert(objEmail);
                    }
                    return Json(string.Format("Success, {0} ", obj.id));
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            {
                s = String.Concat(s, random.Next(10).ToString());
            }
            return s;
        }

        public void sendConfirmMail(PersonCLS obj, string myguid)
        {
            string mailBody = "";

            mailBody = "Hello " + obj.lastname + " " + obj.firstname + ",";
            mailBody += "<br /><br />Please use following code to activate your account";
            string myLink = myguid.Substring(0, 5);
            //try
            //{
            //    myLink = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.ToLower().IndexOf("signupjson/")) + "SignIn?confirm=" + myguid;
            //}
            //catch (Exception ex)
            //{
            //    myLink = "";
            //}
            mailBody += "<br />Code: " + myLink;
            mailBody += "<br /><br />Thanks";




            MailMessage MyMailMessage = new MailMessage();
            MyMailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["From"].ToString());
            MyMailMessage.To.Add(Convert.ToString(obj.email));
            MyMailMessage.Subject = "Account Activation";
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

        public JsonResult Update(PersonCLS obj)
        {
            try
            {
                if (obj.profileimage.Contains("data:image"))
                {
                    obj.profileimage = obj.profileimage.Replace("data:image/png;base64,", "");
                    obj.profileimage = obj.profileimage.Replace("data:image/jpeg;base64,", "");
                    obj.profileimage = obj.profileimage.Replace("data:image/jpg;base64,", "");
                    obj.profileimage = obj.profileimage.Replace("data:image/gif;base64,", "");
                    byte[] imageBytes = Convert.FromBase64String(obj.profileimage);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    string path = System.Configuration.ConfigurationManager.AppSettings["UploadImages"].ToString();
                    string filename = DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "") + ".jpg";
                    image.Save(path + filename);
                    obj.profileimage = filename;

                }
                else
                {

                    obj.profileimage = obj.profileimage;
                }

                if (obj.profileimage.Contains("UploadImages"))
                {

                    obj.profileimage = obj.profileimage.Replace("/UploadImages/", "");

                }
                if (obj.profileimage.Contains("/Content/images/"))
                {

                    obj.profileimage = obj.profileimage.Replace("/Content/images/", "");

                }
                obj.update(obj);
                Session["usernamesignin"] = obj.firstname + " " + obj.lastname;
                Session["UpdateUSer"] = "Update";
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

            public ActionResult GetUserProgress()
            {
                List<UserProgressCLS> viewmodellist = new List<UserProgressCLS>();
                DataTable dt = new DataTable();
                using (UserProgressCLS obj = new UserProgressCLS())
                {

                    if (Session["userid"]!=null)
                    {
                         dt = obj.getAllbyuser(Convert.ToInt32(Session["userid"].ToString()));
                    }
                   

                }
                foreach (DataRow dr in dt.Rows)
                {
                    using (UserProgressCLS obj2 = new UserProgressCLS())
                    {

                        obj2.contentid = Convert.ToInt32(dr["contentid"].ToString());

                        obj2.progressid = Convert.ToInt32(dr["progressid"].ToString());
                        obj2.contentname = dr["contentname"].ToString();
                        viewmodellist.Add(obj2);
                    }
                }
                return Json(viewmodellist, JsonRequestBehavior.AllowGet); ;
            }


            public JsonResult UpdateUserProgress(int id)
            {
            try
            {
                using(UserProgressCLS obj=new UserProgressCLS())
                {
                    obj.userid = Convert.ToInt32(Session["userid"].ToString());
                    obj.contentid = id;
                    obj.insert(obj);
 

                }
                            

                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult CheckUserPass(PersonCLS obj)
        {
            DataTable dt = new DataTable();
            List<PersonCLS> viewModelList = new List<PersonCLS>();
            string guid = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["Activateuser"])))
                guid = Convert.ToString(Session["Activateuser"]);

            dt = obj.CheckUserNamePass(obj);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToString(dt.Rows[0]["ConfirmedByEmail"]).Trim() == "False")
                {
                    return Json(string.Format("Not Active, {0} ", dt.Rows[0]["id"].ToString()));
                }

                Session["usernamesignin"] = dt.Rows[0]["firstname"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
                Session["userid"] = dt.Rows[0]["id"].ToString();
                Session["roleid"] = dt.Rows[0]["roleid"].ToString();
              
             
                Session["IsActivePerson"] = dt.Rows[0]["active"].ToString();
                if (Convert.ToString(dt.Rows[0]["CareGiver"]) == "0" || string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CareGiver"])))
                {
                    Session["IsCareGiver"] = 0;
                }
                else
                    Session["IsCareGiver"] = Convert.ToString(dt.Rows[0]["CareGiver"]);



                if (!Convert.ToBoolean(Convert.ToString(Session["IsActivePerson"])))
                {
                    return Json(string.Format("Success, {0} ", "false"));
                }
                if (dt.Rows[0]["roleid"].ToString()=="")
                {

                    return Json(string.Format("Success, {0} ", "0"));
                }
                else
                {
                    return Json(string.Format("Success, {0} ", dt.Rows[0]["roleid"].ToString()));

                }
               
            }
            else
                return Json(viewModelList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SignOut()
        {
            Session.RemoveAll();
            return RedirectToAction("SignIn", "Account");
        }

        public ActionResult UserProfile()
        {

            if (Session["usernamesignup"] == null && Session["usernamesignin"] == null)
                return RedirectToAction("SignUp", "Account");
            else
            {


                string g = Request.QueryString["g"];
                if (g != null)
                {

                    GoogleConnect.ClientId = "620381939960-v1hfbqkoc04m59ie57e1jvufbar2o8gi.apps.googleusercontent.com";
                    GoogleConnect.ClientSecret = "NovmdkEVwGfdym9fqs4zgrtk";
                    GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
                    GoogleConnect.Authorize("profile", "email");
                }

                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    string code = Request.QueryString["code"];
                    string json = GoogleConnect.Fetch("me", code);
                    GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);

                    string name = profile.DisplayName;
                    string url = profile.Image.Url;
                    ViewBag.url=url ;
                }
            }
                return View();

        }

        public ActionResult ActivateAccount()
        {
            Session["Activateuser"] = "confirm";
            return View();
        }
        [HttpPost]
        public ActionResult ActiveUser(PersonCLS obj)
        {
            try
            {
                using (PersonCLS db = new PersonCLS())
                {
                    //obj.id = Convert.ToInt32(Convert.ToString(Session["Activateuser"]));
                    DataTable dt = db.ActiveAccount(obj);
                    if (dt.Rows.Count > 0)
                    {
                        Session["Activateuser"] = "confirm";
                        Session["usernamesignin"] = dt.Rows[0]["firstname"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
                        Session["userid"] = dt.Rows[0]["id"].ToString();
                        if (Convert.ToString(dt.Rows[0]["CareGiver"]) == "0" || string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CareGiver"])))
                        {
                            Session["IsCareGiver"] = 0;
                        }
                        else
                            Session["IsCareGiver"] = Convert.ToString(dt.Rows[0]["CareGiver"]);
                        return Json("Success", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Invalie code, please try again.", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json("Exception: " + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult View1()
        {
            //MailMessage mailmsg = new MailMessage();
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtpout.secureserver.net";
            //mailmsg.From = new MailAddress("support@PatientMaster.com");
            //mailmsg.To.Add("jayesh.avyak@gmail.com");

            ////mailmsg.To.Add(Convert.ToString(((new GeneralSettingsCtl()).selectByKey("AdminEmailToAccessRequest")).Settingsvalue));
            //mailmsg.Subject = "Account Activation";// +obj.lastname + " " + obj.firstname + ".";
            //mailmsg.Body = "Hello";
            //mailmsg.IsBodyHtml = true;
            //smtp.Port = Convert.ToInt32("25");
            //smtp.Credentials = new System.Net.NetworkCredential("support@visitmydemo.net", "support123");
            //smtp.EnableSsl = Convert.ToBoolean(Convert.ToInt32("0"));


            MailMessage MyMailMessage = new MailMessage();
            MyMailMessage.From = new MailAddress("bgoyal@logicaldevelopers.com");
            MyMailMessage.To.Add("jayesh.avyak@gmail.com");
            MyMailMessage.Subject = "Test email";
            MyMailMessage.IsBodyHtml = true;
            MyMailMessage.Body = "hello";

            SmtpClient SMTPServer = new SmtpClient();
            SMTPServer.Host = "smtpout.secureserver.net";
            SMTPServer.EnableSsl = Convert.ToBoolean(Convert.ToInt32("0"));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
            credentials.UserName = "support@visitmydemo.net";
            credentials.Password = "support123";
            SMTPServer.UseDefaultCredentials = true;
            SMTPServer.Credentials = credentials;
            SMTPServer.Port = Convert.ToInt32("25");


            try
            {
                //smtp.Send(mailmsg);
                SMTPServer.Send(MyMailMessage);
            }
            catch (Exception ex)
            {
            }
            return View();
        }

        public ActionResult ShowMessage()
        {

            return View();
        }

        public JsonResult GetRecordById()
        {

            DataTable dt = new DataTable();
            List<PersonCLS> lstObj = new List<PersonCLS>();
            string guid = Convert.ToString(Session["CareGiverGuid"]);
            if (Session["userid"] != null || !string.IsNullOrEmpty(guid))
            {
                using (PersonCLS obj = new PersonCLS())
                {
                    if (Session["userid"] != null)
                    {
                        dt = obj.selectlist(Convert.ToInt32(Session["userid"].ToString()));
                    }
                    else
                        dt = obj.selectlistByGuid(guid);

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

        public JsonResult UpdatePassword(PersonCLS obj)
        {
            try
            {

                Int64 i = 0, j = 0;
                obj.id = Convert.ToInt64(Session["userid"]);
                i = obj.CheckOldPassword(obj);

                if (i > 0)
                {
                    obj.id = Convert.ToInt64(Session["userid"]);

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

        public ActionResult CareGiverRegister()
        {

            return View();
        }

        public JsonResult NewCareGiverJson(PersonCLS obj)
        {
            try
            {
                Int32 checkemail = 0;
                Int64 i = 0;
                checkemail = obj.CheckEmail(obj);
                if (checkemail == 0)
                {
                    obj.ConfirmedByEmail = false;
                    obj.CareGiver = Convert.ToInt32(obj.id);
                    obj.id = 0;
                    string name = obj.address;
                    obj.address = "";
                   
                    i = obj.insert(obj);
                    if(name.Contains(','))
                    {
                        obj.address = name.Replace(',',' ');
                    }
                    else
                    {
                        obj.address = name;
                    }
                   
                    string myGuid = System.Guid.NewGuid().ToString().ToString();
                    sendInvitaion(obj, myGuid);
                    using (ConfirmedEmailCtl dbMail = new ConfirmedEmailCtl())
                    {
                        ConfirmedEmailClass objEmail = new ConfirmedEmailClass();
                        objEmail.Personid = Convert.ToInt32(i);
                        objEmail.Guid = myGuid;
                        objEmail.Requestdate = System.DateTime.Now;
                        objEmail.Isused = false;
                        objEmail.Confirmemailid = dbMail.insert(objEmail);
                    }


                    return Json(string.Format("Success, {0} ", obj.id));
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

        public void sendInvitaion(PersonCLS obj, string myguid)
        {
            string mailBody = "";
           
           // mailBody += ;
            string myLink = "";
            string myLink1 = "";
            try
            {
                myLink = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.ToLower().IndexOf("newcaregiverjson/")) + "SignupCareGiver?gu=" + myguid;
                myLink1 = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.ToLower().IndexOf("newcaregiverjson/")) + "SignupCareGiver?gu=" + myguid+"&decline=dec";
            }
            catch (Exception ex)
            {
                myLink = "";
                myLink1 = "";
            }


             mailBody += "<div style=\"margin:0px; padding:0px; text-align:center;\">";
             mailBody += "<div class=\"wrapper\" style=\"width:70%; margin:0 auto; background-color:#eee; text-align:center;\">";
             mailBody += "<div>";
             mailBody += "<h2 style=\"font-family:Arial, Helvetica, sans-serif; font-size:34px; padding-top:0px;margin:0;padding-bottom:0;background-color:#111755;color:#fff;\">Bariatric</h2><br></br>";
             mailBody +="<p style=\"text-align:left;padding-left:15px;\">Hi, "+ obj.firstname +" "+obj.lastname+"</p>";
             mailBody += "<p style=\"text-align:left;padding-left:15px;color:#000;\">"+ obj.address + " has requested that you become their care giver to support them with their health care.</p>";
             mailBody +="<div  style=\"font-family:Arial, Helvetica, sans-serif; font-size:14px; padding-bottom:25px;\">";
             mailBody +="<a href="+myLink+"><button type=\"submit\" value=\"Submit\" style=\"background-color: rgb(17, 23, 85); border-radius: 7px; padding: 6px 16px; color: rgb(255, 255, 255);font-size: 12px; font-family: arial; border: 1px solid #111755;\">Accept</button></a>";
             mailBody +="<a href="+myLink1+"><button type=\"submit\" value=\"Submit\" style=\"background-color:#111755; border-radius:7px; padding:6px 16px; color:#fff; font-size:12px; font-family:arial; border:1px solid #111755;margin-left:10px;\">Decline</button></a>";
             mailBody +="</div>";
             mailBody +="</div>";
             mailBody +="</div>";
             mailBody +="</div>";


     

            MailMessage MyMailMessage = new MailMessage();
            MyMailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["From"].ToString());
            MyMailMessage.To.Add(Convert.ToString(obj.email));
            MyMailMessage.Subject = "Care giver invitation";// "Care giver invitation from " + obj.address.Split(',')[0];
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

        public ActionResult SignupCareGiver()
        {
            Session["CareGiverGuid"] = Convert.ToString(Request["gu"]);
            return View();
        }

        public JsonResult SignUpCareGiverUpdate(PersonCLS obj)
        {
            try
            {
                obj.ConfirmedByEmail = true;
                Int64 i = obj.update(obj);
                string myGuid = System.Guid.NewGuid().ToString().ToString();
                sendConfirmMailCareGiver(obj, myGuid);
                Session.Remove("CareGiverGuid");
                Session["usernamesignin"] = obj.firstname + " " + obj.lastname;
                Session["userid"] = obj.id.ToString();
                Session["IsCareGiver"] = obj.CareGiver.ToString();
                return Json(string.Format("Success, {0} ", obj.id));
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SignUpCareGiverDecline(PersonCLS obj)
        {
            try
            {

                Int64 i = obj.updateDecline(obj);
                Session.Remove("CareGiverGuid");
                Session["usernamesignin"] = obj.firstname + " " + obj.lastname;
                Session["userid"] = obj.id.ToString();
                Session["IsCareGiver"] = obj.CareGiver.ToString();
                return Json(string.Format("Success, {0} ", obj.id));
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        
        public void sendConfirmMailCareGiver(PersonCLS obj, string myguid)
        {
            string mailBody = "Welcome to Patientmaster. ";

            MailMessage MyMailMessage = new MailMessage();
            MyMailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["From"].ToString());
            MyMailMessage.To.Add(Convert.ToString(obj.email));
            MyMailMessage.Subject = "Welcome to Patientmaster ";
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

        public ActionResult CareGiverProfile()
        {
            if (Session["usernamesignup"] == null && Session["usernamesignin"] == null)
                return RedirectToAction("SignIn", "Account");
            else
                return View();
        }

        public JsonResult CareGiverProfileUpdate(PersonCLS[] obj)
        {
            try
            {
                foreach (PersonCLS myobj in obj)
                {
                    Int64 i = myobj.updateCareGiverProfile1(myobj);
                }

                //Int64 i = obj.updateCareGiverProfile(obj);
                return Json(string.Format("Success, {0} ", 1));
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult MyCareGivers()
        {
            return View();
        }
        public ActionResult ThankYou()

        {
            return View();
        }
        public JsonResult GetMyCareGivers()
        {
            DataTable dt = new DataTable();
            List<PersonCLS> lstObj = new List<PersonCLS>();
            if (Session["userid"] != null)
            {
                using (PersonCLS obj = new PersonCLS())
                {
                    dt = obj.getMyCareGivers(Convert.ToInt32(Session["userid"].ToString()));
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
                        obj2.caregivercomment = dr["caregivercomment"].ToString();
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
            }
            return Json(lstObj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCareGivers(int id)
        {
            try
            {
                using (PersonCLS db = new PersonCLS())
                {
                    db.delete(id);
                }
                return Json(string.Format("Success, {0} ", id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DialogDemo()
        {
            return View();
        }

    }

}
