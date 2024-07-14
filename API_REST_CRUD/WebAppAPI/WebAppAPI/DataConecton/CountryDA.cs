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

        public String Registrar(Country obj)
        {
            string mensaje = "";
            using (SqlConnection cn = new ConexionDA().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegisterCountry", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@country", obj.country);
                    cmd.Parameters.AddWithValue("@countryCode", obj.countryCode);
                    cmd.CommandTimeout = 0;
                    Int32 resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                        mensaje = "Se procedio con el registro en la base de datos.";
                    else
                        mensaje = "Error: No se ha realizado el registro";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;

        }

        public String Actualizar(Country obj)
        {
            string mensaje = "";
            using (SqlConnection cn = new ConexionDA().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateCountry", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCountry", obj.idCountry);
                    cmd.Parameters.AddWithValue("@country", obj.country);
                    cmd.Parameters.AddWithValue("@countryCode", obj.countryCode);
                    cmd.CommandTimeout = 0;
                    Int32 resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                        mensaje = "Se actualizo el registro en la base de datos.";
                    else
                        mensaje = "Error: No se ha encontrado el registro para actualizar";
                   
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;

        }

        public String Eliminar(Int32 Id)
        {
            string mensaje = "";
            using (SqlConnection cn = new ConexionDA().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteCountry", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCountry", Id);
                    cmd.CommandTimeout = 0;
                    Int32 resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                        mensaje = "Se elimino el registro en la base de datos.";
                    else
                        mensaje = "Error: No se ha podido eliminar el registro";

                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;

        }
    }
}