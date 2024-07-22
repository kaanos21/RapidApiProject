using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models.OtelModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidApiProject.ViewComponents.OtelViewComponents
{
	public class _OtelSearchBox : ViewComponent
	{
		
		public async Task<IViewComponentResult> InvokeAsync(OtelFilterModel filter)
		{
			
			if(filter==null)
			{
				filter= new OtelFilterModel();
				filter.Checkin = "2024-09-14";
				filter.Checkout = "2024-09-15";
				filter.Rooms = 1;
				filter.Guest = 2;
				filter.Children= 2;
			}
			// Filtreleme parametrelerini al
			string checkin = filter.Checkin;
			string checkout = filter.Checkout;
			int guest = filter.Guest;
			int children = filter.Children;
			int rooms = filter.Rooms;

			// API isteğini oluştur
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?checkout_date={checkout:yyyy-MM-dd}&order_by=popularity&filter_by_currency=AED&include_adjacency=true&children_number={children}&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&room_number={rooms}&dest_id=553173&dest_type=city&adults_number={guest}&page_number=0&checkin_date={checkin:yyyy-MM-dd}&locale=en-gb&units=metric&children_ages=5%2C0"),
				Headers =
				{
					{ "x-rapidapi-key", "da0c61577amsh87f33e2291e88d4p136182jsn8e6abda27db6" },
					{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
				},
			};

			// API isteğini gönder
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
