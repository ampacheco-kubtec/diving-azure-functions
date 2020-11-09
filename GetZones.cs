using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DivingPrj
{
    public static class GetZones
    {
        [FunctionName("GetZones")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            DivingZone[] zones = GetAllZones();
            string zonesJson = JsonConvert.SerializeObject(zones);

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(zonesJson);

        }
        private static DivingZone[] GetAllZones()
        {
            return new DivingZone[] {
                new DivingZone { ID=1, Name="Valparaiso", Latitud=1, Longitud=1, ImageUrl="https://www.valparaiso.cl",
                    Inmersions = new Inmersion[] {
                        new Inmersion {Id=1, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=2, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=3, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=4, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=5, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=6, InmersionDate="2020-01-01", Time=10, Deep=50}
                    }
                },
                new DivingZone { ID=2, Name="Valparaiso", Latitud=1, Longitud=1, ImageUrl="https://www.valparaiso.cl",
                    Inmersions = new Inmersion[] {
                        new Inmersion {Id=1, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=2, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=3, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=4, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=5, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=6, InmersionDate="2020-01-01", Time=10, Deep=50}
                    }
                },
                new DivingZone { ID=3, Name="Valparaiso", Latitud=1, Longitud=1, ImageUrl="https://www.valparaiso.cl",
                    Inmersions = new Inmersion[] {
                        new Inmersion {Id=1, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=2, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=3, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=4, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=5, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=6, InmersionDate="2020-01-01", Time=10, Deep=50}
                    }
                },
                new DivingZone { ID=4, Name="Valparaiso", Latitud=1, Longitud=1, ImageUrl="https://www.valparaiso.cl",
                    Inmersions = new Inmersion[] {
                        new Inmersion {Id=1, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=2, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=3, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=4, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=5, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=6, InmersionDate="2020-01-01", Time=10, Deep=50}
                    }
                },
                new DivingZone { ID=5, Name="Valparaiso", Latitud=1, Longitud=1, ImageUrl="https://www.valparaiso.cl",
                    Inmersions = new Inmersion[] {
                        new Inmersion {Id=1, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=2, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=3, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=4, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=5, InmersionDate="2020-01-01", Time=10, Deep=50},
                        new Inmersion {Id=6, InmersionDate="2020-01-01", Time=10, Deep=50}
                    }
                }
            };
        }
    }
    public class DivingZone 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public string ImageUrl { get; set; }
        public Inmersion[] Inmersions { get; set; }     
    }

    public class Inmersion 
    {
        public int Id { get; set; }     
        public String InmersionDate { get; set; }
        public int Time { get; set; }
        public int Deep { get; set; }
    }
}
