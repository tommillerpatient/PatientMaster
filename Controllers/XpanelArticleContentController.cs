using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PatientMaster.Models;
namespace PatientMaster.Controllers
{
    public class XpanelArticleContentController : Controller

    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult TitleSubtitleList()

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



        public ActionResult Insert(ArticleContentCLS obj)
        {
            using (ArticleContentCLS obj1 = new ArticleContentCLS())
            {



                obj1.insert(obj);

            }

            return Json(string.Format("Success, {0} ", obj.titleid));
        }

        [HttpPost]
        public ActionResult Update(ArticleContentCLS obj)
        {
            using (ArticleContentCLS obj1 = new ArticleContentCLS())
            {
                obj1.update(obj);

            }

            return Json(string.Format("Success, {0} ", obj.titleid));
        }









        public ActionResult ArticleContentData()

        {
            List<ArticleContentCLS> viewmodellist = new List<ArticleContentCLS>();
            DataTable dt = new DataTable();
            using (ArticleContentCLS obj = new ArticleContentCLS())
            {
                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (ArticleContentCLS obj2 = new ArticleContentCLS())
                {

                    obj2.subtitleid = Convert.ToInt32(dr["subtitleid"].ToString());
                    obj2.titleid = Convert.ToInt32(dr["titleid"].ToString());
                    obj2.content = dr["content"].ToString();
                    obj2.contentname = dr["contentname"].ToString();
                    viewmodellist.Add(obj2);
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);



        }



        public JsonResult GetAll()
        {


            List<ArticleContentCLS> viewmodellist = new List<ArticleContentCLS>();
            DataTable dt = new DataTable();
            using (ArticleContentCLS obj = new ArticleContentCLS())
            {


                dt = obj.getAll();

            }
            foreach (DataRow dr in dt.Rows)
            {
                using (ArticleContentCLS obj2 = new ArticleContentCLS())
                {

                    obj2.subtitleid = Convert.ToInt32(dr["subtitleid"].ToString());
                    obj2.titleid = Convert.ToInt32(dr["titleid"].ToString());
                    obj2.content = dr["content"].ToString();
                    obj2.contentname = dr["contentname"].ToString();
                    viewmodellist.Add(obj2);


                 
                }
            }


            return Json(viewmodellist, JsonRequestBehavior.AllowGet);
        }




        public ActionResult DeleteArticleContent(int id)

        {
            using (ArticleContentCLS obj = new ArticleContentCLS())
            {

               
                    obj.delete(id);

              

            }

            return Json("Success", JsonRequestBehavior.AllowGet);

        }
    }
}
