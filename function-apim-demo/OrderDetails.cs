using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using function_apim_demo.Models;

namespace function_apim_demo
{
    public static class OrderDetails
    {
        [FunctionName("OrderDetails")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Get the customer's last name from the query string or the request body
            string name = req.Query["name"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            Order requestedOrder = new Order().GetOrder(name);

            if (requestedOrder != null)
            {
                string orderJson = JsonConvert.SerializeObject(requestedOrder);
                return new OkObjectResult(orderJson);
            }
            else
            {
                return new NotFoundObjectResult($"No order for customer {name} has been found in our registries.");
            }
        }
    }
}
