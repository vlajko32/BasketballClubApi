using BasketballClubApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BCApiTest
{
    public class TestClientProvider: IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
           server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

           Client = server.CreateClient();


        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
