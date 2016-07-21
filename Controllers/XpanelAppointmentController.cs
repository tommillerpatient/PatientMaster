using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PatientMaster.Models;

namespace PatientMaster.Controllers
{
    public class XpanelAppointmentController : Controller
    {
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
        public ActionResult appointment()
        {
            return View();
        }


   

        [HttpPost]
        public ActionResult Insert(AppointmentCLS obj)
        {
            using (AppointmentCLS obj1 = new AppointmentCLS())
            {
             
                obj1.insert(obj);

            }

            return Json(string.Format("Success, {0} ", obj.appointmentid));
        }

        [HttpPost]
        public ActionResult Update(AppointmentCLS obj)
        {
            using (AppointmentCLS obj1 = new AppointmentCLS())
            {
                obj1.update(obj);

            }

            return Json(string.Format("Success, {0} ", obj.appointmentid));
        }



        [HttpPost]
        public ActionResult Deleteappointment(int id)
        {
            using (AppointmentCLS obj = new AppointmentCLS())
            {
                obj.delete(id);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }


    


        public ActionResult appointmentData()
        {
            List<AppointmentCLS> viewmodellist = new List<AppointmentCLS>();
            DataTable dt = new DataTable();
            using (AppointmentCLS obj = new AppointmentCLS())
            {
                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (AppointmentCLS obj2 = new AppointmentCLS())
                {

                    obj2.appointmentid = Convert.ToInt64(dr["appointmentid"].ToString());
                    obj2.appointmentname = dr["appointmentname"].ToString();
                    obj2.appointmentdesc = dr["appointmentdesc"].ToString();
                    obj2.patientid = Convert.ToInt32(dr["patientid"].ToString());
                    obj2.attendid = Convert.ToInt32(dr["attendid"].ToString());
                    obj2.active = Convert.ToBoolean(dr["active"].ToString());
                    obj2.staffid = Convert.ToInt32(dr["attendid"].ToString());
                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);



        }



        public JsonResult GetAll()
        {


            List<AppointmentCLS> viewmodellist = new List<AppointmentCLS>();
            DataTable dt = new DataTable();
            using (AppointmentCLS obj = new AppointmentCLS())
            {


                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (AppointmentCLS obj2 = new AppointmentCLS())
                {
                    obj2.appointmentid = Convert.ToInt64(dr["appointmentid"].ToString());
                    obj2.appointmentname = dr["appointmentname"].ToString();
                    obj2.appointmentdesc = dr["appointmentdesc"].ToString();
                    obj2.patientid = Convert.ToInt32(dr["patientid"].ToString());
                    obj2.attendid = Convert.ToInt32(dr["attendid"].ToString());
                    obj2.active = Convert.ToBoolean(dr["active"].ToString());
                    obj2.staffid = Convert.ToInt32(dr["attendid"].ToString());
                    viewmodellist.Add(obj2);
                

                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Delete(int id)
        {
            using (AppointmentCLS obj = new AppointmentCLS())
            {

                try
                {
                    obj.delete(id);

                }
                catch (Exception ex)
                {
                    return Json("Exception: " + ex.Message, JsonRequestBehavior.AllowGet);
                }

            }

            return Json("Success", JsonRequestBehavior.AllowGet);

        }

      

      
    }
}
