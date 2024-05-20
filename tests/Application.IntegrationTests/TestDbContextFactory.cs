using ConsultaAlumnos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.IntegrationTests
{
    public static class TestDbContextFactory
    {
        public static ApplicationDbContext CreateTestApplicationDbContextWithInMemoryDatabase()
        {

            //Every database must have their own unique name to avoid collision when tests run in parallel
            var id = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"ConsultaAlumnosTestint-{id}").Options;
            var context = new ApplicationDbContext(options, true);

            //Seed data with context.OnModelCreating
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            

            return context;
        }

        public static ApplicationDbContext CreateTestApplicationDbContextWithSQLiteDatabase()
        {
            //To run test in parallel
            var id = Guid.NewGuid().ToString();
            string strDatabasePath = $"Data Source = ConsultaAlumnosTestint-{id}.db";

            //string strDatabasePath = $"Data Source = ConsultaAlumnosTestint.db";

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
