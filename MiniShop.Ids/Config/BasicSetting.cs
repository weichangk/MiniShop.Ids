namespace MiniShop.Ids.Config
{
    public class BasicSetting
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 自宿主启动IP端口
        /// </summary>
        public string Urls { get; set; } = "http://*:15101";
        /// <summary>
        /// 主程序集名称
        /// </summary>
        public string AssemblyName { get; set; }


        public string MiniShopBackendWeb_Url { get; set; }
        public string MiniShopBackendWeb_Id { get; set; }
        public string MiniShopBackendWeb_Name { get; set; }
        public string MiniShopBackendWeb_Secret { get; set; }
        public string MiniShopBackendWeb_AccessTokenLifetime { get; set; }
        public string MiniShopBackendWeb_AllowedScopes { get; set; }

        public string MiniShopPlatformApiResource_Name { get; set; }
        public string MiniShopPlatformApiResource_DisplayName { get; set; }
        public string MiniShopPlatformApiResource_Secret { get; set; }
        public string MiniShopPlatformApiResource_Scopes { get; set; }

        public string MiniShopBackendApiResource_Name { get; set; }
        public string MiniShopBackendApiResource_DisplayName { get; set; }
        public string MiniShopBackendApiResource_Secret { get; set; }
        public string MiniShopBackendApiResource_Scopes { get; set; }
        public string MiniShopBackendApiResource_UserClaims { get; set; }

        public string UserClaimExtras_Name { get; set; }
        public string UserClaimExtras_DisplayName { get; set; }
        public string UserClaimExtras_UserClaims { get; set; }


        public static BasicSetting Setting { get; set; } = new BasicSetting();
    }
}