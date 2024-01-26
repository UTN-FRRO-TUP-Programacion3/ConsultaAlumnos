﻿using Moq;
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
            var mapper = TestMapperFactory.CreateMapper();

            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContextWithInMemoryDatabase();

            var questionRepository = new QuestionRepository(context);

            var mailService = new Mock<IMailService>().Object;

            var studentRepository = new StudentRepository(context);

            var professorRepository = new EfRepository<Professor>(context);

            var service = new QuestionService(mapper, questionRepository, mailService, studentRepository, professorRepository);

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
            Assert.Equal(questionCreateRequest.ProfessorId, result.ProfessorId);
            Assert.Equal(questionCreateRequest.Description, result.Description);
            Assert.Equal(questionCreateRequest.SubjectId, result.SubjectId);
            Assert.Equal(QuestionState.WaitingProfessorAnwser, result.QuestionState);

        }

    }
}
