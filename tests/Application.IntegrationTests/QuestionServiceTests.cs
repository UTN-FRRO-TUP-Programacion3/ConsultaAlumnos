using Moq;
using ConsultaAlumnos.Infrastructure.Data;
using ConsultaAlumnos.Domain.Enums;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Services;

namespace Application.IntegrationTests
{
    public class QuestionServiceTests
    {
        [Fact]
        public void CreateNewQuestion()
        {
            //Arrange
            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContextWithInMemoryDatabase();

            var questionRepository = new QuestionRepository(context);

            var mailService = new Mock<IMailService>().Object;

            var studentRepository = new StudentRepository(context);

            var professorRepository = new EfRepository<Professor>(context);

            var userRepository = new UserRepository(context);

            var subjectRepository = new EfRepository<Subject>(context);

            var service = new QuestionService(questionRepository, mailService, studentRepository, professorRepository,userRepository,subjectRepository);

            //Act
            QuestionCreateRequest questionCreateRequest = new()
            {
                ProfessorId = 5,
                Title = "Título de prueba",
                Description = "Pregunta de prueba",
                SubjectId = 1

            };

            var result = service.CreateQuestion(questionCreateRequest, 1);

            //Assert
            Assert.IsType<QuestionDto>(result);
            Assert.Equal(questionCreateRequest.Title, result.Title);
            //Assert.Equal(questionCreateRequest.ProfessorId, result.ProfessorId);
            Assert.Equal(questionCreateRequest.Description, result.Description);
            //Assert.Equal(questionCreateRequest.SubjectId, result.SubjectId);
            Assert.Equal(QuestionState.WaitingProfessorAnwser, result.QuestionState);

        }


        [Fact]
        public void getQuestionById_ReturnsQuestionGivenAValidId()
        {
            //Arrange
            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContextWithInMemoryDatabase();

            QuestionRepository questionRepository = new(context);

            var service = new QuestionService(questionRepository,null, null, null, null, null);

            //Act
            var result = service.GetQuestion(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<QuestionDto>(result);
        }


        [Fact]
        public void CreateResponseAndReturnItFromDatabase()
        {
            //Arrange
            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContextWithInMemoryDatabase();

            QuestionRepository questionRepository = new(context);
            var userRepository = new UserRepository(context);

            var service = new QuestionService(questionRepository, null, null, null, userRepository, null);

            ResponseCreateRequest responseCreateRequest = new ResponseCreateRequest()
            {
                Message = "Response message created during testing"
            };

            //Act
            service.CreateResponse(responseCreateRequest,2,4);

            var result = service.GetResponse(2,2);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ResponseDto>(result);
            Assert.NotNull(result.Creator);
            Assert.IsType<UserDto>(result.Creator);
            Assert.True(result.CreationDate >= DateTime.Now.AddMinutes(-60));
            Assert.True(result.CreationDate < DateTime.Now);
        }

    }
}
