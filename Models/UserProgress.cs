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
    public class UserProgressCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _progressid = 0;

        private Int32 _contentid = 0;

        private Int32 _userid = 0;
        private string _contentname = string.Empty;



        #endregion

        #region "properties"
        public Int64 progressid
        {

            get { return _progressid; }

            set { _progressid = value; }

        }

        public Int32 contentid
        {

            get { return _contentid; }

            set { _contentid = value; }

        }
        public string contentname
        {

            get { return _contentname; }

            set { _contentname = value; }

        }
        
        public Int32 userid
        {

            get { return _userid; }

            set { _userid = value; }

        }


        #endregion

        #region "constructors"

        //Default Constructor
        public UserProgressCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public UserProgressCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _progressid = Convert.ToInt64(dt.Rows[0]["progressid"]);
                    _contentid = Convert.ToInt16(dt.Rows[0]["contentid"]);
                    _userid = Convert.ToInt16(dt.Rows[0]["userid"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public void insert(UserProgressCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_UserProgress_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                //return obj.progressid = Convert.ToInt64(obj_con.getValue("@progressid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_UserProgress_insert");
            }
        }

        //update data into database 
        public long update(UserProgressCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_UserProgress_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.progressid = Convert.ToInt64(obj_con.getValue("@progressid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_UserProgress_update");
            }
        }

        //delete data from database 
        public void delete(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@progressid", id);
                obj_con.ExecuteNoneQuery("AI_sp_UserProgress_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_UserProgress_delete");
            }
        }

        //select all data from database 
        public DataTable getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_UserProgress_selectall", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_UserProgress_selectall");
            }
        }

        //select all data from database  by user
        public DataTable getAllbyuser(Int32 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@id",id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_UserProgress_selectbyuser", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_UserProgress_selectbyuser");
            }
        }


        //select data from database as list
        public List<UserProgressCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@progressid", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_UserProgress_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_UserProgress_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@progressid", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_UserProgress_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_UserProgress_select");
            }
        }

        //create parameter 
        public void createParameter(UserProgressCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.addParameter("@contentid", obj.contentid);
                obj_con.addParameter("@userid", obj.userid);
                obj_con.addParameter("@progressid", obj.progressid, trans);
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
        public List<UserProgressCLS> ConvertToList(DataTable dt)
        {
            List<UserProgressCLS> UserProgresslist = new List<UserProgressCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (UserProgressCLS obj_UserProgress = new UserProgressCLS())
                {
                    obj_UserProgress.progressid = Convert.ToInt64(dt.Rows[i]["progressid"]);
                    obj_UserProgress.contentid = Convert.ToInt16(dt.Rows[i]["contentid"]);
                    obj_UserProgress.userid = Convert.ToInt16(dt.Rows[i]["userid"]);
                    UserProgresslist.Add(obj_UserProgress);
                }
            }
            return UserProgresslist;
        }


        #endregion
    }
}
