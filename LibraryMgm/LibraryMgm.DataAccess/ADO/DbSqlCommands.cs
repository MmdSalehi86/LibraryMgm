﻿using System;
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

        protected int ExcNonQueryProc(string proc, params SqlParameter[] ps)
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

        protected T ExcScalarProc<T>(string proc, params SqlParameter[] ps)
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

        protected SqlDataReader ExcReaderProc(string proc, params SqlParameter[] ps)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            cmd.Connection = ConnectToDb();
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteReader();
            //cmd.Connection.Close();
            return result;
        }

        protected T ExcScalarFunc<T>(string funcName, params SqlParameter[] ps)
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

        protected SqlDataReader ExcReaderFunc(string funcName, params SqlParameter[] ps)
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

            cmd.Connection = ConnectToDb();
            commandText = commandText.Remove(commandText.Length - 1, 1);
            commandText += ")";
            cmd.CommandText = commandText;
            var result = cmd.ExecuteReader();
            //cmd.Connection.Close();
            return result;
        }

        protected int ExcNonQuerySql(string proc, params SqlParameter[] ps)
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

        protected T ExcScalarSql<T>(string proc, params SqlParameter[] ps)
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

        protected SqlDataReader ExcReaderSql(string proc, params SqlParameter[] ps)
        {
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
                foreach (var p in ps)
                    cmd.Parameters.Add(p);

            cmd.Connection = ConnectToDb();
            cmd.CommandText = proc;
            var result = cmd.ExecuteReader();
            //cmd.Connection.Close();
            return result;
        }
    }
}
