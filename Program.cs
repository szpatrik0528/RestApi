using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ValutaValto;

namespace ValutaValto
{
    internal class Program
    {
        static List<Valuts> valutak = new List<Valuts>();

        static async Task Main(string[] args)
        {

            await valutaAdatok();
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("Üdvözöllek a Valutaváltóban \n\nKérlek válassz az alábbi lehetőségek közül, hogy milyen pénznemet szeretnél átváltani:\n\n");
            Console.WriteLine("1.Forint \n2.USA Dollár \n3.AED \n4.BOB ");

            string valasztas1 = Console.ReadLine();
            string penz1 = "";

            switch (valasztas1)
            {
                case "1":
                    penz1 = "HUF";
                    break;
                case "2":
                    penz1 = "USD";
                    break;
                case "3":
                    penz1 = "AED";
                    break;
                case "4":
                    penz1 = "BOB";
                    break;

                default:
                    penz1 = "HUF";
                    break;
            }
            Console.Clear();
            Console.WriteLine("És most, hogy milyen pénznemre szeretnél átváltani:\n\n");
            Console.WriteLine("1.Forint \n2.USA Dollár \n3.AED \n4.BOB ");
            string valasztas2 = Console.ReadLine();
            string penz2 = "";
            switch (valasztas2)
            {
                case "1":
                    penz2 = "HUF";
                    break;
                case "2":
                    penz2 = "USD";
                    break;
                case "3":
                    penz2 = "AED";
                    break;
                case "4":
                    penz2 = "BOB";
                    break;

                default:
                    penz2 = "HUF";
                    break;
            }
            szamolas(penz1, penz2);
        }

        private static void szamolas(string penz1, string penz2)
        {



            Console.WriteLine("Írj be egy összeget amit szeretnél átváltani a másik pénznembe");


            string penzosszeg = Console.ReadLine();
            try
            {
                int numVal1 = Int32.Parse(penzosszeg);
                Console.WriteLine($"{numVal1} {penz1} az {Math.Round((numVal1 / valutak[0].Rates[penz1]) * valutak[0].Rates[penz2], 2)} {penz2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Nyomja le az 'esc' billentyűt a kilépéshez vagy bármelyik gombot az újrakezdéshez");
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Menu();
            }
        }

        private static async Task valutaAdatok()
        {
            // List<Valuts> valutak = new List<Valuts>();
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            HttpResponseMessage responseMessage = await client.GetAsync("http://infojegyzet.hu/webszerkesztes/php/valuta/api/v1/arfolyam/");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();
                valutak.Add(Valuts.FromJson(jsonString));
            }
        }
    }
}