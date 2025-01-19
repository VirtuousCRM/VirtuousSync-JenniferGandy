using RestSharp;
using Sync.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sync
{
    /// <summary>
    /// API Docs found at https://docs.virtuoussoftware.com/
    /// </summary>
    internal class VirtuousService
    {
        private readonly RestClient _restClient;

        public VirtuousService(IConfiguration configuration)
        {
            var apiBaseUrl = configuration.GetValue("VirtuousApiBaseUrl");
            var apiKey = configuration.GetValue("VirtuousApiKey");

            var options = new RestClientOptions(apiBaseUrl)
            {
                Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(apiKey)
            };

            _restClient = new RestClient(options);
        }

        public async Task<PagedResult<AbbreviatedContact>> GetContactsAsync(int skip, int take)
        {
            var response = new PagedResult<AbbreviatedContact>();

            try
            {
                var request = new RestRequest("/api/Contact/Query", Method.Post);
                request.AddQueryParameter("Skip", skip);
                request.AddQueryParameter("Take", take);

                var body = new ContactQueryRequest();

                body.Groups = new List<Group>()
            {
                new Group
                {
                    Conditions = new List<Condition>()
                    {
                        new Condition
                        {
                            Parameter = "state",
                            Operator = "contains",
                            Value = "Arizona"
                        }
                    }
                }
            };

                request.AddJsonBody(body);

                response = await _restClient.PostAsync<PagedResult<AbbreviatedContact>>(request);
                
            }

            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }

            return response;
        }
    }
}
