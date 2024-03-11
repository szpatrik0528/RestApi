using Iranyitoszam;
using System;
using System.Net.Http;

internal static class ProgramHelpers
{
    private static async string Irszam(string irszam)
    {
        string url = $"http://api.zippopotam.us/hu/{irszam}";
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string jsonString = await response.Content.ReadAsStringAsync();
        var postCode = PostCode.FromJson(jsonString);
        return postCode.Places[0].PlaceName;
    }
    static void Main(string[] args)
    {
        Irszam("4220");
        Console.WriteLine("vége");
        Console.ReadLine();
    }
}