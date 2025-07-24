namespace Khayati.Core.Common.IOption
{
    public interface IJwtSettingsOptions
    {
        public int? DurationInMinutes { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public string? Key { get; set; }

    }
}
