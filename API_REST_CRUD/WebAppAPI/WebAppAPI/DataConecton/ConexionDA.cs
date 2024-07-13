using Microsoft.Data.SqlClient;
namespace WebAppAPI.DataConecton
{
    public class ConexionDA
    {
        SqlConnection cn = new SqlConnection(@"Data Source=localhost, 1433;Initial Catalog=Test;User=sa;Password=*123Test*;" +
           "MultipleActiveResultSets = True;TrustServerCertificate= False;Encrypt= False");
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}


