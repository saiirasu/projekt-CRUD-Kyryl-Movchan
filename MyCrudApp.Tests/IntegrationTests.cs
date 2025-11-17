using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCrudApp;
using Xunit; 

namespace MyCrudApp.Tests;

internal class TestWebAppFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });
        });

        return base.CreateHost(builder);
    }
}

internal class IntegrationTests : IClassFixture<TestWebAppFactory>
{
    private readonly HttpClient _client;

    public IntegrationTests(TestWebAppFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_NonExistentProduct_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync("/api/products/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Post_ProductWithInvalidPrice_ShouldReturnBadRequest()
    {
        var invalidProduct = new { Name = "Test Product", Price = -10, Category = "Test", Description = "Test" };
        var jsonContent = new StringContent(JsonSerializer.Serialize(invalidProduct), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/products", jsonContent);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Post_ProductWithMissingName_ShouldReturnBadRequest()
    {
        var invalidProduct = new { Price = 100, Category = "Test", Description = "Test" };
        var jsonContent = new StringContent(JsonSerializer.Serialize(invalidProduct), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/products", jsonContent);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}