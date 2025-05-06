using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Api.Tests;

public class Tests
{
    [Test]
    public async Task Test1()
    {
        WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>();

        var http = factory.CreateDefaultClient();

        var response = await http.GetAsync("/weatherforecast");

        response.EnsureSuccessStatusCode();
    }
}
