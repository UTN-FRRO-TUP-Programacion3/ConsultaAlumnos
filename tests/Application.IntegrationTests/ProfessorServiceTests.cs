using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Services;
using ConsultaAlumnos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    public class ProfessorServiceTests
    {
        [Fact]
        public void GetPendingQuestionsWithOutResponses()
        {
            //Arrange

            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContextWithInMemoryDatabase();

            var questionRepository = new QuestionRepository(context);

            var service = new ProfessorService(questionRepository);

            //Act
            var result = service.GetPendingQuestions(5,false);
            

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<QuestionDto>>(result);
            Assert.Single(result);
            Assert.Empty(result.First().Responses);

        }

        [Fact]
        public void GetPendingQuestionsWithResponses()
        {
            //Arrange
            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContextWithInMemoryDatabase();

            var questionRepository = new QuestionRepository(context);

            var service = new ProfessorService(questionRepository);

            //Act
            var result = service.GetPendingQuestions(5, true);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<QuestionDto>>(result);
            Assert.Single(result);
            Assert.Single(result.First().Responses);
            Assert.IsType<List<ResponseDto>>(result.First().Responses);
        }

    }
}
