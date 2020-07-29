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
    public static class ProductDetails
    {
        [FunctionName("ProductDetails")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Get the product ID from the query string or the request body
            string requestedProductID = req.Query["ID"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            requestedProductID = requestedProductID ?? data?.id;

            Product requestedProduct = new Product().GetProduct(requestedProductID);

            if (requestedProduct != null)
            {
                string productJson = JsonConvert.SerializeObject(requestedProduct);
                return new OkObjectResult(productJson);
            }
            else
            {
                return new NotFoundObjectResult($"Product with Id {requestedProductID} doesn't exist in our registries");
            }
        }
    }
}
