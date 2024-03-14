using PBS_React_API.DatabaseContext.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.DatabaseContext.DatabaseContext
{
    public class ProjectDataContext : iProjectDataContext
    {
        DataAccess dataAccess;
        private Hashtable _errObj;

        public static double hitcnumber;



        private readonly iDataAccess _dataAccess;
       

        public ProjectDataContext(iDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _errObj = new Hashtable();
        }


        public ProjectDataContext(iDataAccess dataAccess, string DbName)
        {
            _dataAccess = dataAccess;
            _errObj = new Hashtable();
            _dataAccess = new DataAccess(DbName);
            _errObj = new Hashtable();
        }
        public Hashtable ErrorObject
        {
            get
            {
                return this._errObj;
            }
        }
        public void SetError(Exception exp)
        {
            this._errObj["Src"] = exp.Source;
            this._errObj["Msg"] = exp.Message;
            this._errObj["Location"] = exp.StackTrace;
        }

        public void SetError(Hashtable errObject)
        {
            this._errObj["Src"] = errObject["Src"];
            this._errObj["Msg"] = errObject["Msg"];
            this._errObj["Location"] = errObject["Location"];
        }

        public void ClearErrors()
        {
            this._errObj["Src"] = string.Empty;
            this._errObj["Msg"] = string.Empty;
            this._errObj["Location"] = string.Empty;
        }

       

        public DataSet GetTransInfo(string SQLprocName = "", string CallType = "", string mDesc1 = "", string mDesc2 = "",
     string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "", string mDesc7 = "", string mDesc8 = "", string mDesc9 = "", string mDesc10 = "", string mDesc11 = "")
        {
            try
            {
                this.ClearErrors();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQLprocName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CallType", CallType));
                cmd.Parameters.Add(new SqlParameter("@Desc1", mDesc1));
                cmd.Parameters.Add(new SqlParameter("@Desc2", mDesc2));
                cmd.Parameters.Add(new SqlParameter("@Desc3", mDesc3));
                cmd.Parameters.Add(new SqlParameter("@Desc4", mDesc4));
                cmd.Parameters.Add(new SqlParameter("@Desc5", mDesc5));
                cmd.Parameters.Add(new SqlParameter("@Desc6", mDesc6));
                cmd.Parameters.Add(new SqlParameter("@Desc7", mDesc7));
                cmd.Parameters.Add(new SqlParameter("@Desc8", mDesc8));
                cmd.Parameters.Add(new SqlParameter("@Desc9", mDesc9));
                cmd.Parameters.Add(new SqlParameter("@Desc10", mDesc10));
                cmd.Parameters.Add(new SqlParameter("@Desc11", mDesc11));

                DataSet result = _dataAccess.GetDataSet(cmd);
                if (result == null)  //_result==false
                {
                    this.SetError(_dataAccess.ErrorObject);
                }
                return result;
            }
            catch (Exception exp)
            {
                this.SetError(exp);
                return null;
            }// try
        }


        public DataSet GetTransInfoXML(string comCode, string SQLprocName, string CallType, DataSet parmXml01 = null, DataSet parmXml02 = null, byte[] parmBin01 = null,
                  string mDesc1 = "", string mDesc2 = "", string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "", string mDesc7 = "", string mDesc8 = "",
                  string mDesc9 = "", string mDesc10 = "", string mDesc11 = "", string mDesc12 = "", string mDesc13 = "", string mDesc14 = "", string mDesc15 = "",
                  string mDesc16 = "", string mDesc17 = "", string mDesc18 = "", string mDesc19 = "", string mDesc20 = "", string @userid = "")
        {
            try
            {
                this.ClearErrors();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQLprocName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Comp1", comCode));
                cmd.Parameters.Add(new SqlParameter("@CallType", CallType));
                cmd.Parameters.Add("@Dxml01", SqlDbType.Xml).Value = (parmXml01 == null ? null : parmXml01.GetXml());
                cmd.Parameters.Add("@Dxml02", SqlDbType.Xml).Value = (parmXml02 == null ? null : parmXml02.GetXml());
                cmd.Parameters.Add(new SqlParameter("@Dbin01", parmBin01));
                cmd.Parameters.Add(new SqlParameter("@Desc1", mDesc1));
                cmd.Parameters.Add(new SqlParameter("@Desc2", mDesc2));
                cmd.Parameters.Add(new SqlParameter("@Desc3", mDesc3));
                cmd.Parameters.Add(new SqlParameter("@Desc4", mDesc4));
                cmd.Parameters.Add(new SqlParameter("@Desc5", mDesc5));
                cmd.Parameters.Add(new SqlParameter("@Desc6", mDesc6));
                cmd.Parameters.Add(new SqlParameter("@Desc7", mDesc7));
                cmd.Parameters.Add(new SqlParameter("@Desc8", mDesc8));
                cmd.Parameters.Add(new SqlParameter("@Desc9", mDesc9));
                cmd.Parameters.Add(new SqlParameter("@Desc10", mDesc10));
                cmd.Parameters.Add(new SqlParameter("@Desc11", mDesc11));
                cmd.Parameters.Add(new SqlParameter("@Desc12", mDesc12));
                cmd.Parameters.Add(new SqlParameter("@Desc13", mDesc13));
                cmd.Parameters.Add(new SqlParameter("@Desc14", mDesc14));
                cmd.Parameters.Add(new SqlParameter("@Desc15", mDesc15));
                cmd.Parameters.Add(new SqlParameter("@Desc16", mDesc16));
                cmd.Parameters.Add(new SqlParameter("@Desc17", mDesc17));
                cmd.Parameters.Add(new SqlParameter("@Desc18", mDesc18));
                cmd.Parameters.Add(new SqlParameter("@Desc19", mDesc19));
                cmd.Parameters.Add(new SqlParameter("@Desc20", mDesc20));
                cmd.Parameters.Add(new SqlParameter("@UserID", @userid));


                DataSet result = _dataAccess.GetDataSet(cmd);
                if (result == null)  //_result==false
                {
                    this.SetError(_dataAccess.ErrorObject);
                }
                return result;
            }
            catch (Exception exp)
            {
                this.SetError(exp);
                return null;
            }// try
        }


        
        public bool UpdateTransInfo(string SQLprocName, string CallType,
             string mDesc1 = "", string mDesc2 = "", string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "",
             string mDesc7 = "", string mDesc8 = "", string mDesc9 = "", string mDesc10 = "")
        {
            try
            {
                this.ClearErrors();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQLprocName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CallType", CallType));
                cmd.Parameters.Add(new SqlParameter("@Desc1", mDesc1));
                cmd.Parameters.Add(new SqlParameter("@Desc2", mDesc2));
                cmd.Parameters.Add(new SqlParameter("@Desc3", mDesc3));
                cmd.Parameters.Add(new SqlParameter("@Desc4", mDesc4));
                cmd.Parameters.Add(new SqlParameter("@Desc5", mDesc5));
                cmd.Parameters.Add(new SqlParameter("@Desc6", mDesc6));
                cmd.Parameters.Add(new SqlParameter("@Desc7", mDesc7));
                cmd.Parameters.Add(new SqlParameter("@Desc8", mDesc8));
                cmd.Parameters.Add(new SqlParameter("@Desc9", mDesc9));
                cmd.Parameters.Add(new SqlParameter("@Desc10", mDesc10));
                bool _result = _dataAccess.ExecuteCommand(cmd);
                if (_result == false)  //_result==false
                {
                    this.SetError(_dataAccess.ErrorObject);
                }
                return _result;
            }
            catch (Exception exp)
            {
                this.SetError(exp);
                return false;
            }// try
        }

        public bool UpdateXmlTransInfo(string comCode, string SQLprocName, string CallType, DataSet parmXml01 = null, DataSet parmXml02 = null, byte[] parmbyte = null,
 string mDesc1 = "", string mDesc2 = "", string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "",
            string mDesc7 = "", string mDesc8 = "", string mDesc9 = "", string mDesc10 = "", string mDesc11 = "", string mDesc12 = "",
            string mDesc13 = "", string mDesc14 = "", string mDesc15 = "", string mDesc16 = "", string mDesc17 = "", string mDesc18 = "", string mDesc19 = "",
            string mDesc20 = "", string mDesc21 = "", string mDesc22 = "", string mDesc23 = "", string mDesc24 = "", string mDesc25 = "", string mDesc26 = "",
            string mDesc27 = "", string mDesc28 = "", string mDesc29 = "", string mDesc30 = "", string mDesc31 = "", string mDesc32 = "", string mDesc33 = "",
            string mDesc34 = "", string mDesc35 = "", string mUserID = "")
        {
            try
            {
                this.ClearErrors();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQLprocName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Comp1", comCode));
                cmd.Parameters.Add(new SqlParameter("@CallType", CallType));
                cmd.Parameters.Add("@Dxml01", SqlDbType.Xml).Value = (parmXml01 == null ? null : parmXml01.GetXml());
                cmd.Parameters.Add("@Dxml02", SqlDbType.Xml).Value = (parmXml02 == null ? null : parmXml02.GetXml());
                cmd.Parameters.Add(new SqlParameter("@Dbin01", parmbyte));
                cmd.Parameters.Add(new SqlParameter("@Desc1", mDesc1));
                cmd.Parameters.Add(new SqlParameter("@Desc2", mDesc2));
                cmd.Parameters.Add(new SqlParameter("@Desc3", mDesc3));
                cmd.Parameters.Add(new SqlParameter("@Desc4", mDesc4));
                cmd.Parameters.Add(new SqlParameter("@Desc5", mDesc5));
                cmd.Parameters.Add(new SqlParameter("@Desc6", mDesc6));
                cmd.Parameters.Add(new SqlParameter("@Desc7", mDesc7));
                cmd.Parameters.Add(new SqlParameter("@Desc8", mDesc8));
                cmd.Parameters.Add(new SqlParameter("@Desc9", mDesc9));
                cmd.Parameters.Add(new SqlParameter("@Desc10", mDesc10));
                cmd.Parameters.Add(new SqlParameter("@Desc11", mDesc11));
                cmd.Parameters.Add(new SqlParameter("@Desc12", mDesc12));
                cmd.Parameters.Add(new SqlParameter("@Desc13", mDesc13));
                cmd.Parameters.Add(new SqlParameter("@Desc14", mDesc14));
                cmd.Parameters.Add(new SqlParameter("@Desc15", mDesc15));
                cmd.Parameters.Add(new SqlParameter("@Desc16", mDesc16));
                cmd.Parameters.Add(new SqlParameter("@Desc17", mDesc17));
                cmd.Parameters.Add(new SqlParameter("@Desc18", mDesc18));
                cmd.Parameters.Add(new SqlParameter("@Desc19", mDesc19));
                cmd.Parameters.Add(new SqlParameter("@Desc20", mDesc20));
                cmd.Parameters.Add(new SqlParameter("@Desc21", mDesc21));
                cmd.Parameters.Add(new SqlParameter("@Desc22", mDesc22));
                cmd.Parameters.Add(new SqlParameter("@Desc23", mDesc23));
                cmd.Parameters.Add(new SqlParameter("@Desc24", mDesc24));
                cmd.Parameters.Add(new SqlParameter("@Desc25", mDesc25));
                cmd.Parameters.Add(new SqlParameter("@Desc26", mDesc26));
                cmd.Parameters.Add(new SqlParameter("@Desc27", mDesc27));
                cmd.Parameters.Add(new SqlParameter("@Desc28", mDesc28));
                cmd.Parameters.Add(new SqlParameter("@Desc29", mDesc29));
                cmd.Parameters.Add(new SqlParameter("@Desc30", mDesc30));
                cmd.Parameters.Add(new SqlParameter("@Desc31", mDesc31));
                cmd.Parameters.Add(new SqlParameter("@Desc32", mDesc32));
                cmd.Parameters.Add(new SqlParameter("@Desc33", mDesc33));
                cmd.Parameters.Add(new SqlParameter("@Desc34", mDesc34));
                cmd.Parameters.Add(new SqlParameter("@Desc35", mDesc35));
                cmd.Parameters.Add(new SqlParameter("@UserID", mUserID));
                bool _result = _dataAccess.ExecuteCommand(cmd);
                if (_result == false)  //_result==false
                {
                    this.SetError(_dataAccess.ErrorObject);
                }
                return _result;
            }
            catch (Exception exp)
            {
                this.SetError(exp);
                return false;
            }// try
        }

       
    }
}
