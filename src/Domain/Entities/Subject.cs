
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnosClean.Domain.Entities
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quarter { get; set; }
        public ICollection<Professor> Professors { get; set; } = new List<Professor>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
