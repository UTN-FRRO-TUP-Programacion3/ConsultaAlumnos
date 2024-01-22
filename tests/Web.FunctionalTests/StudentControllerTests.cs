using Azure;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Web.FunctionalTests
{
    public class StudentControllerTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async void  GetSubjectsWithoutAuthorizationToken()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/student/subjects");
            
            //Act
            HttpResponseMessage response = await _client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }


        [Fact]
        public async void GetSubjectsWithAnAuthorizedProfessor()
        {
            //Arrange
            string token = await factory.GetAccessTokenAsync("ppaez", "123456", "Professor");

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/student/subjects");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            //Act
            HttpResponseMessage response = await _client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public async void GetSubjects()
        {

            //Arrange
            string token = await factory.GetAccessTokenAsync("jperez", "123456", "Student");

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/student/subjects");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            //Act
            HttpResponseMessage response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType.ToString());

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Subject>>(stringResponse);
            Assert.NotNull(result);

            Assert.IsType<List<Subject>>(result);

        }

    }
}
