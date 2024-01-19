using ConsultaAlumnosClean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;
namespace ConsultaAlumnosClean.Infrastructure.Data;

/// <summary>
/// One convention of Code First is implicit key properties; Code First will look for a property named “Id”, or a combination of class name and “Id”, such as “BlogId”. This property will map to a primary key column in the database.
/// </summary>

public class ApplicationDbContext : DbContext
{
    private readonly bool isTestingEnvironment;
    public DbSet<Student> Students { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
    public DbSet<Professor> Professors { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
    public DbSet<Question> Questions { get; set; }
    public DbSet<Response> Responses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<User> Users { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool isTestingEnvironment = false) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    {
        this.isTestingEnvironment = isTestingEnvironment;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

        modelBuilder.Entity<Subject>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>().HasData(CreateStudentDataSeed());

        modelBuilder.Entity<Professor>().HasData(CreateProfessorDataSeed());

        modelBuilder.Entity<Subject>().HasData(CreateSubjectDataSeed());

        modelBuilder.Entity<Subject>()
            .HasMany(x => x.Students)
            .WithMany(x => x.SubjectsAttended)
            .UsingEntity(j => j
                .ToTable("StudentsSubjectsAttended")
                .HasData(CreateStudentsSubjectsAttendeDataSeed()
                ));


        modelBuilder.Entity<Subject>()
            .HasMany(x => x.Professors)
            .WithMany(x => x.Subjects)
            .UsingEntity(j => j
                .ToTable("ProfessorSubject")
                .HasData(CreateProfessorSubjectDataSeed()
                ));


        base.OnModelCreating(modelBuilder);

        //Disable all default relationship cascade delete behavior
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }
    }

    private Student[] CreateStudentDataSeed()
    {
        Student[] result;

        if (isTestingEnvironment)
        {
            result = [
            new Student
            {
                LastName = "TestingStudentLastname",
                Name = "TestingStudentName",
                Email = "tstudent@gmail.com",
                UserName = "testingstudent",
                Password = "123456",
                Id = 1
            }];
        }
        else
        {
            result = [
            new Student
            {
                LastName = "Bologna",
                Name = "Nicolas",
                Email = "nbologna31@gmail.com",
                UserName = "nbologna_alumno",
                Password = "123456",
                Id = 1
            },
                new Student
                {
                    LastName = "Perez",
                    Name = "Juan",
                    Email = "Jperez@gmail.com",
                    UserName = "jperez",
                    Password = "123456",
                    Id = 2
                },
                new Student
                {
                    LastName = "Garcia",
                    Name = "Pedro",
                    Email = "pgarcia@gmail.com",
                    UserName = "pgarcia",
                    Password = "123456",
                    Id = 3
                }];
        }

        return result;
    }


    private Professor[] CreateProfessorDataSeed()
    {
        Professor[] result = Array.Empty<Professor>();

        if (isTestingEnvironment)
        {
            result = [
            new Professor
            {
                LastName = "TestingProfessorLastname",
                Name = "TestingProfessorName",
                Email = "tprofessor@gmail.com",
                UserName = "testingprofessor",
                Password = "123456",
                Id = 5
            }];

        }
        else
        {
            result = [
            new Professor
            {
                LastName = "Bologna",
                Name = "Nicolas",
                Email = "nbologna31@gmail.com",
                UserName = "nbologna_profesor",
                Password = "123456",
                Id = 4
            },
            new Professor
            {
                LastName = "Paez",
                Name = "Pablo",
                Email = "ppaez@gmail.com",
                UserName = "ppaez",
                Password = "123456",
                Id = 5
            }];
        }

        return result;
    }


    private Subject[] CreateSubjectDataSeed()
    {
        Subject[] result;

        if (isTestingEnvironment)
        {
            result =
            [
                new Subject
                {
                    Id = 1,
                    Name = "TestingSubject",
                    Quarter = "Tercer"
                }
            ];
        }
        else
        {
            result =
            [
                new Subject
                {
                    Id = 1,
                    Name = "Programación 3",
                    Quarter = "Tercer"
                },
                new Subject
                {
                    Id = 2,
                    Name = "Programación 4",
                    Quarter = "Tercer"
                }
            ];
        }

        return result;
    }

    private Object[] CreateStudentsSubjectsAttendeDataSeed()
    {
        Object[] result;

        if (isTestingEnvironment)
        {
            result = new[]
            {
                new { StudentsId = 1, SubjectsAttendedId = 1},
            };
        }
        else
        {
            result = new[]
            {
                new { StudentsId = 1, SubjectsAttendedId = 1},
                new { StudentsId = 1, SubjectsAttendedId = 2},
            };
        }

        return result;
    }

    private Object[] CreateProfessorSubjectDataSeed()
    {
        Object[] result;

        if (isTestingEnvironment)
        {
            result = new[]
            {
                new { ProfessorsId = 4, SubjectsId = 1},
            };
        }
        else
        {
            result = new[]
            {
                new { ProfessorsId = 4, SubjectsId = 1},
                new { ProfessorsId= 5, SubjectsId = 1},
                new { ProfessorsId = 4, SubjectsId = 2},
            };
        }

        return result;
    }

    
}
