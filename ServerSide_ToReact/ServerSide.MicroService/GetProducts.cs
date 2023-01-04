using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServerSide.Entiteis;
using ServerSide.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Collections.Specialized.BitVector32;
using Data.Sql;
using System.IO;
using System.Reflection;

namespace ServerSide.MicroService
{
    public static class AllProducts
    {
        [FunctionName("getProducts")]
       
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Users/{action}/{IdNumber?}")] HttpRequest req,
            string action, string IdNumber, ILogger log)
        {
            string requestBody;

            switch (action)
            {
                case "ADD":
                    //To add a new User message
                    MUserMessage data = new MUserMessage();
                    data = System.Text.Json.JsonSerializer.Deserialize<MUserMessage>(req.Body);
                    MainManager.Instance.message.SendNewInputToDataLayer(data);

                    break;
                case "GET":
                    //To Get all Products from the DB
                    return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.products.getProductFromDB()));

                    break;

                case "GETONE":
                    //To Get Product From the DB by ProductID
                    Modul.MProducts p = MainManager.Instance.products.getProductByIDFromDB(IdNumber);
                    return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(p));

                    break;

                case "UpdateOne":
                    //To Update the iformation on the UnitInStock and the CategoryID by ProductID
                    try
                    {

                        requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                        Modul.MProducts product = System.Text.Json.JsonSerializer.Deserialize<Modul.MProducts>(requestBody);
                        MainManager.Instance.products.UpdateAProductInDb(product.ProductID, product.CategoryID, product.UnitsInStock);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    break;

                case "DELETE":
                    //To Delete Product by ProductID
                    MainManager.Instance.products.DeleteAProductByProductID(int.Parse(IdNumber));

                    break;

                default:
                    break;

            }


            return null;
        }
    }
}
