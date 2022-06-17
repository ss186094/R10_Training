using System;
using System.Net.Http;

namespace HplusSport.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var discoverDocument= await client.GetDiscoveryDocumentAsync
            Console.WriteLine("Hello World!");
        }
    }
}
