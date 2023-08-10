using CrudTest.Models;
using System.Data;
using System.Data.SqlClient;

 namespace CrudTest.DataAccess;
    public static class SQLDAL
    {

        public static string ConnectionString { get; } = AppConst.ConnectionString;
        
        #region Private Members
        private static SqlConnection ReturnCon()
        {
            return new SqlConnection(ConnectionString);
        }
        private static SqlCommand ReturnSqlCmd(string SqlText, SqlConnection Con, bool IsStoredProcedue)
        {
            SqlCommand cmd = new SqlCommand(SqlText, Con);
            if (IsStoredProcedue)
                cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 10000;
            return cmd;
        }
        private static void OpenCon(SqlConnection Con)
        {
            if (Con.State != ConnectionState.Open)
                Con.Open();
        }
        private static void CloseCon(SqlConnection Con)
        {

            Con.Close();
        }
        private static SqlParameter[] ReturnSqlParametersArray(string[] ParametersNames, object[] ParametersValues)
        {

            SqlParameter[] Arr = new SqlParameter[] { };
            for (int i = 0; i < ParametersNames.Length; i++)
                Arr[i] = new SqlParameter(ParametersNames[i], ParametersValues[i]);
            return Arr;
        }
        #endregion

        #region Private (But Can Be Public & Callable) Members
        private enum CallType
        {
            NonQuery,
            Scalar,
            Reader,
        }
        private static object CallByProcedure(CallType CallType, string SqlText, params SqlParameter[] Parameters)
        {
            return CoreCall(CallType, SqlText, true, Parameters);
        }
        private static object CallByText(CallType CallType, string SqlText)
        {
            return CoreCall(CallType, SqlText, false);
        }
        private static object CoreCall(CallType CallType, string SqlText, bool IsStoredProcedue, params SqlParameter[] Parameters)
        {
            SqlConnection Con = ReturnCon();
            SqlCommand cmd = ReturnSqlCmd(SqlText, Con, IsStoredProcedue);
            if (Parameters != null && Parameters.Length > 0)
                cmd.Parameters.AddRange(Parameters);
            OpenCon(Con);
            try
            {
                switch (CallType)
                {
                    case CallType.NonQuery: return cmd.ExecuteNonQuery();
                    case CallType.Scalar: return cmd.ExecuteScalar();
                    case CallType.Reader: DataTable DT = new DataTable(); DT.Load(cmd.ExecuteReader()); return DT;
                    default: return null;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Parameters.Clear(); CloseCon(Con); }
        }
        #endregion

        #region VoidByProcedure
        public static void VoidByProcedure(string ProcedureName)
        {
            CallByProcedure(CallType.NonQuery, ProcedureName);
        }
        public static void VoidByProcedure(string ProcedureName, List<SqlParameter> Parameters)
        {
            CallByProcedure(CallType.NonQuery, ProcedureName, Parameters.ToArray());
        }
        public static void VoidByProcedure(string ProcedureName, params SqlParameter[] Parameters)
        {
            CallByProcedure(CallType.NonQuery, ProcedureName, Parameters);
        }
        #endregion

        #region ReturnScalarByProcedure
        public static object ReturnScalarByProcedure(string ProcedureName)
        {
            return CallByProcedure(CallType.Scalar, ProcedureName);
        }
        public static object ReturnScalarByProcedure(string ProcedureName, List<SqlParameter> Parameters)
        {
            return CallByProcedure(CallType.Scalar, ProcedureName, Parameters.ToArray());
        }
        public static object ReturnScalarByProcedure(string ProcedureName, params SqlParameter[] Parameters)
        {
            return CallByProcedure(CallType.Scalar, ProcedureName, Parameters);
        }
        #endregion

        #region ReturnDataTableByProcedure
        public static DataTable ReturnDataTableByProcedure(string ProcedureName)
        {
            return (DataTable)CallByProcedure(CallType.Reader, ProcedureName);
        }
        public static DataTable ReturnDataTableByProcedure(string ProcedureName, List<SqlParameter> Parameters)
        {
            return (DataTable)CallByProcedure(CallType.Reader, ProcedureName, Parameters.ToArray());
        }
        public static DataTable ReturnDataTableByProcedure(string ProcedureName, params SqlParameter[] Parameters)
        {
            return (DataTable)CallByProcedure(CallType.Reader, ProcedureName, Parameters);
        }
        #endregion

        #region BySqlText
        public static void VoidByCommand(string SqlText)
        {
            CallByText(CallType.NonQuery, SqlText);
        }
        public static object ReturnScalarByCommand(string SqlText)
        {
            return CallByText(CallType.Scalar, SqlText);
        }
        public static DataTable ReturnDataTableByCommand(string SqlText)
        {
            return (DataTable)CallByText(CallType.Reader, SqlText);
        }
        #endregion

        #region Add Parameter Methods
        public static SqlParameter AddParameter(string parameterName, object value)
        {
            SqlParameter dbParameter = new SqlParameter();
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value == null ? DBNull.Value : value;
            return dbParameter;
        }

        public static SqlParameter AddParameter(string parameterName, DbType type, object value)
        {
            SqlParameter dbParameter = AddParameter(parameterName, value);
            dbParameter.DbType = type;
            return dbParameter;
        }

        public static SqlParameter AddParameter(string parameterName, DbType type, int size, object value)
        {
            SqlParameter dbParameter = AddParameter(parameterName, type, value);
            dbParameter.Size = size;
            return dbParameter;
        }

        public static SqlParameter AddParameter(string parameterName, DbType type, int size, ParameterDirection Direction, object value)
        {
            SqlParameter dbParameter = AddParameter(parameterName, type, size, value);
            dbParameter.Direction = Direction;
            return dbParameter;
        }

        public static List<SqlParameter> CreateSqlParams( params (string name, object value)[] sqlParams)
        {
            var param = new List<SqlParameter>();
            foreach (var sqlParam in sqlParams)
                param.Add(new SqlParameter(sqlParam.name, sqlParam.value));

            return param;
            
        }
    #endregion

         
        public static void BulkInsert(DataTable dt, string DBTableName = null)
        {
            SqlConnection Con = ReturnCon();
            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(Con, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);

                foreach (DataColumn column in dt.Columns)
                {
                    SqlBulkCopyColumnMapping ColumnMapping = new SqlBulkCopyColumnMapping(column.ColumnName, column.ColumnName);
                    bulkCopy.ColumnMappings.Add(ColumnMapping);
                }

                bulkCopy.DestinationTableName = string.IsNullOrEmpty(DBTableName) ? dt.TableName : DBTableName;
                bulkCopy.BulkCopyTimeout = 10000;
                OpenCon(Con);
                bulkCopy.WriteToServer(dt);
            }
            catch (Exception ex) { throw ex; }
            finally { CloseCon(Con); }
        }
    }

