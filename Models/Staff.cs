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
    public class StaffCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _id = 0;

        private string _emailid = string.Empty;

        private string _password = string.Empty;
        private string _newpassword = string.Empty;


        private Int16 _roleid = 0;

        private string _firstname = string.Empty;
        private string _lastname = string.Empty;



        #endregion

        #region "properties"
        public Int64 id
        {

            get { return _id; }

            set { _id = value; }

        }

        public string emailid
        {

            get { return _emailid; }

            set { _emailid = value; }

        }

        public string password
        {

            get { return _password; }

            set { _password = value; }

        }
        public string newpassword

        {

            get { return _newpassword; }

            set { _newpassword = value; }

        }
        public Int16 roleid
        {

            get { return _roleid; }

            set { _roleid = value; }

        }
        public string firstname

        {

            get { return _firstname; }

            set { _firstname = value; }

        }

        public string lastname
        {

            get { return _lastname; }

            set { _lastname = value; }

        }

        #endregion

        #region "constructors"

        //Default Constructor
        public StaffCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public StaffCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _id = Convert.ToInt64(dt.Rows[0]["id"]);
                    _emailid = Convert.ToString(dt.Rows[0]["emailid"]);
                    _password = Convert.ToString(dt.Rows[0]["password"]);
                    _roleid = Convert.ToInt16(dt.Rows[0]["roleid"]);
                    _firstname = Convert.ToString(dt.Rows[0]["firstname"]);
                    _lastname = Convert.ToString(dt.Rows[0]["lastname"]);
                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public long insert(StaffCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Staff_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.id = Convert.ToInt64(obj_con.getValue("@id"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Staff_insert");
            }
        }

        //update data into database 
        public long update(StaffCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Staff_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.id = Convert.ToInt64(obj_con.getValue("@id"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Staff_update");
            }
        }

        //delete data from database 
        public void delete(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@id", id);
                obj_con.ExecuteNoneQuery("sp_Staff_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Staff_delete");
            }
        }


        //CheckOldPassword

        public long CheckOldPassword(StaffCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@retVal", 0, DBTrans.Insert);
                obj_con.addParameter("@id", obj.id);
                obj_con.addParameter("@passwordold", obj.password);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Staff_CheckOldPassword", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return Convert.ToInt64(obj_con.getValue("@retVal"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Staff_CheckOldPassword");
            }
        }
        //update Password
        public long UpdatePassword(StaffCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@id", obj.id);
                obj_con.addParameter("@password", obj.newpassword);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_staff_updatepassword", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.id = Convert.ToInt64(obj_con.getValue("@id"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_staff_updatepassword");
            }
        }


        //select all data from database 
        public DataTable getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Staff_selectall", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Staff_selectall");
            }
        }

        //select data from database as list
        public List<StaffCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@id", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Staff_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Staff_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@id", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Staff_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Staff_select");
            }
        }

        //create parameter 
        public void createParameter(StaffCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.addParameter("@emailid", obj.emailid);
                obj_con.addParameter("@password", obj.password);
                obj_con.addParameter("@firstname", obj.firstname);
                obj_con.addParameter("@lastname", obj.lastname);
                obj_con.addParameter("@roleid", obj.roleid);
                obj_con.addParameter("@id", obj.id, trans);
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
        //check user name and password
        public DataTable CheckUserNamePass(StaffCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@emailid", obj.emailid);
                obj_con.addParameter("@password", obj.password);
                obj_con.ExecuteNoneQuery("sp_StaffLogin_CheckUserNamePass", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_StaffLogin_CheckUserNamePass", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_StaffLogin_CheckUserNamePass");
            }
        }
        //Convert IDataReader To DataTable method
        public DataTable ConvertDatareadertoDataTable(IDataReader dr)
        {
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        //Convert DataTable To List method
        public List<StaffCLS> ConvertToList(DataTable dt)
        {
            List<StaffCLS> Stafflist = new List<StaffCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (StaffCLS obj_Staff = new StaffCLS())
                {
                    obj_Staff.id = Convert.ToInt64(dt.Rows[i]["id"]);
                    obj_Staff.emailid = Convert.ToString(dt.Rows[i]["emailid"]);
                    obj_Staff.password = Convert.ToString(dt.Rows[i]["password"]);
                    obj_Staff.roleid = Convert.ToInt16(dt.Rows[i]["roleid"]);
                    Stafflist.Add(obj_Staff);
                }
            }
            return Stafflist;
        }


        #endregion
    }
}
