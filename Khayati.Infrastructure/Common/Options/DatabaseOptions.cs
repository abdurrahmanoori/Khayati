using Khayati.Core.Common.IOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Infrastructure.Common.Options
{
    public class DatabaseOptions : IDatabaseOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public bool EnableDetailErrors { get ; set ; }
        public bool EnableSensitiveDataLoggin { get ; set ; }
    }
}
