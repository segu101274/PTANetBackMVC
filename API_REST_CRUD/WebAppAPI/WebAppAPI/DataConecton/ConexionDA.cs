using Microsoft.Data.SqlClient;
namespace WebAppAPI.DataConecton
{
    
    public class ConexionDA
    {

        SqlConnection cn = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));

        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}


