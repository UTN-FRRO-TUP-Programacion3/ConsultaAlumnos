using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnos.Domain.Entities
{
    public class Response
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string Message { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; private set; } = DateTime.Now;
      
        public User Creator { get; private set; }
     
        public Question Question { get; private set; }
        
        public Response(Question question, User creator, string message)
        {
            Question = question;
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
