using Khayati.Core.Common.IOption;

namespace Khayati.Infrastructure.Common.Options
{
    public class JwtSettingsOptions: IJwtSettingsOptions
    {
        public int? DurationInMinutes { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public string? Key { get; set; }


    }
}
