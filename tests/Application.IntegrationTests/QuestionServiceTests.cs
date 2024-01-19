using AutoMapper;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Services;
using ConsultaAlumnosClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultaAlumnosClean.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ConsultaAlumnosClean.Infrastructure.Services;
using ConsultaAlumnosClean.Application.Interfaces;
using Moq;
using ConsultaAlumnosClean.Domain.Enums;
using ConsultaAlumnosClean.Application.Profiles;
using Application.IntegrationTests;

namespace Application.UnitTests
{
    public class QuestionServiceTests
    {
        [Fact]
        public void CreateNewQuestion()
        {
            //Arrange
            var mapper = TestMapperFactory.CreateMapper();

            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContext();

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

            var result = service.CreateQuestion(questionCreateRequest,1);

            //Assert
            Assert.IsType<QuestionDto>(result);
            Assert.Equal(questionCreateRequest.Title, result.Title);
            Assert.Equal(questionCreateRequest.ProfessorId, result.ProfessorId);
            Assert.Equal(questionCreateRequest.Description, result.Description);
            Assert.Equal(questionCreateRequest.SubjectId, result.SubjectId);
            Assert.Equal(QuestionState.WaitingProfessorAnwser,result.QuestionState);

        }

    }
}
