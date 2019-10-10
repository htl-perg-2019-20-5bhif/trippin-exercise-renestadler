using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Trippin_Exercise
{
    class Program
    {
        static HttpClient HttpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            HttpClient.BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/apiKey/");
            IEnumerable<PersonInputDto> people = (JsonSerializer.Deserialize<IEnumerable<PersonInputDto>>(await File.ReadAllTextAsync("users.json")));
            foreach (var item in people)
            {

                HttpResponseMessage response = await HttpClient.GetAsync("People('" + item.UserName + "')");
                if (!response.IsSuccessStatusCode)
                {
                    var content = new StringContent(JsonSerializer.Serialize(new PersonOutputDto(item)), Encoding.UTF8, "application/json");
                    await HttpClient.PostAsync("People", content);
                }
            }
        }
    }
}
