using System.Collections.Generic;
using HospitalLibrary.DataConnections;
using System.Configuration;

namespace HospitalLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textFile)
        {
            if (database)
            {
                SqlConnection sql = new SqlConnection();
                Connections.Add(sql);
            }
            if (textFile)
            {
                TextConnection text = new TextConnection();
                Connections.Add(text);
            }
        }

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}