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

namespace Application.IntegrationTests
{
    public static class TestDbContextFactory
    {
        public static ApplicationDbContext CreateTestApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_database").Options;
            var context = new ApplicationDbContext(options,true);

            //Seed data with context.OnModelCreating
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            

            return context;
        }

    }
}
