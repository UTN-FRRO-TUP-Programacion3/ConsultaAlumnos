using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Enums;

namespace ConsultaAlumnos.Application.Models;

public class QuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<ResponseDto> Responses { get; set; } = new List<ResponseDto>();
    public QuestionState QuestionState { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? LastModificationDate { get; set; }

    public ProfessorDto AssignedProfessor { get; private set; }

    public StudentDto Student { get; private set; }

    public SubjectDto Subject { get; private set; }

    public static QuestionDto Create(Question question)
    {
        var dto  = new QuestionDto();

        dto.Id = question.Id;
        dto.Title = question.Title;
        dto.Description = question.Description; 
        dto.CreationDate = question.CreationDate;
        dto.EndDate = question.EndDate;
        dto.LastModificationDate = question.LastModificationDate;

        dto.AssignedProfessor = ProfessorDto.Create(question.AssignedProfessor);
        dto.Student = StudentDto.Create(question.Student);
        dto.Subject = SubjectDto.Create(question.Subject);

        foreach(Response r in question.Responses)
        {
            dto.Responses.Add(ResponseDto.Create(r));
        }

        return dto;
    }

    public static List<QuestionDto> CreateList(IEnumerable<Question> questions)
    {
        List<QuestionDto> listDto = [];
        foreach(var q in questions)
        {
            listDto.Add(Create(q));
        }

        return listDto;
    }

}


