using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer
{

    public class Config
    {


        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>{
                new ApiScope(name: "apiscope",   displayName: "Read your data."),
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
             };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource("myresourceapi", "My Resource API"){Scopes={ "myresourceapi.apiscope" }}, 
                new ApiResource("mysecondapi", "My Second API"){Scopes={ "mysecondapi.read" }}
            };
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
                AllowedScopes = {"apiscope","read"}
            }
        };
        }

    }
}
