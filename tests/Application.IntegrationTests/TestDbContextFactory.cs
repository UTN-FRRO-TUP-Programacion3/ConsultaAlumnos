using ConsultaAlumnos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.IntegrationTests
{
    public static class TestDbContextFactory
    {
        public static ApplicationDbContext CreateTestApplicationDbContextWithInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_database").Options;
            var context = new ApplicationDbContext(options,true);

            //Seed data with context.OnModelCreating
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            

            return context;
        }

        public static ApplicationDbContext CreateTestApplicationDbContextWithSQLiteDatabase()
        {
            var id = Guid.NewGuid().ToString();
            string strDatabasePath = $"Data Source = ConsultaAlumnosTestint-{id}.db";

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(strDatabasePath).Options;
            var context = new ApplicationDbContext(options, true);


            //Seed data with context.OnModelCreating
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            context.Database.EnsureCreated();


            return context;
        }

    }
}
