using Microsoft.Graph;
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
    public class DataAccess : iDataAccess
    {
        public SqlConnection m_Conn;
        private Hashtable m_Erroobj;
        //public string DBConnstr = "Data Source=AST05\\MSSQLSVR2K5;initial Catalog=ASTSOFTDB;Integrated Security=SSPI";
        public string DBConnstr = "Data Source=172.16.1.152;Initial Catalog=ECO;Persist Security Info=True;User ID=sa;Password=sa*1209";
        public DataAccess()
        {
            m_Conn = new SqlConnection(this.DBConnstr);
            m_Erroobj = new Hashtable();
        }

        public DataAccess(string mDBName)
        {
            m_Conn = new SqlConnection(this.DBConnstr);
            m_Conn.ConnectionString = m_Conn.ConnectionString.Replace("ECO", mDBName );

        }

        
        public Hashtable ErrorObject
        {
            get
            {
                return this.m_Erroobj;
            }
        }
        public DataTable GetTable(string SQl)
        {
            //for string : have to edit with proper code
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0];
            }

            catch (Exception ex)
            {
                this.SetError(ex);
                return null;
            }
        }
        public DataSet GetDataSet(String SQL)
        {
            //for string : have to edit with proper code
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter(SQL, this.m_Conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                this.SetError(ex);
                return null;
            }
        }
        public DataTable GetTable(SqlCommand Cmd)
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = Cmd;
                Cmd.Connection = this.m_Conn;
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                this.SetError(ex);
                return null;
            }
        }
        public DataSet GetDataSet(SqlCommand Cmd)
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = Cmd;

                Cmd.CommandTimeout = 120;
                Cmd.Connection = this.m_Conn;
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                this.SetError(ex);
                return null;
            }
        }
        
        public Boolean ExecuteCommand(string SQL)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = this.m_Conn;

            try
            {
                this.m_Conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);
                return false;
            }
            finally
            {
                this.m_Conn.Close();
            }
        }


        public Boolean ExecuteCommand(SqlCommand cmd)
        {
            cmd.Connection = this.m_Conn;
            try
            {
                this.m_Conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);
                return false;
            }
            finally
            {
                this.m_Conn.Close();
            }
        }
        public SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            cmd.Connection = this.m_Conn;
            cmd.CommandTimeout = 120;
            try
            {
                this.m_Conn.Close();
                this.m_Conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                this.SetError(ex);
                return null;
            }

        }
        public void SetError(Exception ex)
        {
            this.m_Erroobj["Src"] = ex.Source;
            this.m_Erroobj["Msg"] = ex.Message;
            this.m_Erroobj["Location"] = ex.StackTrace;
        }
    }
}
