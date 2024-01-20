using Azure;
using ConsultaAlumnosClean.Domain.Entities;
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
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/student/subjects");
            HttpResponseMessage response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }


        [Fact]
        public async void GetSubjectsWithAnAuthorizedProfessor()
        {
            //Get the token
            var authRequest = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/authenticate");
            authRequest.Content = JsonContent.Create(new { userName = "ppaez", password = "123456", userType = "Professor" });
            HttpResponseMessage AuthResponse = await _client.SendAsync(authRequest);
            string token = await AuthResponse.Content.ReadAsStringAsync();

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/student/subjects");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public async void GetSubjects()
        {

            //Get the token
            var authRequest = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/authenticate");
            authRequest.Content = JsonContent.Create(new { userName = "nbologna_alumno", password = "123456", userType = "Student" });
            HttpResponseMessage AuthResponse = await _client.SendAsync(authRequest);
            string token = await AuthResponse.Content.ReadAsStringAsync();

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/student/subjects");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            //Assert.Equal("text/html; charset=utf-8",
            //response.Content.Headers.ContentType.ToString());
        }

    }
}
