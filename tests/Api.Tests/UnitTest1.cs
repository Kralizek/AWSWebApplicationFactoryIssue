using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Api.Tests;

public class Tests
{
    [Test]
    public async Task Test1()
    {
        WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddDefaultAWSOptions(new Amazon.Extensions.NETCore.Setup.AWSOptions{
                    Credentials = new Amazon.Runtime.AnonymousAWSCredentials(),
                });
            });
        });

        var http = factory.CreateDefaultClient();

        var response = await http.GetAsync("/weatherforecast");

        Assert.That(response.IsSuccessStatusCode, Is.True, "Response was not successful");
    }
}
