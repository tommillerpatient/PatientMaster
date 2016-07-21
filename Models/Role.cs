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
    public class RoleCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _roleid = 0;

        private string _type = string.Empty;



        #endregion

        #region "properties"
        public Int64 roleid
        {

            get { return _roleid; }

            set { _roleid = value; }

        }

        public string type
        {

            get { return _type; }

            set { _type = value; }

        }


        #endregion

        #region "constructors"

        //Default Constructor
        public RoleCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public RoleCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _roleid = Convert.ToInt64(dt.Rows[0]["roleid"]);
                    _type = Convert.ToString(dt.Rows[0]["type"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public long insert(RoleCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Role_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.roleid = Convert.ToInt64(obj_con.getValue("@roleid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Role_insert");
            }
        }

        //update data into database 
        public long update(RoleCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Role_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.roleid = Convert.ToInt64(obj_con.getValue("@roleid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Role_update");
            }
        }

        //delete data from database 
        public void delete(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@roleid", id);
                obj_con.ExecuteNoneQuery("sp_Role_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Role_delete");
            }
        }

        //select all data from database 
        public List<RoleCLS> getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Role_selectall", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Role_selectall");
            }
        }

        //select data from database as list
        public List<RoleCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@roleid", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Role_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Role_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@roleid", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Role_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Role_select");
            }
        }

        //create parameter 
        public void createParameter(RoleCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.addParameter("@type", obj.type);
                obj_con.addParameter("@roleid", obj.roleid, trans);
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
        public List<RoleCLS> ConvertToList(DataTable dt)
        {
            List<RoleCLS> Rolelist = new List<RoleCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (RoleCLS obj_Role = new RoleCLS())
                {
                    obj_Role.roleid = Convert.ToInt64(dt.Rows[i]["roleid"]);
                    obj_Role.type = Convert.ToString(dt.Rows[i]["type"]);
                    Rolelist.Add(obj_Role);
                }
            }
            return Rolelist;
        }


        #endregion
    }
}
