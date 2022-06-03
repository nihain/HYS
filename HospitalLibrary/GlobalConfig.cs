using HospitalLibrary.DataConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textFile)
        {
            if (database)
            {
                // TODO: Set up the SQL Connector properly
                SqlConnection sql = new SqlConnection();
                Connections.Add(sql);
            }
            if (textFile)
            {
                // TODO: Create text file connection
                TextConnection text = new TextConnection();
                Connections.Add(text);
            }
        }
    }
}
