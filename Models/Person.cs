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
    public class PersonCLS : IDisposable
    {
        #region "variables"

        ConnectionCls obj_con = null;
        private Int64 _id = 0;

        private string _username = string.Empty;

        private string _passwordhash = string.Empty;

        private string _sessiontoken = string.Empty;

        private string _firstname = string.Empty;

        private string _middlename = string.Empty;

        private string _lastname = string.Empty;

        private DateTime _dateofbirth = DateTime.Now;

        private Int16 _gender = 0;

        private string _email = string.Empty;

        private Int16 _phone1 = 0;

        private Int16 _phone2 = 0;

        private Int16 _phone3 = 0;

        private Int16 _personispatient = 0;

        private bool _acknowledgednoticeofprivacy = false;

        private string _address = string.Empty;

        private Int16 _zipcode = 0;

        private string _state = string.Empty;

        private string _city = string.Empty;

        private string _procedure = string.Empty;

        private DateTime _proceduredate = DateTime.Now;

        private string _insurancecompanyname = string.Empty;

        private DateTime _insuranceeffectivedate = DateTime.Now;

        private string _guarantor = string.Empty;

        private string _groupnumber = string.Empty;

        private string _policynumber = string.Empty;

        private string _preferredpharmacy = string.Empty;

        private string _pharmacyphone = string.Empty;

        private string _pharmacyaddress1 = string.Empty;

        private string _pharmacyaddress2 = string.Empty;

        private string _pharmacycity = string.Empty;

        private string _pharmacystate = string.Empty;



        #endregion

        #region "properties"
        public Int64 id
        {

            get { return _id; }

            set { _id = value; }

        }

        public string username
        {

            get { return _username; }

            set { _username = value; }

        }

        public string passwordhash
        {

            get { return _passwordhash; }

            set { _passwordhash = value; }

        }

        public string sessiontoken
        {

            get { return _sessiontoken; }

            set { _sessiontoken = value; }

        }

        public string firstname
        {

            get { return _firstname; }

            set { _firstname = value; }

        }

        public string middlename
        {

            get { return _middlename; }

            set { _middlename = value; }

        }

        public string lastname
        {

            get { return _lastname; }

            set { _lastname = value; }

        }

        public DateTime dateofbirth
        {

            get { return _dateofbirth; }

            set { _dateofbirth = value; }

        }

        public Int16 gender
        {

            get { return _gender; }

            set { _gender = value; }

        }

        public string email
        {

            get { return _email; }

            set { _email = value; }

        }

        public Int16 phone1
        {

            get { return _phone1; }

            set { _phone1 = value; }

        }

        public Int16 phone2
        {

            get { return _phone2; }

            set { _phone2 = value; }

        }

        public Int16 phone3
        {

            get { return _phone3; }

            set { _phone3 = value; }

        }

        public Int16 personispatient
        {

            get { return _personispatient; }

            set { _personispatient = value; }

        }

        public bool acknowledgednoticeofprivacy
        {

            get { return _acknowledgednoticeofprivacy; }

            set { _acknowledgednoticeofprivacy = value; }

        }

        public string address
        {

            get { return _address; }

            set { _address = value; }

        }

        public Int16 zipcode
        {

            get { return _zipcode; }

            set { _zipcode = value; }

        }

        public string state
        {

            get { return _state; }

            set { _state = value; }

        }

        public string city
        {

            get { return _city; }

            set { _city = value; }

        }

        public string procedure
        {

            get { return _procedure; }

            set { _procedure = value; }

        }

        public DateTime proceduredate
        {

            get { return _proceduredate; }

            set { _proceduredate = value; }

        }

        public string insurancecompanyname
        {

            get { return _insurancecompanyname; }

            set { _insurancecompanyname = value; }

        }

        public DateTime insuranceeffectivedate
        {

            get { return _insuranceeffectivedate; }

            set { _insuranceeffectivedate = value; }

        }

        public string guarantor
        {

            get { return _guarantor; }

            set { _guarantor = value; }

        }

        public string groupnumber
        {

            get { return _groupnumber; }

            set { _groupnumber = value; }

        }

        public string policynumber
        {

            get { return _policynumber; }

            set { _policynumber = value; }

        }

        public string preferredpharmacy
        {

            get { return _preferredpharmacy; }

            set { _preferredpharmacy = value; }

        }

        public string pharmacyphone
        {

            get { return _pharmacyphone; }

            set { _pharmacyphone = value; }

        }

        public string pharmacyaddress1
        {

            get { return _pharmacyaddress1; }

            set { _pharmacyaddress1 = value; }

        }

        public string pharmacyaddress2
        {

            get { return _pharmacyaddress2; }

            set { _pharmacyaddress2 = value; }

        }

        public string pharmacycity
        {

            get { return _pharmacycity; }

            set { _pharmacycity = value; }

        }

        public string pharmacystate
        {

            get { return _pharmacystate; }

            set { _pharmacystate = value; }

        }


        #endregion

        #region "constructors"

        //Default Constructor
        public PersonCLS()
        {
            obj_con = new ConnectionCls();
        }

        //Select Constructor
        public PersonCLS(Int64 id)
        {
            obj_con = new ConnectionCls();
            using (DataTable dt = selectdatatable(id))
            {
                if (dt.Rows.Count > 0)
                {

                    _id = Convert.ToInt16(dt.Rows[0]["id"]);
                    _username = Convert.ToString(dt.Rows[0]["username"]);
                    _passwordhash = Convert.ToString(dt.Rows[0]["passwordhash"]);
                    _sessiontoken = Convert.ToString(dt.Rows[0]["sessiontoken"]);
                    _firstname = Convert.ToString(dt.Rows[0]["firstname"]);
                    _middlename = Convert.ToString(dt.Rows[0]["middlename"]);
                    _lastname = Convert.ToString(dt.Rows[0]["lastname"]);
                    _gender = Convert.ToInt16(dt.Rows[0]["gender"]);
                    _email = Convert.ToString(dt.Rows[0]["email"]);
                    _phone1 = Convert.ToInt16(dt.Rows[0]["phone1"]);
                    _phone2 = Convert.ToInt16(dt.Rows[0]["phone2"]);
                    _phone3 = Convert.ToInt16(dt.Rows[0]["phone3"]);
                    _personispatient = Convert.ToInt16(dt.Rows[0]["personispatient"]);
                    _acknowledgednoticeofprivacy = Convert.ToBoolean(dt.Rows[0]["acknowledgednoticeofprivacy"]);
                    _address = Convert.ToString(dt.Rows[0]["address"]);
                    _zipcode = Convert.ToInt16(dt.Rows[0]["zipcode"]);
                    _state = Convert.ToString(dt.Rows[0]["state"]);
                    _city = Convert.ToString(dt.Rows[0]["city"]);
                    _procedure = Convert.ToString(dt.Rows[0]["procedure"]);
                    _proceduredate = Convert.ToDateTime(dt.Rows[0]["proceduredate"]);
                    _insurancecompanyname = Convert.ToString(dt.Rows[0]["insurancecompanyname"]);
                    _insuranceeffectivedate = Convert.ToDateTime(dt.Rows[0]["insuranceeffectivedate"]);
                    _guarantor = Convert.ToString(dt.Rows[0]["guarantor"]);
                    _groupnumber = Convert.ToString(dt.Rows[0]["groupnumber"]);
                    _policynumber = Convert.ToString(dt.Rows[0]["policynumber"]);
                    _preferredpharmacy = Convert.ToString(dt.Rows[0]["preferredpharmacy"]);
                    _pharmacyphone = Convert.ToString(dt.Rows[0]["pharmacyphone"]);
                    _pharmacyaddress1 = Convert.ToString(dt.Rows[0]["pharmacyaddress1"]);
                    _pharmacyaddress2 = Convert.ToString(dt.Rows[0]["pharmacyaddress2"]);
                    _pharmacycity = Convert.ToString(dt.Rows[0]["pharmacycity"]);
                    _pharmacystate = Convert.ToString(dt.Rows[0]["pharmacystate"]);

                }
            }
        }


        #endregion

        #region "methods"

        //insert data into database 
        public long insert(PersonCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Insert);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("sp_Person_insert", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.id = Convert.ToInt64(obj_con.getValue("@id"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_Person_insert");
            }
        }

        //update data into database 
        public long update(PersonCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                createParameter(obj, DBTrans.Update);
                obj_con.BeginTransaction();
                obj_con.ExecuteNoneQuery("AI_sp_Person_update", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return obj.id = Convert.ToInt64(obj_con.getValue("@id"));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_Person_update");
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
                obj_con.ExecuteNoneQuery("AI_sp_Person_delete", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("AI_sp_Person_delete");
            }
        }

        //select all data from database 
        public List<PersonCLS> getAll()
        {
            try
            {
                obj_con.clearParameter();
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_Person_selectall", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_Person_selectall");
            }
        }

        //select data from database as list
        public List<PersonCLS> selectlist(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@id", id);
                return ConvertToList(ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_Person_select", CommandType.StoredProcedure)));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_Person_select");
            }
        }

        //select data from database as datatable
        public DataTable selectdatatable(Int64 id)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.addParameter("@id", id);
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("AI_sp_Person_select", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("AI_sp_Person_select");
            }
        }

        //create parameter 


        //check user name and password
        public DataTable CheckUserNamePass(PersonCLS obj)
        {
            try
            {
                obj_con.clearParameter();
                obj_con.BeginTransaction();
                obj_con.addParameter("@emailid", obj.email);
                obj_con.addParameter("@password", obj.passwordhash);
                obj_con.ExecuteNoneQuery("sp_UserLogin_CheckUserNamePass", CommandType.StoredProcedure);
                obj_con.CommitTransaction();
                return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_UserLogin_CheckUserNamePass", CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                obj_con.RollbackTransaction();
                throw new Exception("sp_UserLogin_CheckUserNamePass");
            }
        }

        public void createParameter(PersonCLS obj, DB_con.DBTrans trans)
        {
            try
            {
                if (obj.username==null)
                {
                    obj.username = string.Empty;

                }
                if (obj.passwordhash == null)
                {
                    obj.passwordhash = string.Empty;

                }
                if (obj.sessiontoken == null)
                {
                    obj.sessiontoken = string.Empty;

                }
                if (obj.middlename == null)
                {
                    obj.middlename = string.Empty;

                }
                if (obj.guarantor == null)
                {
                    obj.guarantor = string.Empty;

                }
                obj_con.addParameter("@username", obj.username);
                obj_con.addParameter("@passwordhash", obj.passwordhash);
                obj_con.addParameter("@sessiontoken", obj.sessiontoken);
                obj_con.addParameter("@firstname", obj.firstname);
                obj_con.addParameter("@middlename", obj.middlename);
                obj_con.addParameter("@lastname", obj.lastname);
                obj_con.addParameter("@dateofbirth", obj.dateofbirth);
                obj_con.addParameter("@gender", obj.gender);
                obj_con.addParameter("@email", obj.email);
                obj_con.addParameter("@phone1", obj.phone1);
                obj_con.addParameter("@phone2", obj.phone2);
                obj_con.addParameter("@phone3", obj.phone3);
                obj_con.addParameter("@personispatient", obj.personispatient);
                obj_con.addParameter("@acknowledgednoticeofprivacy", obj.acknowledgednoticeofprivacy);
                obj_con.addParameter("@address", obj.address);
                obj_con.addParameter("@zipcode", obj.zipcode);
                obj_con.addParameter("@state", obj.state);
                obj_con.addParameter("@city", obj.city);
                obj_con.addParameter("@procedure", obj.procedure);
                obj_con.addParameter("@proceduredate", obj.proceduredate);
                obj_con.addParameter("@insurancecompanyname", obj.insurancecompanyname);
                obj_con.addParameter("@insuranceeffectivedate", obj.insuranceeffectivedate);
                obj_con.addParameter("@guarantor", obj.guarantor);
                obj_con.addParameter("@groupnumber", obj.groupnumber);
                obj_con.addParameter("@policynumber", obj.policynumber);
                obj_con.addParameter("@preferredpharmacy", obj.preferredpharmacy);
                obj_con.addParameter("@pharmacyphone", obj.pharmacyphone);
                obj_con.addParameter("@pharmacyaddress1", obj.pharmacyaddress1);
                obj_con.addParameter("@pharmacyaddress2", obj.pharmacyaddress2);
                obj_con.addParameter("@pharmacycity", obj.pharmacycity);
                obj_con.addParameter("@pharmacystate", obj.pharmacystate);
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

        //Convert IDataReader To DataTable method
        public DataTable ConvertDatareadertoDataTable(IDataReader dr)
        {
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        //Convert DataTable To List method
        public List<PersonCLS> ConvertToList(DataTable dt)
        {
            List<PersonCLS> Personlist = new List<PersonCLS>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (PersonCLS obj_Person = new PersonCLS())
                {
                    obj_Person.id = Convert.ToInt16(dt.Rows[i]["id"]);
                    obj_Person.username = Convert.ToString(dt.Rows[i]["username"]);
                    obj_Person.passwordhash = Convert.ToString(dt.Rows[i]["passwordhash"]);
                    obj_Person.sessiontoken = Convert.ToString(dt.Rows[i]["sessiontoken"]);
                    obj_Person.firstname = Convert.ToString(dt.Rows[i]["firstname"]);
                    obj_Person.middlename = Convert.ToString(dt.Rows[i]["middlename"]);
                    obj_Person.lastname = Convert.ToString(dt.Rows[i]["lastname"]);
                    obj_Person.gender = Convert.ToInt16(dt.Rows[i]["gender"]);
                    obj_Person.email = Convert.ToString(dt.Rows[i]["email"]);
                    obj_Person.phone1 = Convert.ToInt16(dt.Rows[i]["phone1"]);
                    obj_Person.phone2 = Convert.ToInt16(dt.Rows[i]["phone2"]);
                    obj_Person.phone3 = Convert.ToInt16(dt.Rows[i]["phone3"]);
                    obj_Person.personispatient = Convert.ToInt16(dt.Rows[i]["personispatient"]);
                    obj_Person.acknowledgednoticeofprivacy = Convert.ToBoolean(dt.Rows[i]["acknowledgednoticeofprivacy"]);
                    obj_Person.address = Convert.ToString(dt.Rows[i]["address"]);
                    obj_Person.zipcode = Convert.ToInt16(dt.Rows[i]["zipcode"]);
                    obj_Person.state = Convert.ToString(dt.Rows[i]["state"]);
                    obj_Person.city = Convert.ToString(dt.Rows[i]["city"]);
                    obj_Person.procedure = Convert.ToString(dt.Rows[i]["procedure"]);
                    obj_Person.proceduredate = Convert.ToDateTime(dt.Rows[i]["proceduredate"]);
                    obj_Person.insurancecompanyname = Convert.ToString(dt.Rows[i]["insurancecompanyname"]);
                    obj_Person.insuranceeffectivedate = Convert.ToDateTime(dt.Rows[i]["insuranceeffectivedate"]);
                    obj_Person.guarantor = Convert.ToString(dt.Rows[i]["guarantor"]);
                    obj_Person.groupnumber = Convert.ToString(dt.Rows[i]["groupnumber"]);
                    obj_Person.policynumber = Convert.ToString(dt.Rows[i]["policynumber"]);
                    obj_Person.preferredpharmacy = Convert.ToString(dt.Rows[i]["preferredpharmacy"]);
                    obj_Person.pharmacyphone = Convert.ToString(dt.Rows[i]["pharmacyphone"]);
                    obj_Person.pharmacyaddress1 = Convert.ToString(dt.Rows[i]["pharmacyaddress1"]);
                    obj_Person.pharmacyaddress2 = Convert.ToString(dt.Rows[i]["pharmacyaddress2"]);
                    obj_Person.pharmacycity = Convert.ToString(dt.Rows[i]["pharmacycity"]);
                    obj_Person.pharmacystate = Convert.ToString(dt.Rows[i]["pharmacystate"]);
                    Personlist.Add(obj_Person);
                }
            }
            return Personlist;
        }


        #endregion
    }
}
