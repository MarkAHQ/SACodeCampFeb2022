using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace AusPostExample2
{
    [TestClass]
    public class AusPostSearchTests
    {
        [TestMethod]
        public void PostCode_PCSearch_VerifyPostCode()
        {
            // Arrange
            RestClient client = new RestClient("https://digitalapi.auspost.com.au");
            RestRequest request = new RestRequest("/postcode/search.json");
            request.AddHeader("auth-key", "88737804-3df1-492c-9b97-9ad4a4bdcfe9").
                AddParameter("q", "Oxley").
                AddParameter("state", "Qld");

            // Act
            Task<RestResponse>? response = client.ExecuteAsync(request);
            string? jsonBody = response.Result.Content;
            var postCodeSearchResponse = JsonConvert.DeserializeObject<PostcodeSearchResponse>(jsonBody);

            // Assert
            Assert.AreEqual(expected: postCodeSearchResponse.Localities?.Locality?.Postcode, 
                            actual: 4076);
        }
    }
}