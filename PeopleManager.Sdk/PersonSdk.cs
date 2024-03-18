using PeopleManager.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace PeopleManager.Sdk
{
    public class PersonSdk
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonSdk(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IList<Person>> Find()
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var route = "/api/people";
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var people = await response.Content.ReadFromJsonAsync<IList<Person>>();

            if (people is null)
            {
                return new List<Person>();
            }

            return people;
        }
    }
}
