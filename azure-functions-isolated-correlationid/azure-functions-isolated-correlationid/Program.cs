using Microsoft.Extensions.Hosting;
using Middlewares;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(workerApplication =>
    {
        // Register custom middleware with the worker
        workerApplication.UseMiddleware<CorrelationIdMiddleware>();
    })
    .Build();

host.Run();