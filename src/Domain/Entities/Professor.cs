

namespace ConsultaAlumnosClean.Domain.Entities
{
    public class Professor : User
    {
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
