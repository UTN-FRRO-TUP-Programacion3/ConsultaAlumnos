using AutoMapper;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Profiles;
using ConsultaAlumnosClean.Application.Services;
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    public class StudentServiceTests
    {
        [Fact]
        public void GetStudentById_ReturnsStudentGivenValidId()
        {
            //Arrange
            var mapper = TestMapperFactory.CreateMapper();

            ApplicationDbContext context = TestDbContextFactory.CreateTestApplicationDbContext();

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
