using AutoMapper;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Application.Profiles;
using ConsultaAlumnosClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    public static class TestMapperFactory
    {
        public static IMapper CreateMapper()
        {
            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<StudentProfile>();
            //    cfg.AddProfile<QuestionProfile>();
            //});
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(["ConsultaAlumnosClean.Application"]));

            var mapper = configuration.CreateMapper();

            return mapper;
        }
    }
}
