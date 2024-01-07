﻿
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlumnosClean.Infrastructure.Data;

public class StudentRepository : EfRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ICollection<Subject> GetStudentSubjects(int studentId) =>
        _context.Students.Include(a => a.SubjectsAttended).ThenInclude(m => m.Professors).Where(a => a.Id == studentId)
        .Select(a => a.SubjectsAttended).FirstOrDefault() ?? new List<Subject>();
}
