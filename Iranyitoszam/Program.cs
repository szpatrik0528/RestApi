using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Iranyitoszam
{
    internal class Program
    {
        static PostCode postcode;
        static void Main(string[] args)
        {
            irszam("4220");
            Console.WriteLine($"{postcode.Places[0].PlaceName}");
            Console.WriteLine("vége");
            Console.ReadLine();
        }
        private static async void irszam(string irszam)
        {
            string url = $"http://api.zippopotam.us/hu/{irszam}";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            postcode = PostCode.FromJson(jsonString);
        }
    }
}
