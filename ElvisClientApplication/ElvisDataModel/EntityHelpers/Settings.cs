using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using ElvisDataModel.Properties;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        /// <summary>
        /// Contains Elvis Database Settings for the Application.
        /// </summary>
        public static class ElvisDBSettings
        {
            //private static string liveDBConnectionString = "metadata=res://*/;provider=System.Data.SqlClient;provider connection string=&quot;data source=PTCCL3SQL.porttalbot.pcswales.corusgroup.com;initial catalog=ElvisDB;persist security info=True;user id=ElvisClient;password=clientpwd;multipleactiveresultsets=True;App=EntityFramework&quot;";
            //private static string testDBConnectionString = "metadata=res://*/;provider=System.Data.SqlClient;provider connection string=&quot;data source=PTSSELVISTEST.porttalbot.pcswales.corusgroup.com;initial catalog=elvisdb;persist security info=True;user id=ElvisClient;password=clientpwd;multipleactiveresultsets=True;App=EntityFramework&quot;";
            private static string liveDBConnectionString;
            private static string testDBConnectionString;

            public static string ConnectionString
            {
                get
                {
                    if (Settings.Default.IsLiveDatabase)
                    {
                        if (string.IsNullOrEmpty(liveDBConnectionString))
                        {
                            liveDBConnectionString = BuildLiveConnection();
                        }
                        return liveDBConnectionString;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(testDBConnectionString))
                        {
                            testDBConnectionString = BuildTestConnection();
                        }
                        return testDBConnectionString;
                    }
                }
            }

            /// <summary>
            /// Used for testing purposes only.
            /// </summary>
            public static string LiveConnectionString
            {
                get
                {
                    if (string.IsNullOrEmpty(liveDBConnectionString))
                    {
                        liveDBConnectionString = BuildLiveConnection();
                    }
                    return liveDBConnectionString;
                }
            }

            private static string BuildTestConnection()
            {
                // Specify the provider name, server and database.
                string providerName = "System.Data.SqlClient";
                string serverName = @"CPLAPTOP\MSSQLSERVER01";
                string databaseName = "elvisdb";

                // Initialize the connection string builder for the
                // underlying provider.
                SqlConnectionStringBuilder sqlBuilder =
                    new SqlConnectionStringBuilder();

                // Set the properties for the data source.
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                //sqlBuilder.UserID = "ElvisClient";
                //sqlBuilder.Password = "clientpwd";
                sqlBuilder.IntegratedSecurity = true;

                // Build the SqlConnection connection string.
                string providerString = sqlBuilder.ToString();

                // Initialize the EntityConnectionStringBuilder.
                EntityConnectionStringBuilder entityBuilder =
                    new EntityConnectionStringBuilder();

                //Set the provider name.
                entityBuilder.Provider = providerName;

                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = providerString;

                // Set the Metadata location.
                entityBuilder.Metadata = @"res://*/";
                return entityBuilder.ToString();
            }

            private static string BuildLiveConnection()
            {
                // Specify the provider name, server and database.
                string providerName = "System.Data.SqlClient";
                string serverName = @"CPLAPTOP\MSSQLSERVER01";
                string databaseName = "ElvisDB";

                // Initialize the connection string builder for the
                // underlying provider.
                SqlConnectionStringBuilder sqlBuilder =
                    new SqlConnectionStringBuilder();

                // Set the properties for the data source.
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                //sqlBuilder.UserID = "ElvisClient";
                //sqlBuilder.Password = "clientpwd";
                sqlBuilder.IntegratedSecurity = true;

                // Build the SqlConnection connection string.
                string providerString = sqlBuilder.ToString();

                // Initialize the EntityConnectionStringBuilder.
                EntityConnectionStringBuilder entityBuilder =
                    new EntityConnectionStringBuilder();

                //Set the provider name.
                entityBuilder.Provider = providerName;

                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = providerString;

                // Set the Metadata location.
                entityBuilder.Metadata = @"res://*/";
                return entityBuilder.ToString();
            }

        }
    }
}
