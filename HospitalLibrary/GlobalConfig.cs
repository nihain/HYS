using HospitalLibrary.DataConnections;
using System.Configuration;

namespace HospitalLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; set; } = new SqlConnection();

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}