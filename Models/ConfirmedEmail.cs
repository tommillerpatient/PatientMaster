using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using DB_con;


namespace PatientMaster.Models
{
    public class ConfirmedEmailClass
    {
        #region "properties"
        public Int32 Confirmemailid { get; set; }

        public Int32 Personid { get; set; }

        public string Guid { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Requestdate { get; set; }

        public bool Isused { get; set; }



        public ConfirmedEmailClass()
        {

            Confirmemailid = 0;
            Personid = 0;
            Guid = "update";
            Requestdate = Convert.ToDateTime("1900-01-01");
            Isused = false;
        }
        #endregion
    }

    public class ConfirmedEmailCtl : IDisposable
    {
        #region "constructors"

        ConnectionCls obj_con = null;
        //Default Constructor
        public ConfirmedEmailCtl()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public ConfirmedEmailCtl(Int32 id)
        {
            obj_con = new ConnectionCls();
            ConfirmedEmailClass obj_Con = new ConfirmedEmailClass();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    obj_Con.Confirmemailid = Convert.ToInt32(dt.Rows[0]["Confirmemailid"]);
                    obj_Con.Personid = Convert.ToInt32(dt.Rows[0]["Personid"]);
                    obj_Con.Guid = Convert.ToString(dt.Rows[0]["Guid"]);
                    obj_Con.Requestdate = Convert.ToDateTime(dt.Rows[0]["Requestdate"]);
                    obj_Con.Isused = Convert.ToBoolean(dt.Rows[0]["Isused"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public Int32 insert(ConfirmedEmailClass obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_ConfirmedEmail_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.Confirmemailid = Convert.ToInt32(obj_con.getValue("@Confirmemailid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_ConfirmedEmail_insert");
            }
        }

        //update data into database 
        public Int32 update(ConfirmedEmailClass obj)
        {
            try
            {
                obj_con.clearParameter();
                obj = updateObject(obj);
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_ConfirmedEmail_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.Confirmemailid = Convert.ToInt32(obj_con.getValue("@Confirmemailid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_ConfirmedEmail_update");
            }
        }

        //delete data from database 
        public void delete(Int32 Confirmemailid)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@Confirmemailid", Confirmemailid);
                obj_con.ExecuteNoneQuery("sp_ConfirmedEmail_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_ConfirmedEmail_delete");
            }
        }

        //select all data from database 
        public List<ConfirmedEmailClass> getAll()
        {
            try
            {
                obj_con.clearParameter();
                DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_ConfirmedEmail_selectall", CommandType.StoredProcedure));
                obj_con.CommitTransaction();
                return ConvertToList(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("sp_ConfirmedEmail_selectall");
            }
        }

        //select data from database as Paging
        public List<ConfirmedEmailClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@pageFirstIndex", firstPageIndex);
                obj_con.addParameter("@pageLastIndex", pageSize);
                DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_ConfirmedEmail_selectPaging", CommandType.StoredProcedure));
                obj_con.CommitTransaction();
                return ConvertToList(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("sp_ConfirmedEmail_selectPaging");
            }
        }

        public List<ConfirmedEmailClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@PageSize", PageSize);
                obj_con.addParameter("@PageIndex", PageIndex);
                obj_con.addParameter("@Search", Search);
                DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_ConfirmedEmail_selectIndexPaging", CommandType.StoredProcedure));
                obj_con.CommitTransaction();
                return ConvertToList(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("sp_ConfirmedEmail_selectIndexPaging");
            }
        }
        public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@PageSize", PageSize);
                obj_con.addParameter("@PageIndex", PageIndex);
                obj_con.addParameter("@Search", Search);
                DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_ConfirmedEmail_selectIndexPaging", CommandType.StoredProcedure));
                obj_con.CommitTransaction();
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception("sp_ConfirmedEmail_selectIndexPaging");
            }
        }
        public List<ConfirmedEmailClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@StartIndex", StartIndex);
                obj_con.addParameter("@EndIndex", EndIndex);
                obj_con.addParameter("@Search", Search);
                DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_AddressBook_selectLazyLoading", CommandType.StoredProcedure));
                obj_con.CommitTransaction();
                return ConvertToList(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("sp_AddressBook_selectLazyLoading");
            }
        }
        //select data from database as list
        public List<ConfirmedEmailClass> selectlist(Int32 Confirmemailid)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@Confirmemailid", Confirmemailid);
                DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_ConfirmedEmail_select", CommandType.StoredProcedure));
                obj_con.CommitTransaction();
                return ConvertToList(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("sp_ConfirmedEmail_select");
            }
        }

        //select data from database as Objject
        public ConfirmedEmailClass selectById(Int32 Confirmemailid)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@Confirmemailid", Confirmemailid);
                DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_ConfirmedEmail_select", CommandType.StoredProcedure));
                obj_con.CommitTransaction();
                return ConvertToOjbect(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("sp_ConfirmedEmail_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int32 Confirmemailid)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@Confirmemailid", Confirmemailid);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_ConfirmedEmail_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_ConfirmedEmail_select");
            }
        }

        //create parameter 
        public void createParameter(ConfirmedEmailClass obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@Personid", string.IsNullOrEmpty(Convert.ToString(obj.Personid)) ? 0 : obj.Personid);
                obj_con.addParameter("@Guid", string.IsNullOrEmpty(Convert.ToString(obj.Guid)) ? "" : obj.Guid);
                obj_con.addParameter("@Requestdate", string.IsNullOrEmpty(Convert.ToString(obj.Requestdate)) ? Convert.ToDateTime("1900-01-01") : obj.Requestdate);
                obj_con.addParameter("@Isused", string.IsNullOrEmpty(Convert.ToString(obj.Isused)) ? false : obj.Isused);
                obj_con.addParameter("@Confirmemailid", obj.Confirmemailid, trans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //update edited object 
        public ConfirmedEmailClass updateObject(ConfirmedEmailClass obj)
        {
            try
            {

                ConfirmedEmailClass oldObj = selectById(obj.Confirmemailid);
                if (obj.Personid == null || obj.Personid.ToString().Trim() == "0")
                    obj.Personid = oldObj.Personid;

                if (obj.Guid == null || obj.Guid.ToString().Trim() == "update")
                    obj.Guid = oldObj.Guid;

                if (obj.Requestdate == null || obj.Requestdate == Convert.ToDateTime("1900-01-01"))
                    obj.Requestdate = oldObj.Requestdate;

                if (obj.Isused == null || obj.Isused.ToString().Trim() == "0")
                    obj.Isused = oldObj.Isused;

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
        public List<ConfirmedEmailClass> ConvertToList(DataTable dt)
        {
            List<ConfirmedEmailClass> ConfirmedEmaillist = new List<ConfirmedEmailClass>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ConfirmedEmailClass obj_ConfirmedEmail = new ConfirmedEmailClass();

                if (Convert.ToString(dt.Rows[i]["Confirmemailid"]) != "")
                    obj_ConfirmedEmail.Confirmemailid = Convert.ToInt32(dt.Rows[i]["Confirmemailid"]);
                else
                    obj_ConfirmedEmail.Confirmemailid = Convert.ToInt32("0");

                if (Convert.ToString(dt.Rows[i]["Personid"]) != "")
                    obj_ConfirmedEmail.Personid = Convert.ToInt32(dt.Rows[i]["Personid"]);
                else
                    obj_ConfirmedEmail.Personid = Convert.ToInt32("0");

                if (Convert.ToString(dt.Rows[i]["Guid"]) != "")
                    obj_ConfirmedEmail.Guid = Convert.ToString(dt.Rows[i]["Guid"]);
                else
                    obj_ConfirmedEmail.Guid = Convert.ToString("");

                if (Convert.ToString(dt.Rows[i]["Requestdate"]) != "")
                    obj_ConfirmedEmail.Requestdate = Convert.ToDateTime(dt.Rows[i]["Requestdate"]);
                else
                    obj_ConfirmedEmail.Requestdate = Convert.ToDateTime("01/01/1900");

                if (Convert.ToString(dt.Rows[i]["Isused"]) != "")
                    obj_ConfirmedEmail.Isused = Convert.ToBoolean(dt.Rows[i]["Isused"]);
                else
                    obj_ConfirmedEmail.Isused = Convert.ToBoolean(0);


                ConfirmedEmaillist.Add(obj_ConfirmedEmail);
            }
            return ConfirmedEmaillist;
        }

        //Convert DataTable To object method
        public ConfirmedEmailClass ConvertToOjbect(DataTable dt)
        {
            ConfirmedEmailClass obj_ConfirmedEmail = new ConfirmedEmailClass();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (Convert.ToString(dt.Rows[i]["Confirmemailid"]) != "")
                    obj_ConfirmedEmail.Confirmemailid = Convert.ToInt32(dt.Rows[i]["Confirmemailid"]);
                else
                    obj_ConfirmedEmail.Confirmemailid = Convert.ToInt32("0");

                if (Convert.ToString(dt.Rows[i]["Personid"]) != "")
                    obj_ConfirmedEmail.Personid = Convert.ToInt32(dt.Rows[i]["Personid"]);
                else
                    obj_ConfirmedEmail.Personid = Convert.ToInt32("0");

                if (Convert.ToString(dt.Rows[i]["Guid"]) != "")
                    obj_ConfirmedEmail.Guid = Convert.ToString(dt.Rows[i]["Guid"]);
                else
                    obj_ConfirmedEmail.Guid = Convert.ToString("");

                if (Convert.ToString(dt.Rows[i]["Requestdate"]) != "")
                    obj_ConfirmedEmail.Requestdate = Convert.ToDateTime(dt.Rows[i]["Requestdate"]);
                else
                    obj_ConfirmedEmail.Requestdate = Convert.ToDateTime("01/01/1900");

                if (Convert.ToString(dt.Rows[i]["Isused"]) != "")
                    obj_ConfirmedEmail.Isused = Convert.ToBoolean(dt.Rows[i]["Isused"]);
                else
                    obj_ConfirmedEmail.Isused = Convert.ToBoolean(0);
            }
            return obj_ConfirmedEmail;
        }


        //disposble method
        void IDisposable.Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }

}
