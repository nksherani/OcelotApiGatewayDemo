﻿//using IdentityServer4.Models;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AuthServer.ConfigStore
//{
//    public class SeedAuthData
//    {
//        public static void Seed(ConfigurationStoreContext context)
//        {
//            Client client = new Client
//            {

//                ClientId = "secret_client_id",
//                ClientName = "abc",
//                AllowedGrantTypes = GrantTypes.ClientCredentials,
//                ClientSecrets = new List<Secret> { new Secret("secret".Sha256()) }, // change me!
//                AllowedScopes = { "openid", "read" },

//                //Claims = {new ClientClaim("aud","myresourceapi")}

//            };
//            client.AllowedGrantTypes.Add(GrantType.ResourceOwnerPassword);
//            ClientEntity clientEntity = new ClientEntity() { ClientId = "secret_client_id", ClientData = JsonConvert.SerializeObject(client) };

//            ApiResource resource = new ApiResource();
//            resource.Name = "myresourceapi";
//            resource.DisplayName = "myresourceapi";
//            resource.Description = "myresourceapi";
//            //resource.Properties.Add("aud", "https://localhost:443");
//            resource.Scopes = new List<string> { "myresourceapi.openid" };

//            ApiResourceEntity resourceEntity = new ApiResourceEntity() { ApiResourceName = "myresourceapi", ApiResourceData = JsonConvert.SerializeObject(resource) };

//            var scope = new ApiScope(name: "openid", displayName: "Read your data.");
//            ScopeEntity scopeEntity = new ScopeEntity() { ApiScopeName = "openid", ApiScopeData = JsonConvert.SerializeObject(scope) };
//            context.Add(clientEntity);

//            IdentityResource identityResource = new IdentityResource();
//            identityResource.Name = "naveed";
//            identityResource.DisplayName = "naveed";
//            identityResource.UserClaims = new List<string>() { "role" };

//            var identityResourceEntity = new IdentityResourceEntity() { ID = "naveed", IdentityResourceName = "naveed", IdentityResourceData = JsonConvert.SerializeObject(identityResource) };


//            context.Add(identityResourceEntity);
//            context.Add(resourceEntity);
//            context.Add(scopeEntity);
//            context.SaveChanges();
//        }
//    }
//}
