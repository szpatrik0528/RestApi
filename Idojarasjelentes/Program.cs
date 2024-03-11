using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Idojaras;

namespace Idojaras
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Ido> idojaras = new List<Ido>();
            idojaras = await IdojarasAdatok();
            Console.WriteLine($" {idojaras[0].data["city"]} - {idojaras[0].data["insight_heading"]} - {idojaras[0].data["insight_description"]}  - {idojaras[0].data["wind"]}  - {idojaras[0].data["humidity"]}  - {idojaras[0].data["visibility"]}  - {idojaras[0].data["last_update"]}");

            await Console.Out.WriteLineAsync("Program vége");
            Console.ReadLine();
        }

        private static async Task<List<Ido>> IdojarasAdatok()
        {
            List<Ido> idojaras = new List<Ido>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://the-weather-api.p.rapidapi.com/api/weather/Budapest");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                idojaras.Add(Ido.FromJson(jsonString));

            }
            return idojaras;
        }
    }
}