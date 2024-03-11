using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Foiskolak;

namespace Foiskolak
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Foiskola> foiskolak = new List<Foiskola>();
            foiskolak = await foiskolaAdatok();
            foreach (Foiskola foiskola in foiskolak)
            {
                Console.WriteLine($"{foiskola.Name}");
            }
            await Console.Out.WriteLineAsync("Program vége");
            Console.ReadLine();

        }

        private static async Task<List<Foiskola>> foiskolaAdatok()
        {
            List<Foiskola> foiskolak = new List<Foiskola>();
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            HttpResponseMessage responseMessage = await client.GetAsync("http://universities.hipolabs.com/search?country=hungary");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();
                foiskolak = Foiskola.FromJson(jsonString).ToList(); ;
            }
            return foiskolak;
        }
    }
}
