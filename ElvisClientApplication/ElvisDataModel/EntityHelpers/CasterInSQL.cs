using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region STORED PROCEDURE -- ElvisGetTrend on PTCCINSQL
        /// <summary>
        /// DOES NOT use Entity Framework due to compatibility issues with SQL Server Versions.
        /// The PTCCINSQL Server is running an old version of SQL Server.  This conflicts
        /// with the current models running in the ElvisDataModel project, which is why we have decided
        /// to use the old method of getting data in this class.
        /// </summary>
        public static class ElvisGetTrend
        {
            private static string connectionString = ConfigurationManager.ConnectionStrings["PTCCINSQL"].ToString();

            public static DataTable GetByTagAndDate(string tag, DateTime startDate, DateTime endDate)
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(connectionString.ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("ElvisGetTrend", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tag", SqlDbType.VarChar, 50).Value = tag;
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime, 50).Value = startDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime, 50).Value = endDate;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0]; // Return the result of the stored procedure.
                }
                return new DataTable(); // Return blank data table if no data returned.
            }
        }
        #endregion
    }
}
