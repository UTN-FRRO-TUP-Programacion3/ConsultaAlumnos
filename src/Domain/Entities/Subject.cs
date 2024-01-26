using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnos.Domain.Entities
{
    public class Subject
    {

        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Quarter { get; set; }
        public ICollection<Professor> Professors { get; set; } = new List<Professor>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
