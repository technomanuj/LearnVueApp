using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace api
{
    public static class users_getbyid
    {
        [FunctionName("users_getbyid")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

           HttpClient client= new HttpClient();
            client.BaseAddress=new Uri("https://jsonplaceholder.typicode.com/users");
            var result=await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/2");

            

            return new OkObjectResult(result);
        }
    }
}
