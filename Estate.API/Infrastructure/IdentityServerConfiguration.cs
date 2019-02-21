using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityServer4.IdentityServerConstants;

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
                new ApiResource(SCOPE_NAME) {
                    ApiSecrets = new [] { new Secret("api-secret".Sha256()) },
                    UserClaims  = new [] { JwtClaimTypes.Role }
                }
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
                    AllowedScopes = { SCOPE_NAME, StandardScopes.OpenId, StandardScopes.Profile }
                }
            };

        public static List<TestUser> GetUsers() => 
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(),
                    Username = "Jack",
                    Password = "qwerty",
                    Claims = new []
                    {
                        new Claim(JwtClaimTypes.Name, "Petro Havrylei!"),
                        new Claim(JwtClaimTypes.Role, "Admin")
                    }
                }
            };
    }
}
