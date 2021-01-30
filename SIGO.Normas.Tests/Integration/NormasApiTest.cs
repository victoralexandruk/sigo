using SIGO.Common;
using SIGO.Domain.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Normas.Tests.Integration
{
    public class NormasApiTest
    {
        private readonly HttpClient _httpClientNormas;

        public NormasApiTest()
        {
            var token = TokenHelper.CreateToken(new AppUser
            {
                Username = "Test"
            }, "wgGEl#XkIdkR");

            _httpClientNormas = new HttpClient()
            {
                BaseAddress = new Uri("https://bluelake.brazilsouth.cloudapp.azure.com/sigo/normas/v1/")
            };
            
            _httpClientNormas.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        [Theory]
        [InlineData("application/json")]
        [InlineData("application/xml")]
        public async Task GetAll_SendRequest_ReturnOk(string contentType)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "norma/");
            request.Headers.Add("Accept", contentType);

            // Act
            var response = await _httpClientNormas.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(request.Headers.Accept.ToString(), response.Content.Headers.ContentType.MediaType);
        }
    }
}
