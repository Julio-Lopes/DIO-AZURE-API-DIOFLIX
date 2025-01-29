using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.Configure<KestrelServerOptions>(options =>
        {
            options.Limits.MaxRequestBufferSize = 1024 * 1024 * 100; // 100 MB
        });
    })
    .Build();

host.Run();