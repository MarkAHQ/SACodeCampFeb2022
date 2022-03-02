using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharpExample
{
    [TestClass]
    public class AusPostTests
    {
        [TestMethod]
        public void PostCalc_PCSearch_VerifyPostcode()
        {
            // Arrange
            RestClient client = new RestClient("https://digitalapi.auspost.com.au");
            RestRequest request = new RestRequest("/postcode/search.json");
            request.AddHeader("auth-key", "88737804-3df1-492c-9b97-9ad4a4bdcfe9");
            request.AddParameter("q", "Oxley");
            request.AddParameter("state", "qld");

            // Act
            var response = client.ExecuteGetAsync(request);

            // Assert
            dynamic jsonBody = JsonConvert.DeserializeObject(response.Result.Content);

            Assert.IsTrue(jsonBody.localities.locality.postcode == 4075);
        }
    }
}