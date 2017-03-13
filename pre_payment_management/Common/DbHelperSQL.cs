using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using log4net;

namespace LXS.Common
{

    /// <summary>
    /// ���ݷ��ʳ��������
    /// Copyright (C) 2004-2008 Test
    /// All rights reserved	
    /// </summary>
    public class DbHelperSQL
    {
        //���ݿ������ַ���(web.config������)�����Զ�̬����connectionString        	

        //<add key="ConnectionString" value="server=127.0.0.1;database=DATABASE;uid=sa;pwd=" />	
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        //private static readonly ILog logger = LogManager.GetLogger(typeof(DbHelperSQL)); //д��־�ö���
        //���ܵ����
        //public static string connectionString = Mhywy.Common.DEncrypt.DESEncrypt.Decrypt(ConfigurationSettings.AppSettings["ConnectionString"]);

        public DbHelperSQL()
        {
        }
        /*
        #region XML-related method create by zk 2013-10-10

        /// <summary>
        /// write unid into e-HR database directly when complete create UNID ticket
        /// </summary>
        /// <param name="empNO"></param>
        /// <param name="unid"></param>
        /// <param name="unid_old"></param>
        /// <returns></returns>
        public static bool SyncUNIDtoEHR(string empNO, string unid, out string unid_old) {
            bool _result = false;
            unid_old = string.Empty;

            SqlParameter p_empNO = new SqlParameter("@empNO",SqlDbType.VarChar,20);
            SqlParameter p_unid = new SqlParameter("@unid", SqlDbType.VarChar,30);
            SqlParameter p_result = new SqlParameter("@result", SqlDbType.Bit);
            p_result.Direction = ParameterDirection.Output;
            SqlParameter p_unid_old = new SqlParameter("@unid_old", SqlDbType.VarChar, 30);
            p_unid_old.Direction = ParameterDirection.Output;

            SqlParameter[] p = { p_empNO, p_unid, p_result, p_unid_old };
            p[0].Value = empNO;
            p[1].Value = unid;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd= BuildQueryCommand(connection, "SyncUNIDtoEHR", p);
                cmd.ExecuteNonQuery();
                _result = cmd.Parameters["@result"].Value.ToString().ToUpper()== "TRUE" ? true : false;
                unid_old = cmd.Parameters["@unid_old"].Value.ToString();
                connection.Close();
            
            }

            logger.Debug("SyncUNIDtoEHR->Execute Procedure return " + _result.ToString() + "[empNO=" + empNO + ",unid=" + unid + ",unid_old=" + unid_old + "]");
            return _result;
        }
        public static System.Data.SqlTypes.SqlXml ConvertStringToXML(string xmlData)
        {
            System.Data.SqlTypes.SqlXml objData;
            try
            {
                objData = new System.Data.SqlTypes.SqlXml(new System.Xml.XmlTextReader(xmlData, System.Xml.XmlNodeType.Document, null));
            }
            catch
            {
                throw;
            }
            return objData;
        }

        /// <summary>
        /// get SYS_Group info from T_flow_Main.IP_Content_XML
        /// </summary>
        /// <param name="flowcode"></param>
        /// <param name="ipName">template_ID</param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        
        public static string GetXmlValueFromSQL(string flowcode, string ipName, string fieldName, bool flag_approver)
        {
            
            string iResult = string.Empty;
            SqlParameter[] p ={
            new SqlParameter("@FlowCode", SqlDbType.VarChar,15),
            new SqlParameter("@IpName", SqlDbType.VarChar,12),
            new SqlParameter("@FieldName", SqlDbType.VarChar,30)};
            p[0].Value = flowcode;
            p[1].Value = ipName;
            p[2].Value = fieldName;
            DataSet ds;
            if(flag_approver)
                ds = DbHelperSQL.RunProcedure("GetSysField", p, "table1");
            else
                ds= DbHelperSQL.RunProcedure("GetInfoByFileID2", p, "table1");
            
            if (WebCheck.DataSetCheck(ds))
            {
                iResult = ds.Tables[0].Rows[0][0].ToString();
                //logger.Debug("iResult=" + iResult);
            }
            else {
                logger.Debug("ds.tabel.row.count=" + ds.Tables[0].Rows.Count.ToString() + "@");
            }

            return iResult;
        }
        public static string GetXmlValueFromSQL(string flowcode, string ipName, string fieldName) {
            return GetXmlValueFromSQL(flowcode, ipName, fieldName, false);
        }

        public static string GetXmlValueFromSQL_interface(string flowcode, string ipName, string fieldName)
        {

            string iResult = string.Empty;
            SqlParameter[] p ={
            new SqlParameter("@FlowCode", SqlDbType.VarChar,15),
            new SqlParameter("@IpName", SqlDbType.VarChar,12),
            new SqlParameter("@FieldName", SqlDbType.VarChar,30)};
            p[0].Value = flowcode;
            p[1].Value = ipName;
            p[2].Value = fieldName;

            DataSet ds = DbHelperSQL.RunProcedure("GetInfoByFileID2b", p, "table1");

            if (WebCheck.DataSetCheck(ds))
            {
                iResult = ds.Tables[0].Rows[0][0].ToString();
                //logger.Debug("iResult=" + iResult);
            }
            else
            {
                logger.Debug("ds.tabel.row.count=" + ds.Tables[0].Rows.Count.ToString() + "@");
            }

            return iResult;
        }

        public static bool UpdateXmlValueFromSQL(string fileID, string IpName, string fieldName, string fieldValue)
        {
            bool iResult = false;

            SqlParameter[] p ={
            new SqlParameter("@FileID", SqlDbType.VarChar,12),
            new SqlParameter("@IpName", SqlDbType.VarChar,12),
            new SqlParameter("@fieldName", SqlDbType.VarChar,12),
            new SqlParameter("@fieldValue", SqlDbType.VarChar,30) };
            p[0].Value = fileID;
            p[1].Value = IpName;
            p[2].Value = fieldName;
            p[3].Value = fieldValue;

            int iRow = 0;
            DbHelperSQL.RunProcedure("UpdateIpField2", p, out iRow);
            if (iRow > 0)
                iResult = true;

            return iResult;

        }
        /// <summary>
        /// Update T_flow_main->IP_Content->simple field
        /// </summary>
        /// <param name="flowcode"></param>
        /// <param name="IpName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public static bool UpdateXmlValueFromSQL3(string flowcode, string IpName, string fieldName, string fieldValue)
        {
            bool iResult = false;

            SqlParameter[] p ={
            new SqlParameter("@FlowCode", SqlDbType.VarChar,15),
            new SqlParameter("@IpName", SqlDbType.VarChar,12),
            new SqlParameter("@fieldName", SqlDbType.VarChar,30),
            new SqlParameter("@fieldValue", SqlDbType.VarChar,250) };
            p[0].Value = flowcode;
            p[1].Value = IpName;
            p[2].Value = fieldName;
            p[3].Value = fieldValue;

            int iRow = 0;
            DbHelperSQL.RunProcedure("UpdateIpField2b", p, out iRow);
            if (iRow > 0)
                iResult = true;

            return iResult;

        }
        /// <summary>
        /// Update T_flow_main->IP_Content->gpAdmin
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="AccountID"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static bool UpdateXmlValueFromSQL2(string fileID, string IpName,string FieldName, string AccountID, string displayName)
        {
            bool iResult = false;

            SqlParameter[] p ={
            new SqlParameter("@FileID", SqlDbType.VarChar,12),
            new SqlParameter("@IpName", SqlDbType.VarChar,12),
            new SqlParameter("@FieldName", SqlDbType.VarChar,30),
            new SqlParameter("@AccountID", SqlDbType.VarChar,30),
            new SqlParameter("@DisplayName", SqlDbType.VarChar,250) };
            p[0].Value = fileID;
            p[1].Value = IpName;
            p[2].Value = FieldName;
            p[3].Value = AccountID;
            p[4].Value = displayName;

            int iRow = 0;
            DbHelperSQL.RunProcedure("UpdateIpApprover2", p, out iRow);
            if (iRow > 0)
                iResult = true;

            return iResult;

        }

        /// <summary>
        /// ȡ�ķ�����ʱ��
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTime()
        {
            return System.DateTime.Now;
        }

        #endregion
        */
        #region ���÷���

