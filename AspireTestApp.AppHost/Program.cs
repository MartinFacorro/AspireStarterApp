var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireTestApp_ApiService>("apiservice");

// Add Redis
var redis = builder.AddRedis("cache");

builder.AddProject<Projects.AspireTestApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(redis);

builder.Build().Run();
