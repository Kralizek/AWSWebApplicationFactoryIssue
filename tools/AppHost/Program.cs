var builder = DistributedApplication.CreateBuilder(args);

var aws = builder.AddAWSSDKConfig()
                 .WithProfile("EduConvertMaster")
                 .WithRegion(Amazon.RegionEndpoint.EUNorth1);

builder.AddProject<Projects.Api>("api")
        .WithReference(aws)
        .WithHttpCommand(
                path: "/weatherforecast",
                displayName: "GetWeatherForecast",
                commandOptions: new HttpCommandOptions
                {
                        Method = HttpMethod.Get,
                        Description = "Get the weather forecast",
                        IconName = "DocumentLightning",
                        IsHighlighted = true
                }
        );

builder.Build().Run();
