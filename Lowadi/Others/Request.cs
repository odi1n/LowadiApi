using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lowadi.Others
{
    public class Request
    {
        private HttpClient _httpClient;

        public Request()
        {
            HttpClientHandler handler = new HttpClientHandler() { AllowAutoRedirect = true };
            _httpClient = new HttpClient(handler);
        }

        public void AddHeader(string name, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(name, value);
        }

        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> param = null)
        {
            return await _httpClient.GetAsync(new Uri(url) + await param.ParamToString());
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string param)
        {
            return await _httpClient.GetAsync(new Uri(new Uri(url), param));
        }

        public async Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> param)
        {
            return await _httpClient.PostAsync(new Uri(url), param.ItsNull());
        }

        public async Task<HttpResponseMessage> PostAsync(string url, string param)
        {
            return await _httpClient.PostAsync(new Uri(url),
                new StringContent(param, Encoding.UTF8, "application/x-www-form-urlencoded"));
        }

        public string GetCookie(Uri uri)
        {
            CookieContainer cookies = new CookieContainer();
            IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
            foreach (Cookie cookie in responseCookies)
                Console.WriteLine(cookie.Name + ": " + cookie.Value);
            return null;
        }
    }
}