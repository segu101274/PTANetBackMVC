using Microsoft.Data.SqlClient;
using System.Data;
using WebAppAPI.DataConecton;
using WebAppAPI.Models;

namespace WebAppAPI.DataConecton
{
    public class CountryDA
    {
        public IEnumerable<Country> listado()
        {
            List<Country> loCountry = new List<Country>();
            using (SqlConnection cn = new ConexionDA().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListAllCountry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    loCountry.Add(new Country()
                    {
                        idCountry = dr.GetInt32(0),
                        country = dr.GetString(1),
                        countryCode = dr.GetString(2),
                        fechaRegistro = dr.GetDateTime(3),
                    });
                }
            }
            return loCountry;
        }

        public Country Ubicar(Int32 Id)
        {
            Country oCountry = new Country();
            using (SqlConnection cn = new ConexionDA().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultCountryId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCountry", Id);
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oCountry = new Country()
                    {
                        idCountry = dr.GetInt32(0),
                        country = dr.GetString(1),
                        countryCode = dr.GetString(2),
                        fechaRegistro = dr.GetDateTime(3),
                    };
                }
            }
            return oCountry;
        }
    }
}