/* TODO
 * Declare all Shodan API methods in the Interface
 * Implement the Interface in the ShodanClient class
*/

using System;
using System.Threading.Tasks;

namespace Shodan
{
    class Program
    {
        static async Task Main(string[] args)
        {
			//if (args.Length != 1)
			//{
			//	Console.WriteLine("Usage: Shodan <apiKey.txt>");
			//	System.Environment.Exit(1);
			//}

			//string apiKey = System.IO.File.ReadAllText(args[0]);
			string apiKey = System.IO.File.ReadAllText(@"/home/joel/Documents/shodanApi.key");
			
			ShodanClient shodanClient = new ShodanClient(apiKey);

			while(true)
			{
				// Print menu
				Console.WriteLine("Possible commands:");
				Console.WriteLine("host - search host based on IP");
				Console.WriteLine("count - count matching devices");
				Console.WriteLine("search - search matching devices");
				Console.WriteLine("ports - list all ports that shodan is crawling");
				Console.WriteLine("facets - list all facets");
				Console.WriteLine("filters - list all filters");
				Console.WriteLine("tokens - show tokens for entered query");
				Console.Write(">>> ");
				
				string input = Console.ReadLine();	

				if (input == "host")
				{
					Console.Write("IP: ");
					string ip = Console.ReadLine();

                    object searchResult = await shodanClient.searchHost(ip);
					if (searchResult != null) {Console.WriteLine(searchResult.ToString());}
				}
				else if (input == "count")
				{
					Console.Write("Query: ");
					string query = Console.ReadLine();

					Console.Write("Facets (Optional): ");
					string facets = Console.ReadLine();

					object searchResult = await shodanClient.count(query, facets);
					if (searchResult != null) {Console.WriteLine(searchResult.ToString());}
				}
				else if (input == "search")
				{
					Console.Write("Query: ");
					string query = Console.ReadLine();

					Console.Write("Facets (Optional): ");
					string facets = Console.ReadLine();

					object searchResult = await shodanClient.search(query, facets);
					if (searchResult != null) {Console.WriteLine(searchResult.ToString());}
				}
				else if (input == "ports")
				{
					object searchResult = await shodanClient.listCrawledPorts();
					if (searchResult != null) {Console.WriteLine(searchResult.ToString());}
				}
				else if (input == "facets")
				{
					object searchResult = await shodanClient.listFacets();
					if (searchResult != null) {Console.WriteLine(searchResult.ToString());}
				}
				else if (input == "filters")
				{
					object searchResult = await shodanClient.listFilters();
					if (searchResult != null) {Console.WriteLine(searchResult.ToString());}
				}
				else if (input == "tokens")
				{
					Console.Write("Query: ");
					string query = Console.ReadLine();
					object searchResult = await shodanClient.showTokens(query);
					if (searchResult != null) {Console.WriteLine(searchResult.ToString());}
				}

				Console.WriteLine("Press ENTER to return to menu");
				Console.ReadLine();
			}
		}
	}
}
