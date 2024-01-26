using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Services;
using ConsultaAlumnos.Infrastructure.Data;

namespace Application.IntegrationTests
{
    public class StudentServiceTests
    {
        [Fact]
        public void GetStudentById_ReturnsStudentGivenValidId()
        {
            //Arrange
            var mapper = TestMapperFactory.CreateMapper();

            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContextWithInMemoryDatabase();

            var studentRepository = new StudentRepository(context);

            var service = new StudentService(studentRepository, mapper);

            //Act
            var result = service.GetStudentById(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<StudentDto>(result);

        }
    }
}
