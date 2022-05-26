using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lowadi.Attribute;
using Lowadi.Models.Type;
using Lowadi.Models.Type.Shops;

namespace Lowadi.Models
{
    public class ReqData
    {
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

                if (Enum.IsDefined(typeof(ItemsType), convertedValue))
                    value = ServerData.GetItemId((ItemsType)convertedValue).ToString();
                else
                {
                    var description = GetDescription((Enum)convertedValue);
                    if (description == "0")
                        return null;
                    value = description;
                }
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