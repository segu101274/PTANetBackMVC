using System;

namespace ConsumirAPI.BE
{
    public class Country
    {
        public int idCountry { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
    }

    public class CountryMBA
    {
        public int idMba { get; set; }
        public int idCountry { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}

