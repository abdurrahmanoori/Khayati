using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Khayati.Infrastructure.Common.Options
{
    public class JwtSettingsOtptionsSetup : IConfigureOptions<JwtSettingsOptions>
    {
        private const string ConfigurationSectionName = "JwtSettings";
        private readonly IConfiguration _configuration;

        public JwtSettingsOtptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtSettingsOptions options)
        {
            //var connectionstring = _configuration.GetConnectionString("JwtSettings");

            //options.ConnectionString = connectionstring;
          var result =   _configuration.GetSection((ConfigurationSectionName));

        var JwtKey =   _configuration.GetValue<string>("Key");

            _configuration.GetSection(ConfigurationSectionName).Bind(options);
                
        }
    }
}
