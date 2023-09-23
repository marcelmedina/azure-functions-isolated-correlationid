using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace Middlewares;

public class CorrelationIdMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var requestData = await context.GetHttpRequestDataAsync();

        // find existing correlationId
        // otherwise create new correlationId
        var correlationId = requestData!.Headers.TryGetValues("x-correlationId", out var values)
            ? values.First()
            : Guid.NewGuid().ToString();

        // action executed
        await next(context);

        // set correlationId to response
        context.GetHttpResponseData()?.Headers.Add("x-correlationId", correlationId);
    }
}