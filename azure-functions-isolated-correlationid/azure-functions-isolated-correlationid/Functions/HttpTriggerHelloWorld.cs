using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Functions;

public class HttpTriggerHelloWorld(ILogger<HttpTriggerHelloWorld> logger)
{
    [Function("HttpTriggerHelloWorld")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
        FunctionContext executionContext)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions! Hello World!");

        return response;
    }
}