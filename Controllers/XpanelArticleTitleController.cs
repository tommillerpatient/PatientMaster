using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PatientMaster.Models;


namespace PatientMaster.Controllers
{
    public class XpanelArticleTitleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ArticleList()

        {

            List<ArticleTitleCLS> viewmodellist = new List<ArticleTitleCLS>();
            DataTable dt = new DataTable();
            using (ArticleTitleCLS obj = new ArticleTitleCLS())
            {


                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (ArticleTitleCLS obj2 = new ArticleTitleCLS())
                {

                    obj2.titleid = Convert.ToInt64(dr["titleid"].ToString());

                    obj2.title = dr["title"].ToString();

                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet); ;
        }



        public ActionResult Insert(ArticleTitleCLS obj)
        {
            using (ArticleTitleCLS obj1 = new ArticleTitleCLS())
            {
               
                
             
                obj1.insert(obj);

            }

            return Json(string.Format("Success, {0} ", obj.titleid));
        }

        [HttpPost]
        public ActionResult Update(ArticleTitleCLS obj)
        {
            using (ArticleTitleCLS obj1 = new ArticleTitleCLS())
            {
                obj1.update(obj);

            }

            return Json(string.Format("Success, {0} ", obj.titleid));
        }



        [HttpPost]
        public ActionResult DeleteArticle(int id)

        {
            using (ArticleTitleCLS obj = new ArticleTitleCLS())
            {
                obj.delete(id);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }





        public ActionResult ArticleData()

        {
            List<ArticleTitleCLS> viewmodellist = new List<ArticleTitleCLS>();
            DataTable dt = new DataTable();
            using (ArticleTitleCLS obj = new ArticleTitleCLS())
            {
                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (ArticleTitleCLS obj2 = new ArticleTitleCLS())
                {

                    obj2.titleid = Convert.ToInt64(dr["titleid"].ToString());
                    obj2.title = dr["title"].ToString();
 
                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);



        }



        public JsonResult GetAll()
        {


            List<ArticleTitleCLS> viewmodellist = new List<ArticleTitleCLS>();
            DataTable dt = new DataTable();
            using (ArticleTitleCLS obj = new ArticleTitleCLS())
            {


                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (ArticleTitleCLS obj2 = new ArticleTitleCLS())
                {
                    obj2.titleid = Convert.ToInt64(dr["titleid"].ToString());
                    obj2.title = dr["title"].ToString();

                    viewmodellist.Add(obj2);


                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Delete(int id)
        {
            using (ArticleTitleCLS obj = new ArticleTitleCLS())
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
