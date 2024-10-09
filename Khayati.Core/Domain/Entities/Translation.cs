using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.Domain.Entities
{
    public class Translation
    {
        public int TranslationId { get; set; }
        public string EntityType { get; set; }  // e.g., "Province", "District"
        public int EntityId { get; set; }       // ID of the entity being translated (ProvinceId, DistrictId)
        public string LanguageCode { get; set; }  // Language code like "en", "fr"
        public string PropertyName { get; set; }  // e.g., "ProvinceName"
        public string TranslatedValue { get; set; }  // Translated text
    }
}
