using System.Collections.Generic;

namespace Lowadi.Models
{
    public enum LanguageType
    {
        EN, US, UK, AU, CA, DE, FR, ES, PT, BR, IL, RU, IT, NL, SE, PL, CZ, DK, FI, NO, AR, HU, RO, BG, SI, SK
    }

    public class Language
    {
        public LanguageType LanguageType { get; set; }
        public string Link { get; set; }
    }
}