        public static int GetMaxID(string FieldName, string TableName)
        {
            //string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            string strsql = "select max(right(" + FieldName + ",4)) from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static string GetMaxID2(string FieldName, string TableName) {
            string strsql = "select max(right(" + FieldName + ",4)) from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }

        public static int GetMaxLogID(string FieldName, string TableName) {
            string strsql = "select max(right(" + FieldName + ",6)) from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        
        public static bool Exists(string strSql)
        {
            object obj = DbHelperSQL.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = DbHelperSQL.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  ִ�м�SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">����SQL���</param>		
        public static bool ExecuteSqlTran(ArrayList SQLStringList)
        {
            bool iResult = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    iResult = true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                return iResult;
            }
        }
        /// <summary>
        /// ִ�д�һ���洢���̲����ĵ�SQL��䡣
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// ִ�д�һ���洢���̲����ĵ�SQL��䡣
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// �����ݿ������ͼ���ʽ���ֶ�(������������Ƶ���һ��ʵ��)
        /// </summary>
        /// <param name="strSQL">SQL���</param>
        /// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺ʹ�ú�һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }
        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }



        #endregion

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //ѭ��
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺ʹ�ú�һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region �洢���̲���

        /// <summary>
        /// ִ�д洢���� ( ע�⣺ʹ�ú�һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader returnReader;
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                returnReader = command.ExecuteReader();
                return returnReader;
            }
        }


        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }


        /// <summary>
        /// ���� SqlCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // ���δ����ֵ���������,���������DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������		
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="rowsAffected">Ӱ�������</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// ���� SqlCommand ����ʵ��(��������һ������ֵ)	
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand ����ʵ��</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

    }
}

