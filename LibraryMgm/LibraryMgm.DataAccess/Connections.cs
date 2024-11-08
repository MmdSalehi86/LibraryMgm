using System.Configuration;

namespace LibraryMgm.DataAccess
{
    public class Connections
    {
        public static string Conn_LibMgmDb { get
            {
                return ConfigurationManager.ConnectionStrings["Conn_LibMgmDb"].ConnectionString;
            }
        }
    }
}
