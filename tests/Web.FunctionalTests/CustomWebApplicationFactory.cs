
using ConsultaAlumnos.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Web.FunctionalTests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    /// <summary>
    /// Overriding CreateHost to avoid creating a separate ServiceProvider per this thread:
    /// https://github.com/dotnet-architecture/eShopOnWeb/issues/465
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Development"); // will not send real emails
        var host = builder.Build();
        host.Start();

        // Get service provider.
        var serviceProvider = host.Services;

        // Create a scope to obtain a reference to the database
        // context (AppDbContext).
        using (var scope = serviceProvider.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            var logger = scopedServices
                .GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

            // Reset Sqlite database for each test run
            // If using a real database, you'll likely want to remove this step.
            db.Database.EnsureDeleted();

            // Ensure the database is created.
            db.Database.EnsureCreated();
        }

        return host;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .ConfigureServices(services =>
            {
                // Configure test dependencies here

                //// Remove the app's ApplicationDbContext registration.
                //var descriptor = services.SingleOrDefault(
                //d => d.ServiceType ==
                //    typeof(DbContextOptions<AppDbContext>));

                //if (descriptor != null)
                //{
                //  services.Remove(descriptor);
                //}

                //// This should be set for each individual test run
                //string inMemoryCollectionName = Guid.NewGuid().ToString();

                //// Add ApplicationDbContext using an in-memory database for testing.
                //services.AddDbContext<AppDbContext>(options =>
                //{
                //  options.UseInMemoryDatabase(inMemoryCollectionName);
                //});
            });
    }


    public async Task<string> GetAccessTokenAsync(string userName, string password, string userType)
    {
        using (var _localClient = CreateClient())
        {
            //Get the token
            var authRequest = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/authenticate");
            authRequest.Content = JsonContent.Create(new { userName, password, userType });
            HttpResponseMessage AuthResponse = await _localClient.SendAsync(authRequest);
            string token = await AuthResponse.Content.ReadAsStringAsync();
            return token;
        }
    }

}
