﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.FunctionalTests
{
    public class FSharpWebSiteTest : IClassFixture<MvcTestFixture<FSharpWebSite.Startup>>
    {
        public FSharpWebSiteTest(MvcTestFixture<FSharpWebSite.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }
        
        [Fact]
        public async Task HomeIndex_ReturnsHtml()
        {
            // Act
            var response = await Client.GetAsync("http://localhost/");
            var responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("<h1>Hello from FSharpWebSite</h1>", responseBody);
        }
    }
}
