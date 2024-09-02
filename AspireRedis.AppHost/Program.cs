var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
                   .PublishAsAzureRedis();

var apiService = builder.AddProject<Projects.AspireRedis_ApiService>("apiservice");

builder.AddProject<Projects.AspireRedis_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
