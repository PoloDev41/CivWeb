using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebCiv;

namespace EngineUnitTest
{
    public class TestCheckRoutine
    {
        private TestServer _server;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Ignore("don't find appsettings.json")]
        [Test]
        public async Task CheckIndexRoutine()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task CheckErrorPage()
        {
            var response = await _client.GetAsync("/PathToFileWhich/DoesntExit");
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}