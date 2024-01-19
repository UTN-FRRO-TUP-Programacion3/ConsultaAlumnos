using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
