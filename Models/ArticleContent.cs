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
    public class ArticleContentCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _contentid = 0;

        private string _content = string.Empty;
        private string _contentname = string.Empty;


        private Int32 _titleid = 0;

        private Int32 _subtitleid = 0;



        #endregion

        #region "properties"
        public Int64 contentid
        {

            get { return _contentid; }

            set { _contentid = value; }

        }

        public string content
        {

            get { return _content; }

            set { _content = value; }

        }
        public string contentname
        {

            get { return _contentname; }

            set { _contentname = value; }

        }
        public Int32 titleid
        {

            get { return _titleid; }

            set { _titleid = value; }

        }

        public Int32 subtitleid
        {

            get { return _subtitleid; }

            set { _subtitleid = value; }

        }


        #endregion

        #region "constructors"

        //Default Constructor
        public ArticleContentCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public ArticleContentCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _contentid = Convert.ToInt64(dt.Rows[0]["contentid"]);
                    _content = Convert.ToString(dt.Rows[0]["content"]);
                    _titleid = Convert.ToInt16(dt.Rows[0]["titleid"]);
                    _subtitleid = Convert.ToInt16(dt.Rows[0]["subtitleid"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public long insert(ArticleContentCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_ArticleContent_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.contentid = Convert.ToInt64(obj_con.getValue("@contentid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleContent_insert");
            }
        }

        //update data into database 
        public long update(ArticleContentCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_ArticleContent_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.contentid = Convert.ToInt64(obj_con.getValue("@contentid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleContent_update");
            }
        }

        //delete data from database 
        public void delete(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@contentid", id);
                obj_con.ExecuteNoneQuery("AI_sp_ArticleContent_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleContent_delete");
            }
        }

        //select all data from database 
        public DataTable getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleContent_selectall", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleContent_selectall");
            }
        }

        //select data from database as list
        public List<ArticleContentCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@contentid", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleContent_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleContent_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@contentid", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleContent_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleContent_select");
            }
        }

        //create parameter 
        public void createParameter(ArticleContentCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.addParameter("@content", obj.content);
                obj_con.addParameter("@contentname", obj.contentname);
                obj_con.addParameter("@titleid", obj.titleid);
                obj_con.addParameter("@subtitleid", obj.subtitleid);
                obj_con.addParameter("@contentid", obj.contentid, trans);
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
        public List<ArticleContentCLS> ConvertToList(DataTable dt)
        {
            List<ArticleContentCLS> ArticleContentlist = new List<ArticleContentCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (ArticleContentCLS obj_ArticleContent = new ArticleContentCLS())
                {
                    obj_ArticleContent.contentid = Convert.ToInt64(dt.Rows[i]["contentid"]);
                    obj_ArticleContent.content = Convert.ToString(dt.Rows[i]["content"]);
                    obj_ArticleContent.titleid = Convert.ToInt16(dt.Rows[i]["titleid"]);
                    obj_ArticleContent.subtitleid = Convert.ToInt16(dt.Rows[i]["subtitleid"]);
                    ArticleContentlist.Add(obj_ArticleContent);
                }
            }
            return ArticleContentlist;
        }


        #endregion
    }
}
