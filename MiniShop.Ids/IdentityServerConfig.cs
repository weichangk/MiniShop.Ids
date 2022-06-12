using IdentityModel;
using IdentityServer4.Models;
using MiniShop.Ids.Config;
using System.Collections.Generic;

namespace MiniShop.Ids
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Phone(),
            new IdentityResources.Email(),
            new IdentityResource("roles", "user roles", new List<string> { JwtClaimTypes.Role }),
            new IdentityResource(
                name: BasicSetting.Setting.UserClaimExtras_Name,
                displayName: BasicSetting.Setting.UserClaimExtras_DisplayName,
                userClaims: BasicSetting.Setting.UserClaimExtras_UserClaims.Split(" ")),
        };

        public static IEnumerable<ApiScope> ApiScopes()
        {
            List<ApiScope> apiScope = new List<ApiScope>();
            var miniShopApiScopes = BasicSetting.Setting.MiniShopBackendApiResource_Scopes.Split(" ");
            for (int i = 0; i < miniShopApiScopes.Length; i++)
            {
                apiScope.Add(new ApiScope {Name = miniShopApiScopes[i] });
            }

            var miniShopAdminApiScopes = BasicSetting.Setting.MiniShopPlatformApiResource_Scopes.Split(" ");
            for (int i = 0; i < miniShopAdminApiScopes.Length; i++)
            {
                apiScope.Add(new ApiScope { Name = miniShopAdminApiScopes[i] });
            }

            return apiScope;
        }


        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource(BasicSetting.Setting.MiniShopBackendApiResource_Name, BasicSetting.Setting.MiniShopBackendApiResource_DisplayName)
            {
                ApiSecrets = { new Secret(BasicSetting.Setting.MiniShopBackendApiResource_Secret.Sha256()) },
                Scopes = BasicSetting.Setting.MiniShopBackendApiResource_Scopes.Split(" "),
                //UserClaims = new [] { JwtClaimTypes.Role }
                UserClaims = BasicSetting.Setting.MiniShopBackendApiResource_UserClaims.Split(" "),
            },
            new ApiResource(BasicSetting.Setting.MiniShopPlatformApiResource_Name, BasicSetting.Setting.MiniShopPlatformApiResource_DisplayName)
            {
                ApiSecrets = { new Secret(BasicSetting.Setting.MiniShopPlatformApiResource_Secret.Sha256()) },
                Scopes = BasicSetting.Setting.MiniShopPlatformApiResource_Scopes.Split(" "),
                UserClaims = new [] { JwtClaimTypes.Role }
            }
        };

        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = BasicSetting.Setting.MiniShopBackendWeb_Id,
                ClientName = BasicSetting.Setting.MiniShopBackendWeb_Name,
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                ClientSecrets = { new Secret(BasicSetting.Setting.MiniShopBackendWeb_Secret.Sha256()) },
                RedirectUris = { $"{BasicSetting.Setting.MiniShopBackendWeb_Url}/signin-oidc" },
                FrontChannelLogoutUri = $"{BasicSetting.Setting.MiniShopBackendWeb_Url}/signout-oidc",
                PostLogoutRedirectUris = { $"{BasicSetting.Setting.MiniShopBackendWeb_Url}/signout-callback-oidc" },
                AlwaysIncludeUserClaimsInIdToken = true,
                RequireConsent = false,
                AllowOfflineAccess = true,
                AccessTokenLifetime = int.Parse(BasicSetting.Setting.MiniShopBackendWeb_AccessTokenLifetime),
                AllowedScopes = BasicSetting.Setting.MiniShopBackendWeb_AllowedScopes.Split(" "),
            },
            // wpf client, password grant
            new Client
            {
                ClientId = BasicSetting.Setting.MiniShopFrontendClient_Id,
                ClientName = BasicSetting.Setting.MiniShopFrontendClient_Name,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret(BasicSetting.Setting.MiniShopFrontendClient_Secret.Sha256()) },
                AlwaysIncludeUserClaimsInIdToken = true,
                RequireConsent = false,
                AllowOfflineAccess = true,
                AccessTokenLifetime = int.Parse(BasicSetting.Setting.MiniShopFrontendClient_AccessTokenLifetime),
                AllowedScopes = BasicSetting.Setting.MiniShopFrontendClient_AllowedScopes.Split(" "),
            },
        };
    }
}