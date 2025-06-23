using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace App.MvcUi.Controllers
{
    public class RandevuController(IHttpClientFactory factory) : Controller
    {
        private readonly string baseUrl = "http://localhost:5070/";

        public async Task<IActionResult> Index(int id)
        {
            Randevu randevu = new Randevu();
            using (var client = factory.CreateClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage result = await client.GetAsync($"api/Randevu/{id}");
                if (result.IsSuccessStatusCode)
                {
                    var randevuResponse = result.Content.ReadAsStringAsync().Result;
                    randevu = JsonConvert.DeserializeObject<Randevu>(randevuResponse);
                }
            }
            return View(randevu);
        }
    }
}
