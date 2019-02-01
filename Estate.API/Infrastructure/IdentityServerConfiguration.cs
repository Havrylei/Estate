using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;

namespace Estate.API.Infrastructure
{
    internal static class IdentityServerConfiguration
    {
        internal const string SCOPE_NAME = "Estate.API";
        internal const string CLIENT_NAME = "Estate.Client";

        public static List<IdentityResource> GetIdentityResources() => 
            new List<IdentityResource> 
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static List<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                new ApiResource(SCOPE_NAME)
            };

        public static List<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = CLIENT_NAME,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("SuperSecret".Sha256())
                    },
                    AllowedScopes = { SCOPE_NAME }
                }
            };

        public static List<TestUser> GetUsers() => 
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(),
                    Username = "Jack",
                    Password = "qwerty"
                }
            };
    }
}
