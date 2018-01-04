using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VANHACK_Forum_Project.Model
{
    public class DB
    {
        // string ConStr_Prn = ConfigurationManager.ConnectionStrings["DB2CONN_PRN"].ConnectionString;
        //public string get_ConStr_Prn()
        //{
        //    return ConStr_Prn;
        //}
        public string ConStr_fix = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string ConStr_fix_Ded = ConfigurationManager.ConnectionStrings["DB2CONN2"].ConnectionString;
        public string get_ConStr_fix()
        {
            return ConStr_fix;
        }



        //public int int_ExecuteNonQuery_Prn(string sql)
        //{
        //    int ReturnValue = 0;
        //    try
        //    {
        //        OdbcConnection con = new OdbcConnection(ConStr_Prn);
        //        OdbcCommand cmd = new OdbcCommand(sql, con);
        //        con.Open();
        //        ReturnValue = cmd.ExecuteNonQuery();
        //        con.Close();
        //        cmd = null;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        //Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
        //    }
        //    return ReturnValue;
        //}
        public int int_ExecuteScalar(SqlCommand cmd)
        {
            int ReturnValue = 0;
            try
            {
                object ScalarValue = null;
                SqlConnection con = new SqlConnection(ConStr_fix);
                 cmd.Connection = con;
                con.Open();
                ScalarValue = cmd.ExecuteScalar();
                ReturnValue = (ScalarValue == null ? 0 : (ScalarValue == System.DBNull.Value ? 0 : Convert.ToInt32(ScalarValue)));
                con.Close();
                cmd = null;
            }
            catch (System.Exception ex)
            {
                //Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }
            return ReturnValue;
        }
        public string string_ExecuteScalar(string sql)
        {
            string ReturnValue = "";
            try
            {
                object ScalarValue = null;
                OdbcConnection con = new OdbcConnection(ConStr_fix);
                OdbcCommand cmd = new OdbcCommand(sql, con);
                con.Open();
                ScalarValue = cmd.ExecuteScalar();
                ReturnValue = (ScalarValue == null ? "" : (ScalarValue == System.DBNull.Value ? "" : ScalarValue.ToString()));
                con.Close();
                cmd = null;
            }
            catch (System.Exception ex)
            {
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                //Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }
            return ReturnValue;
        }

        public  string string_ExecuteScalar(OdbcCommand cmd)
        {
            string ReturnValue = "";
            try
            {
                object ScalarValue = null;
                OdbcConnection con = new OdbcConnection(ConStr_fix);
                cmd.Connection = con;
                con.Open();
                ScalarValue = cmd.ExecuteScalar();
                ReturnValue = (ScalarValue == null ? "" : (ScalarValue == System.DBNull.Value ? "" : ScalarValue.ToString()));
                con.Close();
                cmd = null;
            }
            catch (System.Exception ex)
            {
                //Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }
            return ReturnValue;
        }


        public DataSet string_DataSet_fix(string sql)
        {
            DataSet ReturnValue = new DataSet();
            try
            {
                OdbcConnection con = new OdbcConnection(ConStr_fix);
                OdbcDataAdapter x = new OdbcDataAdapter(sql, con);
                x.Fill(ReturnValue);
            }
            catch (System.Exception ex)
            {
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                ////Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }
            return ReturnValue;
        }
        public  DataTable string_DataTable_fix(string sql)
        {
            DataTable ReturnValue = new DataTable();
            try
            {
                OdbcConnection con = new OdbcConnection(ConStr_fix);
                OdbcDataAdapter x = new OdbcDataAdapter(sql, con);
                x.Fill(ReturnValue);
            }
            catch (System.Exception ex)
            {
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                ////Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }
            return ReturnValue;
        }



        public int int_ExecuteNonQuery_Odbc(SqlCommand OdCmd)
        {
            SqlConnection con = new SqlConnection(ConStr_fix);
            int ReturnValue = 0;
            try
            {


                OdCmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                ReturnValue = OdCmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();
                OdCmd = null;
            }
            catch (Exception ex)
            {
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                //Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }

            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                con.Dispose();
            }

            return ReturnValue;
        }
        public int int_ExecuteNonQuery_Odbc(string sql)
        {
            OdbcConnection con = new OdbcConnection(ConStr_fix);
            int ReturnValue = 0;
            try
            {

                OdbcCommand cmd = new OdbcCommand(sql, con);
                if (con.State != ConnectionState.Open)
                    con.Open();

                ReturnValue = cmd.ExecuteNonQuery();
                cmd = null;
            }
            catch (System.Exception ex)
            {
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                ////myLog.Error(ex);
                //////Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }

            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                con.Dispose();
            }

            return ReturnValue;
        }
        public DataTable string_DataTable_fix(SqlCommand  Cmd)
        {
            SqlConnection con = new SqlConnection(ConStr_fix);
            DataTable ReturnValue = new DataTable();
            try
            {

                Cmd.Connection = con;
                SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                SqlCommandBuilder b = new SqlCommandBuilder(adapter);
                adapter.Fill(ReturnValue);
            }
            catch (Exception ex)
            {
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);
                ////Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
            }

            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                con.Dispose();
            }

            return ReturnValue;
        }
        public DataTable string_DataTable_fix_Ded(OdbcCommand OdCmd)
        {
            OdbcConnection con = new OdbcConnection(ConStr_fix);
            DataTable ReturnValue = new DataTable();
            try
            {

                OdCmd.Connection = con;
                OdbcDataAdapter adapter = new OdbcDataAdapter(OdCmd);
                OdbcCommandBuilder b = new OdbcCommandBuilder(adapter);
                adapter.Fill(ReturnValue);
            }
            catch (Exception ex)
            {
                //NLogLogger MontrFinFileLog = new NLogLogger();
                //MontrFinFileLog.Error(ex);

            }

            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                con.Dispose();
            }

            return ReturnValue;
        }
        //public DataSet string_DataSet_PRN(string sql)
        //{
        //    DataSet ReturnValue = new DataSet();
        //    try
        //    {
        //        OdbcConnection con = new OdbcConnection(ConStr_Prn);
        //        OdbcDataAdapter x = new OdbcDataAdapter(sql, con);
        //        x.Fill(ReturnValue);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        //Response.Redirect("Error.aspx?ex=" + ex.Message.ToString());
        //    }
        //    return ReturnValue;
        //}
    }
}