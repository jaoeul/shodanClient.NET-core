using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shodan
{
    public class ShodanClient
	{
		private string _apiKey;

		// Constructor
		public ShodanClient(string apiKey)
		{
			this._apiKey = apiKey;
		}

        public async Task<object> searchHost(string ip)
		{
			string url = $"https://api.shodan.io/shodan/host/{ip}?key={_apiKey}";
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				Console.WriteLine(url);
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				return null;
			}
		}

		public async Task<object> count(string query, string facets)
		{
			string url = $"https://api.shodan.io/shodan/host/count?key={_apiKey}&query={query}&facets={facets}";
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				return null;
			}
		}
		
		public async Task<object> search(string query, string facets)
		{
			string url = $"https://api.shodan.io/shodan/host/search?key={_apiKey}&query={query}&facets={facets}";
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				return null;
			}
		}

		public async Task<object> listCrawledPorts()
		{
			string url = $"https://api.shodan.io/shodan/ports?key={_apiKey}";
			try
			{
				HttpClient client = new HttpClient();
				Console.WriteLine(url);
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				return null;
			}

		}

        public async Task<object> listFacets()
		{
			string url = $"https://api.shodan.io/shodan/host/search/facets?key={_apiKey}";
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				return null;
			}
		}

        public async Task<object> listFilters()
		{
			string url = $"https://api.shodan.io/shodan/host/search/filters?key={_apiKey}";
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				return null;
			}
		}

        public async Task<object> showTokens(string query)
		{
			string url = $"https://api.shodan.io/shodan/host/search/tokens?key={_apiKey}&query={query}";
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				return null;
			}
		}
	}
}
