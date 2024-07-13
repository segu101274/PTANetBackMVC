using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ConsumirAPI.BL;
using System.Configuration;


namespace ConsoleConsumirAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string urlApi = ConfigurationManager.AppSettings["Api"];
            ApiClassBL oApiClassBL = new ApiClassBL();
            string mensaje = "";
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    var response = client.GetAsync(urlApi).Result;
                    var res = response.Content.ReadAsStringAsync().Result;
                    dynamic json = JArray.Parse(res);

                    mensaje = oApiClassBL.LeerJson(json);
                }
                Console.WriteLine(mensaje);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Pulsar una tecla para salir ....");
            Console.Read();
        }
    }
}
