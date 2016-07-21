using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PatientMaster.Models;
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
        public ActionResult Staff()

        {
            return View();
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

                    obj2.firstname = dr["firstname"].ToString() +" "+ dr["lastname"].ToString();

              

                    obj2.email = dr["email"].ToString();

                    obj2.phone1=Convert.ToInt32(dr["phone1"].ToString());

                    obj2.active=Convert.ToBoolean(dr["active"].ToString());

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

            }

            return Json("Success", JsonRequestBehavior.AllowGet);


        }



    }
}
