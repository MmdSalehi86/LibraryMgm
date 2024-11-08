using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryMgm.DataAccess.ADO
{
    public class DbSqlCommands
    {
        private SqlConnection ConnectToDb()
        {
            SqlConnection con = new SqlConnection(Connections.Conn_LibMgmDb);
            con.Open();
            return con;
        }

        protected int ExcNonQueryProc(string proc, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            int result;
            using (cmd.Connection = ConnectToDb())
            {
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            return result;
        }

        protected T ExcScalarProc<T>(string proc, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            T result;
            using (cmd.Connection = ConnectToDb())
            {
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                result = (T)cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            return result;
        }

        protected SqlDataReader ExcReaderProc(string proc, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            SqlDataReader result;
            using (cmd.Connection = ConnectToDb())
            {
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteReader();
                //cmd.Connection.Close();
            }
            return result;
        }

        protected T ExcScalarFunc<T>(string funcName, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            string commandText = "select " + funcName + "(";
            if (ps != null)
            {
                foreach (var p in ps)
                {
                    cmd.Parameters.Add(p);
                    commandText += p.ParameterName + ",";
                }
            }
            T result;
            using (cmd.Connection = ConnectToDb())
            {
                commandText = commandText.Remove(commandText.Length - 1, 1);
                commandText += ")";
                cmd.CommandText = commandText;
                result = (T)cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            return result;
        }

        protected SqlDataReader ExcReaderFunc<T>(string funcName, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            string commandText = "select " + funcName + "(";
            if (ps != null)
            {
                foreach (var p in ps)
                {
                    cmd.Parameters.Add(p);
                    commandText += p.ParameterName + ",";
                }
            }
            SqlDataReader result;
            using (cmd.Connection = ConnectToDb())
            {
                commandText = commandText.Remove(commandText.Length - 1, 1);
                commandText += ")";
                cmd.CommandText = commandText;
                result = cmd.ExecuteReader();
                //cmd.Connection.Close();
            }
            return result;
        }

        protected int ExcNonQuerySql(string proc, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            int result;
            using (cmd.Connection = ConnectToDb())
            {
                cmd.CommandText = proc;
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            return result;
        }

        protected T ExcScalarSql<T>(string proc, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            T result;
            using (cmd.Connection = ConnectToDb())
            {
                cmd.CommandText = proc;
                result = (T)cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            return result;
        }

        protected SqlDataReader ExcReaderSql(string proc, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            SqlDataReader result;
            using (cmd.Connection = ConnectToDb())
            {
                cmd.CommandText = proc;
                result = cmd.ExecuteReader();
                //cmd.Connection.Close();
            }
            return result;
        }
    }
}
