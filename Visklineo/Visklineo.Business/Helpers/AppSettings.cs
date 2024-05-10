using Microsoft.Extensions.Configuration;

namespace Visklineo.Business.Helpers
{
    public class AppSettings
    {
        private static IConfigurationSection _configuration;
        public static void Configure(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }

        public static string WebSiteDomain => _configuration["WebSiteDomain"];
        public static string WebApi => _configuration["WebApi"];
        public static string WebSiteName => _configuration["WebSiteName"];
        public static string Token => _configuration["JwtSecret"];
        public static string Issuer => _configuration["Issuer"];
    }
}