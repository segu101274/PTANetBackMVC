using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UtilitariosConexionDA.Base;
using ConsumirAPI.BE;

namespace ConsumirAPI.DA
{
    public class ApiClassDA : BaseDalcSql
    {
        public int RegistrarLecturaCabApi(Country obj)
        {
            AbrirConexionPrincipal();
            var cmd = ObtenerCommand("sp_registrarConsultaApiCab");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@country", obj.country);
            cmd.Parameters.AddWithValue("@countryCode", obj.countryCode);
            cmd.CommandTimeout = 0;
            var dr = cmd.ExecuteScalar();
            Int32 idContry = Convert.ToInt32(dr);
            CerrarConexion();
            return idContry;
        }

        public int RegistrarLecturaDetApi(CountryMBA obj, Int32 id)
        {
            AbrirConexionPrincipal();
            var cmd = ObtenerCommand("sp_registrarConsultaApiDet");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@code", obj.code);
            cmd.Parameters.AddWithValue("@idCountry", id);
            cmd.CommandTimeout = 0;
            var dr = cmd.ExecuteScalar();
            Int32 idMba = Convert.ToInt32(dr);
            CerrarConexion();
            return idMba;
        }
    }
}
