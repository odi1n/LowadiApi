using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Lowadi.Attribute;
using Lowadi.Models.Type.Ksk;

namespace Lowadi.Models.Ksk
{
    public class Inscription
    {
        [Required] public int Cheval { get; set; }
        public string Elevage { get; set; }
        public double Competence { get; set; }

        public TriType TriType { get; set; } = TriType.Prestige;
        public SendType Sens { get; set; } = SendType.Asc;

        [Range(20, 200)] public int? Tarif { get; set; }
        [Range(0, 60)] public int? LeconsPrix { get; set; }

        public bool? Foret { get; set; } = null;
        public bool? Montagne { get; set; } = null;
        public bool? Plage { get; set; } = null;

        public bool? Classique { get; set; } = null;
        public bool? Western { get; set; } = null;

        public bool? Fourrage { get; set; } = null;
        public bool? Avoine { get; set; } = null;
        public bool? Carotte { get; set; } = null;
        public bool? Mash { get; set; } = null;
        public bool? HasSelles { get; set; } = null;
        public bool? HasBrides { get; set; } = null;
        public bool? HasTapis { get; set; } = null;
        public bool? HasBonnets { get; set; } = null;
        public bool? HasBandes { get; set; } = null;
        public bool? Hbreuvoir { get; set; } = null;
        public bool? Douche { get; set; } = null;

        public string Centre { get; set; }
        public int CentreBox { get; set; }
        public string Directeur { get; set; }
        [Range(0, 100)] public int? Prestige { get; set; }
        [Range(1, 40)] public int? Bonus { get; set; }

        public BotType? BoxType { get; set; }
        public LitterType BoxLitiere { get; set; }
        [Range(0, 100)] public int? PrePrestige { get; set; }

        public SellesType ProdSellesType { get; set; }
        public BridesType ProdBridesType { get; set; }
        public TapisType ProdTapisType { get; set; }
        public BonnetsType ProdBonnetsType { get; set; }
        public BandesType PropdBandesType { get; set; }

        private string GetDescription(Enum enumElement)
        {
            System.Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(StringValueAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((StringValueAttribute)attrs[0]).StringValue;
            }

            return enumElement.GetHashCode().ToString();
        }

        private string SetValue(PropertyInfo prop)
        {
            string value = "";
            var getValue = prop.GetValue(this, null);

            if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(string))
                value = getValue?.ToString();
            else if (prop.PropertyType == typeof(bool?))
            {
                value = getValue == null ? "2" : getValue.GetHashCode().ToString();
            }
            else if (prop.PropertyType.IsEnum)
            {
                var convertedValue = Enum.Parse(prop.PropertyType, getValue.ToString(), false);
                var description = GetDescription((Enum)convertedValue);
                if (description == "0")
                    return null;
                value = description;
            }

            return value;
        }

        private string FirstLower(string line)
        {
            return line.Substring(0, 1).ToLower() + (line.Length > 1 ? line.Substring(1) : "");
        }

        public Dictionary<string, string> GetParam()
        {
            Dictionary<string, string> data = this.GetType()
                .GetProperties()
                .ToDictionary(
                    prop => FirstLower(prop.Name),
                    SetValue);
            return data;
        }
    }
}