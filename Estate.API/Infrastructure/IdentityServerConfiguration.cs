using IdentityServer4.Models;
using System.Collections.Generic;

namespace Estate.API.Infrastructure
{
    internal static class IdentityServerConfiguration
    {
        internal const string SCOPE_NAME = "Estate.API";
        internal const string CLIENT_NAME = "Estate.Client";

        public static List<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource(SCOPE_NAME)
            };
        }

        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = CLIENT_NAME,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SuperSecret".Sha256())
                    },
                    AllowedScopes = { SCOPE_NAME }
                }
            };
        }


    }
}
