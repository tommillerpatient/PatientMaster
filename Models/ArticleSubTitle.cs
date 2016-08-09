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
    public class ArticleSubTitleCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _subtitleid = 0;

        private string _subtitle = string.Empty;

        private Int32 _titleid = 0;



        #endregion

        #region "properties"
        public Int64 subtitleid
        {

            get { return _subtitleid; }

            set { _subtitleid = value; }

        }

        public string subtitle
        {

            get { return _subtitle; }

            set { _subtitle = value; }

        }

        public Int32 titleid
        {

            get { return _titleid; }

            set { _titleid = value; }

        }


        #endregion

        #region "constructors"

        //Default Constructor
        public ArticleSubTitleCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public ArticleSubTitleCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _subtitleid = Convert.ToInt64(dt.Rows[0]["subtitleid"]);
                    _subtitle = Convert.ToString(dt.Rows[0]["subtitle"]);
                    _titleid = Convert.ToInt16(dt.Rows[0]["titleid"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public long insert(ArticleSubTitleCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_ArticleSubTitle_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.subtitleid = Convert.ToInt64(obj_con.getValue("@subtitleid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleSubTitle_insert");
            }
        }

        //update data into database 
        public long update(ArticleSubTitleCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_ArticleSubTitle_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.subtitleid = Convert.ToInt64(obj_con.getValue("@subtitleid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleSubTitle_update");
            }
        }

        //delete data from database 
        public void delete(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@subtitleid", id);
                obj_con.ExecuteNoneQuery("AI_sp_ArticleSubTitle_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_ArticleSubTitle_delete");
            }
        }

        //select all data from database 
        public DataTable getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleSubTitle_selectall", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleSubTitle_selectall");
            }
        }

        //select data from database as list
        public List<ArticleSubTitleCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@subtitleid", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleSubTitle_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleSubTitle_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@subtitleid", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_ArticleSubTitle_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_ArticleSubTitle_select");
            }
        }

        //create parameter 
        public void createParameter(ArticleSubTitleCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.addParameter("@subtitle", obj.subtitle);
                obj_con.addParameter("@titleid", obj.titleid);
                obj_con.addParameter("@subtitleid", obj.subtitleid, trans);
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
        public List<ArticleSubTitleCLS> ConvertToList(DataTable dt)
        {
            List<ArticleSubTitleCLS> ArticleSubTitlelist = new List<ArticleSubTitleCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (ArticleSubTitleCLS obj_ArticleSubTitle = new ArticleSubTitleCLS())
                {
                    obj_ArticleSubTitle.subtitleid = Convert.ToInt64(dt.Rows[i]["subtitleid"]);
                    obj_ArticleSubTitle.subtitle = Convert.ToString(dt.Rows[i]["subtitle"]);
                    obj_ArticleSubTitle.titleid = Convert.ToInt16(dt.Rows[i]["titleid"]);
                    ArticleSubTitlelist.Add(obj_ArticleSubTitle);
                }
            }
            return ArticleSubTitlelist;
        }


        #endregion
    }
}
