using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace IISConfiger
{
    public class SqlHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["CloudConnectionString"].ConnectionString;

        public static DataTable GetCompanies()
        {
            string sql = "select CompanyId,CompanyName,CompanyUrl from CM_Company where CompanyUrl like '%http://www%'";
            DataTable table = GetDataTable(sql);
            return table;
        }

        public static DataTable GetFinishedStaticizeLogs()
        {
            string sql = "select CompanyId,Url from SYS_LogBack where Url!='0' and Status!=2 order by ID Desc";
            DataTable table = GetDataTable(sql);
            return table;
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExcuteSql(string sql)
        {
            var connStr = connectionString;
            using (var connection = new SqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    var cmd = new SqlCommand(sql, connection);
                    var i = cmd.ExecuteNonQuery();
                    return i;
                }
                catch (Exception e)
                {
                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExcuteScalarSql(string sql)
        {
            var connStr = connectionString;
            using (var connection = new SqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    var cmd = new SqlCommand(sql, connection);
                    var i = cmd.ExecuteScalar();
                    return i;
                }
                catch (Exception e)
                {
                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 根据sql获取表集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            string connStr = connectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(sql, connection);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    return Dt;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
