using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConsultaAlumnos.Application.Models;

namespace Web.FunctionalTests
{
    public class QuestionControllerTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async void CreateQuestion()
        {
            
            //Arrange
            string token = await factory.GetAccessTokenAsync("jperez", "123456", "Student");

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/question");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(new { title = "Question Title", description = "Question Description", professorId = 5, subjectId = 1});
            
            //Act
            HttpResponseMessage response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType.ToString());

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<QuestionDto>(stringResponse);
            Assert.NotNull(result);


        }

    }
}
