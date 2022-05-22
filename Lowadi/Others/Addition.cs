using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lowadi.Others
{
    internal static class Addition
    {
        public static FormUrlEncodedContent ItsNull(this Dictionary<string, string> param)
        {
            if (param != null)
                return new FormUrlEncodedContent(param);
            else
                return new FormUrlEncodedContent(new Dictionary<string, string>());
        }

        public static async Task<string> ParamToString(this Dictionary<string, string> param)
        {
            if (param != null)
                return "?" + await new FormUrlEncodedContent(param).ReadAsStringAsync();
            else
                return "";
        }

        public static async Task<string> RespToString(this HttpResponseMessage response)
        {
            // Stream str = await response.Content.ReadAsStreamAsync();
            // StreamReader readStream = new StreamReader (str, Encoding.UTF8);
            // string readToEnd = readStream.ReadToEnd();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
