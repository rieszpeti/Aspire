using Aspire.Hosting;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Aspire_ApiService>("apiservice");

builder.AddProject<Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

var aspireWebUrl = builder.AddParameter("AspireWebUrl", "https://localhost:7305");

builder.AddProject<SomeWebapi1>("somewebapi1")
       .WithEnvironment("AspireWebUrl", aspireWebUrl);

builder.Build().Run();
