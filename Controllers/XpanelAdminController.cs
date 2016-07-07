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

                    obj2.lastname = dr["lastname"].ToString();

                    obj2.email = dr["email"].ToString();

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

    }
}
