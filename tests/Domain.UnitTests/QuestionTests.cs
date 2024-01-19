using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitTests
{
    public class QuestionTests
    {
        [Fact]
        public void AddProfessorResponseWhenWaitingForStudentResponse()
        {
            //Arrange
            Question question = new Question();
            question.Student = new Student() { Id = 1 };
            //question.Student.Id = 1;
            question.AssignedProfessor = new Professor() { Id = 2 };
            //question.AssignedProfessor.Id = 2;
            question.ChangeQuestionStatus(ConsultaAlumnosClean.Domain.Enums.QuestionState.WaitingStudentAnwser, 1);

            Response response = new Response(
                new Professor() { Id = 2 },
                "Respuesta del profesor");

            //Act and Assert
            Assert.Throws<AppValidationException>(() => question.AddResponse(response));
        }


        [Fact]
        public void AddStudentResponseWhenWaitingForProfessorResponse()
        {
            //Arrange
            Question question = new Question();
            question.Student = new Student() { Id = 1 };
            question.AssignedProfessor = new Professor() { Id = 2 };

            Response response = new Response(
                new Student() { Id = 1 },
                "Respuesta del alumno");

            //Act and Assert
            Assert.Throws<AppValidationException>(() => question.AddResponse(response));
        }


        [Fact] 
        public void AddResponseFromACreatorThatIsNotStudentOrProfessorInTheQuestion()
        {
            //Arrange
            Question question = new Question();
            question.Student = new Student() { Id = 1 };
            question.AssignedProfessor = new Professor() { Id = 2 };
            question.ChangeQuestionStatus(ConsultaAlumnosClean.Domain.Enums.QuestionState.WaitingStudentAnwser, 1);

            Response response = new Response(
                new Student() { Id = 3 },
                "Respuesa de un alumno que no hizo la pregunta");

            //Act and Assert
            Assert.Throws<NotAllowedException>(() => question.AddResponse(response));
        }


        [Fact]
        public void AddResponseToAQuestion()
        {
            //Arrange
            Question question = new Question();
            question.Student = new Student() { Id = 1 };
            question.AssignedProfessor = new Professor() { Id = 2 };

            Response response = new Response(
                new Professor() { Id = 2 },
                "Respuesa del profesor");

            //Act
            question.AddResponse(response);

            //Assert
            Assert.True(question.Responses.Count() == 1);
        }


    }
}
