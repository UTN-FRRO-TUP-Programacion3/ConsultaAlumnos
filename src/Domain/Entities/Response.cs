using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnosClean.Domain.Entities
{
    public class Response
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string Message { get; set; }

        public DateTime CreationDate { get; } = DateTime.Now;
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        public int CreatorId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int QuestionId { get; set; }

        public Response(User creator,string message)
        {
            Message = message;
            Creator = creator;
        }

        //Para Entity framework, porque
        //EF Core cannot set navigation properties (such as Creator) using a constructor.
        public Response()
        {
            
        }
    }
}
