using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace AusPostPostCalc
{
    [TestClass]
    public class PostCalculatorSuite
    {
        [TestMethod]
        public void TestPostCode_PCSearch_VerifyPostCode()
        {
            // Arrange
            RestClient client = new RestClient("https://digitalapi.auspost.com.au/");
            RestRequest request = GetSearchRequest();

            // Act
            var result = client.ExecuteAsync(request);

            // Assert
            var jsonBody = JsonConvert.DeserializeObject<PostcodeSearchResponse>(result.Result.Content);
            var expectedResult = 4075;

            Assert.AreEqual(expected: jsonBody.Localities?.Locality?.Postcode, actual: expectedResult);
        }

        private static RestRequest GetSearchRequest()
        {
            RestRequest request = new RestRequest("/postcode/search.json");
            request.AddHeader("auth-key", "88737804-3df1-492c-9b97-9ad4a4bdcfe9");
            request.AddParameter("q", "Oxley");
            request.AddParameter("state", "qld");
            return request;
        }
    }
}