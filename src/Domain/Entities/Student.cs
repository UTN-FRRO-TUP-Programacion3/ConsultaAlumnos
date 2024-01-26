namespace ConsultaAlumnos.Domain.Entities

{
    public class Student : User
    {
        public ICollection<Subject> SubjectsAttended { get; set; } = new List<Subject>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
