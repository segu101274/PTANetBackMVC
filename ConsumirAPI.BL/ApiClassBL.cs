using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumirAPI.DA;
using ConsumirAPI.BE;
using UtilitariosConexionDA.Base;
using Newtonsoft.Json.Linq;

namespace ConsumirAPI.BL
{
    public class ApiClassBL
    {
        ApiClassDA oApiClassDA;

        public string LeerJson(dynamic json)
        {
            Int32 regEncontrados = 0;
            Int32 regGrabados = 0;
            Int32 idCountry = 0;
            Int32 idMba = 0;
            Country oCountry;
            CountryMBA oCountryMBA;
            string mensaje = "";

            try
            {
                foreach (var oCab in json)
                {
                    oCountry = new Country();
                    oCountry.country = oCab.country;
                    oCountry.countryCode = oCab.countryCode;
                    regEncontrados++;

                    idCountry = RegistrarLecturaCabApi(oCountry);

                    if (idCountry > 0)
                    {
                        regGrabados++;
                        foreach (var oDet in oCab.mbas)
                        {
                            oCountryMBA = new CountryMBA();
                            oCountryMBA.name = oDet.name;
                            oCountryMBA.code = oDet.code;
                            idMba = RegistrarLecturaDetApi(oCountryMBA, idCountry);
                        }
                    }
                }
                mensaje = "-- Los registros obtenidos desde el Api son: " + regEncontrados.ToString() + '\n' +
                          "-- Los regisros almacenados en la BD son: " + regGrabados.ToString();
                          
            }
            catch (Exception ex)
            {
                mensaje = "Se presento un error en el proceso:  " + ex.Message;
            }
            return mensaje;
        }

        private int RegistrarLecturaCabApi(Country obj)
        {
            oApiClassDA = new ApiClassDA();
            return oApiClassDA.RegistrarLecturaCabApi(obj); 
        }

        private int RegistrarLecturaDetApi(CountryMBA obj, Int32 id)
        {
            oApiClassDA = new ApiClassDA();
            return oApiClassDA.RegistrarLecturaDetApi(obj, id);
        }
    }
}
