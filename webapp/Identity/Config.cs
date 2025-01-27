
using IdentityServer4.Models;

namespace Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource{
                Name= "role",
                UserClaims = new List<string> { "role" }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new[] {
            new ApiScope("JobspotApi.read"),
            new ApiScope("JobspotApi.write"),
        };

        public static IEnumerable<ApiResource> ApiResources => new[] {
            new ApiResource("JobspotApi"){
                Scopes = new List<string> {
                    "JobspotApi.read",
                    "JobspotApi.write",
                },
                ApiSecrets = new List<Secret> {
                    new Secret("JobspotApiSecret".Sha256())
                },
                UserClaims = new List<string> { 
                    "role", 
                }
            }
        };

        public static IEnumerable<Client> Clients => new[] {
            new Client{ 
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { 
                    new Secret("JobspotClientSecret".Sha256()),
                },
                AllowedScopes = {
                    "JobspotApi.read",
                    "JobspotApi.write",
                }
            },
            new Client{
                ClientId = "interactive",
                ClientSecrets = {
                    new Secret("JobspotClientSecret".Sha256()),
                },        
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                RedirectUris = { "https://localhost:7205/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7205/signout-oidc" ,
                PostLogoutRedirectUris = { "https://localhost:7205/signout-callback-oidc" },
                AllowOfflineAccess = true,
                RequirePkce = true,
                RequireConsent  = true,
                AllowPlainTextPkce = false,
                AllowedScopes = {
                    "JobspotApi.read",
                    "JobspotApi.write",
                }
            },
        };
    }
}
