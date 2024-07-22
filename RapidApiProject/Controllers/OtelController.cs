using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;
using RapidApiProject.Models.OtelModel;
using System.Net.Http.Headers;

namespace RapidApiProject.Controllers
{
    public class OtelController : Controller
    {
		
        public async Task<IActionResult> Index()
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?checkout_date=2024-09-15&order_by=popularity&filter_by_currency=AED&include_adjacency=true&children_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&room_number=1&dest_id=-553173&dest_type=city&adults_number=2&page_number=0&checkin_date=2024-09-14&locale=en-gb&units=metric&children_ages=5%2C0"),
				Headers =
	{
		{ "x-rapidapi-key", "da0c61577amsh87f33e2291e88d4p136182jsn8e6abda27db6" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var value1 = JsonConvert.DeserializeObject<OtelFeatureModel>(body);
				return View(value1.result.ToList());
			}
		}
    }
}
