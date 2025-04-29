using RestSharp;

namespace XUnitPlayground
{
    public class ApiBaseTest
    {
        public readonly RestClient _client;

        public ApiBaseTest()
        {
            _client = new RestClient("https://petstore.swagger.io/v2");
        }

        public async Task<long> CreateTestPetAsync(string name = "TestPet", string status = "available")
        {
            long id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            var pet = new
            {
                id,
                name,
                status
            };

            var request = new RestRequest("pet", Method.Post)
                .AddJsonBody(pet);

            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new Exception($"Failed to create test pet. Status: {response.StatusCode}");

            return id;
        }

        public async Task DeleteTestPetAsync(long id)
        {
            var request = new RestRequest($"pet/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful && response.StatusCode != System.Net.HttpStatusCode.NotFound)
                throw new Exception($"Failed to delete pet {id}. Status: {response.StatusCode}");
        }
    }
}
