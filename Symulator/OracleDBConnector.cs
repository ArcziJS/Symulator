using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class OracleDBConnector
    {
        static OracleConnection Connection = new OracleConnection();
        protected static void Connect()
        {
                string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1521)))(CONNECT_DATA=(Service_name=tpdb)));User ID=s101700;Password=s101700;";
                Connection.ConnectionString = connectionString;
                Connection.Open();
        }
                
        protected static OracleConnection GetConnection()
        {
            return Connection;
        }
    }
}
