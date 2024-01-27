using AutoMapper;

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
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(["ConsultaAlumnos.Application"]));

            var mapper = configuration.CreateMapper();

            return mapper;
        }
    }
}
