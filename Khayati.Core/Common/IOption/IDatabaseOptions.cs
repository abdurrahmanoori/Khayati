namespace Khayati.Core.Common.IOption
{
    public interface IDatabaseOptions
    {
        public string ConnectionString { get; set; }
        
        public bool EnableDetailErrors { get; set; }
        public bool EnableSensitiveDataLoggin { get; set; }

    }
}
