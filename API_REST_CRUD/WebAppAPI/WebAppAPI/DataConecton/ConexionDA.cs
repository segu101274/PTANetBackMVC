using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
namespace WebAppAPI.DataConecton
{
    
    public class ConexionDA
    {
        SqlConnection cn = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        //SqlConnection cn = new SqlConnection("Server=192.168.1.51, 1433;Initial Catalog=Test;User=sa;Password=*123Test*; MultipleActiveResultSets = True;TrustServerCertificate= False;Encrypt= False");

        public SqlConnection getcn
        {
            get { return cn; }
        }

    }
}


