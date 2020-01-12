using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shodan;


namespace shodanTests
{
    [TestClass]
    public class UnitTests
    {
		private static string apiKey = System.IO.File.ReadAllText(@"/home/joel/Documents/shodanApi.key");
		private ShodanClient shodanClient = new ShodanClient(apiKey);

        [TestMethod]
        public async Task testSearchHost()
        {
			// Arrange
			string ip = "8.8.8.8";

			// Act
			object result = await shodanClient.searchHost(ip);

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
