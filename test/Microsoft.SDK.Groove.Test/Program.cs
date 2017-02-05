using Microsoft.SDK.Groove.Client;
using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args) => Task.Run(async () => await MainAsync(args)).Wait();

    static async Task MainAsync(string[] args)
    {
        var m_client = new GrooveMusicClient(clientId: "", clientSecret: "");
        var search = await m_client.SearchAsync("paramore");
    }
}