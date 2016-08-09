using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PatientMaster.Models;

namespace PatientMaster.Controllers
{
    public class XpanelArticleSubtitleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ArticleTitleSubtitleList()



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



        public ActionResult Insert(ArticleSubTitleCLS obj)
        {
            using (ArticleSubTitleCLS obj1 = new ArticleSubTitleCLS())
            {



                obj1.insert(obj);

            }

            return Json(string.Format("Success, {0} ", obj.titleid));
        }

        [HttpPost]
        public ActionResult Update(ArticleSubTitleCLS obj)
        {
            using (ArticleSubTitleCLS obj1 = new ArticleSubTitleCLS())
            {
                obj1.update(obj);

            }

            return Json(string.Format("Success, {0} ", obj.titleid));
        }



        [HttpPost]
        public ActionResult DeleteArticleSubtitle(int id)
        {
            using (ArticleSubTitleCLS obj = new ArticleSubTitleCLS())
            {
                obj.delete(id);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }





        public ActionResult ArticleSubtitleData()
        {
            List<ArticleSubTitleCLS> viewmodellist = new List<ArticleSubTitleCLS>();
            DataTable dt = new DataTable();
            using (ArticleSubTitleCLS obj = new ArticleSubTitleCLS())
            {
                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (ArticleSubTitleCLS obj2 = new ArticleSubTitleCLS())
                {

                    obj2.subtitleid = Convert.ToInt64(dr["subtitleid"].ToString());
                    obj2.titleid = Convert.ToInt32(dr["titleid"].ToString());
                    obj2.subtitle = dr["subtitle"].ToString();

                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);



        }



        public JsonResult GetAll()
        {


            List<ArticleSubTitleCLS> viewmodellist = new List<ArticleSubTitleCLS>();
            DataTable dt = new DataTable();
            using (ArticleSubTitleCLS obj = new ArticleSubTitleCLS())
            {


                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (ArticleSubTitleCLS obj2 = new ArticleSubTitleCLS())
                {
                    obj2.subtitleid = Convert.ToInt64(dr["subtitleid"].ToString());
                    obj2.titleid = Convert.ToInt32(dr["titleid"].ToString());
                    obj2.subtitle = dr["subtitle"].ToString();

                    viewmodellist.Add(obj2);


                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);
        }




    }
}
