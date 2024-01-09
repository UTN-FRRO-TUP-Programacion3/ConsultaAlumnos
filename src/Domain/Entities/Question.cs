using ConsultaAlumnosClean.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnosClean.Domain.Entities
{
    public class Question
    {
      
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; } = string.Empty;
        [ForeignKey("ProfessorId")]
        public Professor AssignedProfessor { get; set; }
        public int ProfessorId { get; set; }
        [ForeignKey("CreatorStudentId")]
        public Student Student { get; set; } 
        public int CreatorStudentId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
      
        public ICollection<Response> Responses { get; set; } = new List<Response>();
        public QuestionState QuestionState { get; private set; } = QuestionState.WaitingProfessorAnwser;

        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; private set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; private set; } = DateTime.Now;

        public void AddResponse(Response response, int userId)
        {
            QuestionState newQuestionState;

            if (userId == AssignedProfessor.Id)
            {
                newQuestionState = QuestionState.WaitingStudentAnwser;
            } 
            else if(userId == Student.Id)
            {
                newQuestionState = QuestionState.WaitingProfessorAnwser;
            } 
            else
            {
                throw new Exception("User not allowed to answer this question");
            }

            Responses.Add(response);
            this.QuestionState = newQuestionState;
        }

        public void ChangeQuestionStatus(QuestionState questionState,int userId)
        {
            //Validacines
            if (AssignedProfessor.Id != userId && Student.Id != userId)
            {
                throw new Exception("User not allowed to modify this question");
            }

            if (this.QuestionState == questionState)
            {
                throw new Exception("The question has it State already");
            }

            this.QuestionState = questionState;
            this.LastModificationDate = DateTime.Now;

        }

    }

}
