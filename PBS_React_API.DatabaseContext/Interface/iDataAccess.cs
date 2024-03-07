using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.DatabaseContext.Interface
{
    public interface iDataAccess
    {
        
         Hashtable ErrorObject{ get; }
       
        DataTable GetTable(string SQl);
        DataSet GetDataSet(String SQL);
        DataTable GetTable(SqlCommand Cmd);
        DataSet GetDataSet(SqlCommand Cmd);
        Boolean ExecuteCommand(string SQL);
        Boolean ExecuteCommand(SqlCommand cmd);
        SqlDataReader ExecuteReader(SqlCommand cmd);
        
    }
}
