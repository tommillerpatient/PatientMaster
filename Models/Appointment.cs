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
    public class AppointmentCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _appointmentid = 0;

        private DateTime _appointmentdate = DateTime.Now;

        private string _appointmentdesc = string.Empty;

        private Int32 _staffid = 0;

        private Int32 _patientid = 0;

        private string _appointmentname = string.Empty;

        private bool _active = false;

        private DateTime _appointmenton = DateTime.Now;

        private Int32 _attendid = 0;



        #endregion

        #region "properties"
        public Int64 appointmentid
        {

            get { return _appointmentid; }

            set { _appointmentid = value; }

        }

        public DateTime appointmentdate
        {

            get { return _appointmentdate; }

            set { _appointmentdate = value; }

        }

        public string appointmentdesc
        {

            get { return _appointmentdesc; }

            set { _appointmentdesc = value; }

        }

        public Int32 staffid
        {

            get { return _staffid; }

            set { _staffid = value; }

        }

        public Int32 patientid
        {

            get { return _patientid; }

            set { _patientid = value; }

        }

        public string appointmentname
        {

            get { return _appointmentname; }

            set { _appointmentname = value; }

        }

        public bool active
        {

            get { return _active; }

            set { _active = value; }

        }

        public DateTime appointmenton
        {

            get { return _appointmenton; }

            set { _appointmenton = value; }

        }

        public Int32 attendid
        {

            get { return _attendid; }

            set { _attendid = value; }

        }


        #endregion

        #region "constructors"

        //Default Constructor
        public AppointmentCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public AppointmentCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _appointmentid = Convert.ToInt64(dt.Rows[0]["appointmentid"]);
                    _appointmentdate = Convert.ToDateTime(dt.Rows[0]["appointmentdate"]);
                    _appointmentdesc = Convert.ToString(dt.Rows[0]["appointmentdesc"]);
                    _staffid = Convert.ToInt16(dt.Rows[0]["staffid"]);
                    _patientid = Convert.ToInt16(dt.Rows[0]["patientid"]);
                    _appointmentname = Convert.ToString(dt.Rows[0]["appointmentname"]);
                    _active = Convert.ToBoolean(dt.Rows[0]["active"]);
                    _appointmenton = Convert.ToDateTime(dt.Rows[0]["appointmenton"]);
                    _attendid = Convert.ToInt16(dt.Rows[0]["attendid"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public long insert(AppointmentCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Appointment_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.appointmentid = Convert.ToInt64(obj_con.getValue("@appointmentid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Appointment_insert");
            }
        }

        //update data into database 
        public long update(AppointmentCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Appointment_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.appointmentid = Convert.ToInt64(obj_con.getValue("@appointmentid"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Appointment_update");
            }
        }

        //delete data from database 
        public void delete(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@appointmentid", id);
                obj_con.ExecuteNoneQuery("sp_Appointment_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Appointment_delete");
            }
        }

        //select all data from database 
        public DataTable getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Appointment_selectall", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Appointment_selectall");
            }
        }

        //select data from database as list
        public List<AppointmentCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@appointmentid", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Appointment_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Appointment_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@appointmentid", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_Appointment_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("sp_Appointment_select");
            }
        }

        //create parameter 
        public void createParameter(AppointmentCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                obj_con.addParameter("@appointmentdate", obj.appointmentdate);
                obj_con.addParameter("@appointmentdesc", obj.appointmentdesc);
                obj_con.addParameter("@staffid", obj.staffid);
                obj_con.addParameter("@patientid", obj.patientid);
                obj_con.addParameter("@appointmentname", obj.appointmentname);
                obj_con.addParameter("@active", obj.active);
                obj_con.addParameter("@appointmenton", obj.appointmenton);
                obj_con.addParameter("@attendid", obj.attendid);
                obj_con.addParameter("@appointmentid", obj.appointmentid, trans);
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
        public List<AppointmentCLS> ConvertToList(DataTable dt)
        {
            List<AppointmentCLS> Appointmentlist = new List<AppointmentCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (AppointmentCLS obj_Appointment = new AppointmentCLS())
                {
                    obj_Appointment.appointmentid = Convert.ToInt64(dt.Rows[i]["appointmentid"]);
                    obj_Appointment.appointmentdate = Convert.ToDateTime(dt.Rows[i]["appointmentdate"]);
                    obj_Appointment.appointmentdesc = Convert.ToString(dt.Rows[i]["appointmentdesc"]);
                    obj_Appointment.staffid = Convert.ToInt16(dt.Rows[i]["staffid"]);
                    obj_Appointment.patientid = Convert.ToInt16(dt.Rows[i]["patientid"]);
                    obj_Appointment.appointmentname = Convert.ToString(dt.Rows[i]["appointmentname"]);
                    obj_Appointment.active = Convert.ToBoolean(dt.Rows[i]["active"]);
                    obj_Appointment.appointmenton = Convert.ToDateTime(dt.Rows[i]["appointmenton"]);
                    obj_Appointment.attendid = Convert.ToInt16(dt.Rows[i]["attendid"]);
                    Appointmentlist.Add(obj_Appointment);
                }
            }
            return Appointmentlist;
        }


        #endregion
    }
}
