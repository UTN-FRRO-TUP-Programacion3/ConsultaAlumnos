using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Enums;
using ConsultaAlumnos.Domain.Exceptions;

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
            question.ChangeQuestionStatus(QuestionState.WaitingStudentAnwser, 1);

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
            question.ChangeQuestionStatus(QuestionState.WaitingStudentAnwser, 1);

            Response response = new Response(
                new Student() { Id = 3 },
                "Respuesa de un alumno que no hizo la pregunta");

            //Act and Assert
            Assert.Throws<NotAllowedException>(() => question.AddResponse(response));
        }


        [Fact]
        public void AddResponse()
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

        [Fact]
        public void AddResponseWithEmptyMessage()
        {
            //Arrange
            Question question = new Question();
            question.Student = new Student() { Id = 1 };
            question.AssignedProfessor = new Professor() { Id = 2 };

            Response response = new Response(
                new Professor() { Id = 2 },
                "");

            //Act and Assert
            Assert.Throws<ApplicationException>(() => question.AddResponse(response));
        }


    }
}
