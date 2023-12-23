using ConsultaAlumnosClean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ConsultaAlumnosClean.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
    public DbSet<Professor> Professors { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
    public DbSet<Question> Questions { get; set; }
    public DbSet<Response> Responses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<User> Users { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

        modelBuilder.Entity<Student>().HasData(
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
            });

        modelBuilder.Entity<Professor>().HasData(
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
            });

        modelBuilder.Entity<Subject>().HasData(
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
            });

        modelBuilder.Entity<Subject>()
            .HasMany(x => x.Students)
            .WithMany(x => x.SubjectsAttended)
            .UsingEntity(j => j
                .ToTable("StudentsSubjectsAttended")
                .HasData(new[]
                    {
                            new { StudentsId = 1, SubjectsAttendedId = 1},
                            new { StudentsId = 1, SubjectsAttendedId = 2},
                    }
                ));

        modelBuilder.Entity<Subject>()
            .HasMany(x => x.Professors)
            .WithMany(x => x.Subjects)
            .UsingEntity(j => j
                .ToTable("ProfessorSubject")
                .HasData(new[]
                    {
                            new { ProfessorsId = 4, SubjectsId = 1},
                            new { ProfessorsId= 5, SubjectsId = 1},
                            new { ProfessorsId = 4, SubjectsId = 2},
                    }
                ));

        base.OnModelCreating(modelBuilder);
    }
}
