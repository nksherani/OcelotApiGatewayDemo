using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer
{

    public class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> resources = new List<ApiResource>();
            ApiResource resource = new ApiResource();
            resource.DisplayName = "My Resource API";
            resource.Name = "myresourceapi";
            resource.Scopes = new List<string> { "apiscope" };
            resources.Add(resource);
            return resources;
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>{
            new Client
            {
                ClientId = "secret_client_id",
                ClientName = "Example client application using client credentials",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("secret".Sha256())}, // change me!
                AllowedScopes = new List<string> {"apiscope"}
            }
        };
        }

    }
}
