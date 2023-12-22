using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnosClean.Domain.Entities
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now;
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        public int CreatorId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int QuestionId { get; set; }

    }
}
