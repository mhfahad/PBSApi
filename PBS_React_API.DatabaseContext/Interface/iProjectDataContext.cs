using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.DatabaseContext.Interface
{
    public interface iProjectDataContext
    {
        Hashtable ErrorObject { get;}

        void SetError(Exception exp);
        void SetError(Hashtable errObject);
        void ClearErrors();


        DataSet GetTransInfo( string SQLprocName = "", string CallType = "", string mDesc1 = "", string mDesc2 = "",
     string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "", string mDesc7 = "", string mDesc8 = "", string mDesc9 = "", string mDesc10 = "", string mDesc11 = "");

        DataSet GetTransInfoXML(string comCode, string SQLprocName, string CallType, DataSet parmXml01 = null, DataSet parmXml02 = null, byte[] parmBin01 = null,
                  string mDesc1 = "", string mDesc2 = "", string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "", string mDesc7 = "", string mDesc8 = "",
                  string mDesc9 = "", string mDesc10 = "", string mDesc11 = "", string mDesc12 = "", string mDesc13 = "", string mDesc14 = "", string mDesc15 = "",
                  string mDesc16 = "", string mDesc17 = "", string mDesc18 = "", string mDesc19 = "", string mDesc20 = "", string @userid = "");
        bool UpdateTransInfo(string SQLprocName, string CallType,
             string mDesc1 = "", string mDesc2 = "", string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "",
             string mDesc7 = "", string mDesc8 = "", string mDesc9 = "", string mDesc10 = "");
        bool UpdateXmlTransInfo(string comCode, string SQLprocName, string CallType, DataSet parmXml01 = null, DataSet parmXml02 = null, byte[] parmbyte = null,
 string mDesc1 = "", string mDesc2 = "", string mDesc3 = "", string mDesc4 = "", string mDesc5 = "", string mDesc6 = "",
            string mDesc7 = "", string mDesc8 = "", string mDesc9 = "", string mDesc10 = "", string mDesc11 = "", string mDesc12 = "",
            string mDesc13 = "", string mDesc14 = "", string mDesc15 = "", string mDesc16 = "", string mDesc17 = "", string mDesc18 = "", string mDesc19 = "",
            string mDesc20 = "", string mDesc21 = "", string mDesc22 = "", string mDesc23 = "", string mDesc24 = "", string mDesc25 = "", string mDesc26 = "",
            string mDesc27 = "", string mDesc28 = "", string mDesc29 = "", string mDesc30 = "", string mDesc31 = "", string mDesc32 = "", string mDesc33 = "",
            string mDesc34 = "", string mDesc35 = "", string mUserID = "");

    }
}
