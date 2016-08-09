using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DB_con;

namespace PatientMaster.Models

{
    public class ArticleTitleCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _titleid = 0;

        private string _title = string.Empty;



        #endregion

        #region "properties"
        public Int64 titleid
        {

            get { return _titleid; }

            set { _titleid = value; }

        }

        public string title
        {

            get { return _title; }

            set { _title = value; }

        }


        #endregion

        #region "constructors"

        //Default Constructor
        public ArticleTitleCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public ArticleTitleCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _titleid = Convert.ToInt64(dt.Rows[0]["titleid"]);
                    _title = Convert.ToString(dt.Rows[0]["title"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public long insert(ArticleTitleCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_ArticleTitle_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.titleid = Convert.ToInt64(obj_con.getValue("@titleid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleTitle_insert");
            }
        }

        //update data into database 
        public long update(ArticleTitleCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_ArticleTitle_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.titleid = Convert.ToInt64(obj_con.getValue("@titleid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleTitle_update");
            }
        }

        //delete data from database 
        public void delete(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@titleid", id);
                obj_con.ExecuteNoneQuery("AI_sp_ArticleTitle_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleTitle_delete");
            }
        }

        //select all data from database 
        public DataTable getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleTitle_selectall", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleTitle_selectall");
            }
        }

        //select data from database as list
        public List<ArticleTitleCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@titleid", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleTitle_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleTitle_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@titleid", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleTitle_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleTitle_select");
            }
        }

        //create parameter 
        public void createParameter(ArticleTitleCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.addParameter("@title", obj.title);
                obj_con.addParameter("@titleid", obj.titleid, trans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //disposble method
        void IDisposable.Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        //Convert IDataReader To DataTable method
        public DataTable ConvertDatareadertoDataTable(IDataReader dr)
        {
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        //Convert DataTable To List method
        public List<ArticleTitleCLS> ConvertToList(DataTable dt)
        {
            List<ArticleTitleCLS> ArticleTitlelist = new List<ArticleTitleCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (ArticleTitleCLS obj_ArticleTitle = new ArticleTitleCLS())
                {
                    obj_ArticleTitle.titleid = Convert.ToInt64(dt.Rows[i]["titleid"]);
                    obj_ArticleTitle.title = Convert.ToString(dt.Rows[i]["title"]);
                    ArticleTitlelist.Add(obj_ArticleTitle);
                }
            }
            return ArticleTitlelist;
        }


        #endregion
    }
}
