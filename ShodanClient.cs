using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shodan
{
    public class ShodanClient //: IShodanClient
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
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				Console.WriteLine(url);
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}

		public async Task<object> count(string query, string facets)
		{
			string url = $"https://api.shodan.io/shodan/host/count?key={_apiKey}&query={query}&facets={facets}";
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}
		
		public async Task<object> search(string query, string facets)
		{
			string url = $"https://api.shodan.io/shodan/host/search?key={_apiKey}&query={query}&facets={facets}";
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}

		public async Task<object> listCrawledPorts()
		{
			string url = $"https://api.shodan.io/shodan/ports?key={_apiKey}";
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				Console.WriteLine(url);
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}

		}

        public async Task<object> listFacets()
		{
			string url = $"https://api.shodan.io/shodan/host/search/facets?key={_apiKey}";
			string responseBody = String.Empty;
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}

        public async Task<object> listFilters()
		{
			string url = $"https://api.shodan.io/shodan/host/search/filters?key={_apiKey}";
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);

				return null;
			}
		}

        public async Task<object> showTokens(string query)
		{
			string url = $"https://api.shodan.io/shodan/host/search/tokens?key={_apiKey}&query={query}";
			string responseBody = String.Empty;
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}

		public async Task<object> listProtocols()
		{
			string url = $"https://api.shodan.io/shodan/protocols?key={_apiKey}";
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}

		public async Task<object> scanNetwork(string ips)
		{
			string url = $"https://api.shodan.io/shodan/scan?key={_apiKey}";
			ips.Replace(" ", String.Empty);
			string responseBody = String.Empty;

			Dictionary<string, string> dict = new Dictionary<string, string>();
			dict.Add("port", ips);
			var data = new FormUrlEncodedContent(dict);

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.PostAsync(url, data);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(JsonConvert.DeserializeObject<object>(responseBody).ToString());
				return null;
			}
		}

        public async Task<object> scanPortAndProtocolOnWeb(string port, string protocol)
		{
			string url = $"https://api.shodan.io/shodan/scan/internet?key={_apiKey}";
			string responseBody = String.Empty;
			Dictionary<string, string> dict = new Dictionary<string, string>();

			dict.Add("port", port);
			dict.Add("protocol", protocol);

			var data = new FormUrlEncodedContent(dict);

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.PostAsync(url, data);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(JsonConvert.DeserializeObject<object>(responseBody).ToString());
				return null;
			}
		}

		public async Task<object> checkProgress(string id)
		{
			string url = $"https://api.shodan.io/shodan/scan/{id}?key={_apiKey}";
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}

		public async Task<object> getProfile()
		{
			string url = $"https://api.shodan.io/account/profile?key={_apiKey}";
			string responseBody = String.Empty;

			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(url);
				responseBody = await response.Content.ReadAsStringAsync();
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<object>(responseBody);
			}
			catch(HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");	
				Console.WriteLine($"Message: {e.Message}");
				Console.WriteLine($"URL used: {url}");
				Console.WriteLine("Response: ");
				Console.WriteLine(responseBody);
				return null;
			}
		}

	}
}
