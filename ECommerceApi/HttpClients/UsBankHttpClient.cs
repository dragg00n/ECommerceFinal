using ECommerceApi.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceApi.HttpClients
{
    public class UsBankHttpClient : IUsBankHttpClient
    {

        private readonly HttpClient _client;

        public UsBankHttpClient(HttpClient client)
        {
            _client = client;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ECommerce-Api");
        }

        public virtual async Task<CreditCardAuthorizationResponse> AuthorizeAsync(CreditCardAuthorizationRequest creditCardInfo)
        {
            var response = await _client.PostAsJsonAsync("/card-authorizations", creditCardInfo);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStreamAsync();
            var auth = await JsonSerializer.DeserializeAsync<CreditCardAuthorizationResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return auth;
        }
    }
}
