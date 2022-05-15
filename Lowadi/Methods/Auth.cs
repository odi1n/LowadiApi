using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lowadi.Others;
using Lowadi.Models;

namespace Lowadi.Methods
{
    public class Auth
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string UserAgent { get; set; } =
            "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36";

        private Request _request { get; set; }

        private const string _pageLogin = "https://www.lowadi.com/site/logIn";
        private const string _pageDoLogin = "https://www.lowadi.com/site/doLogIn";

        public Auth(string userName, string password, Request request)
        {
            this.UserName = userName;
            this.Password = password;
            this._request = request;
        }

        private async Task<HttpResponseMessage> LogIn()
        {
            _request.AddHeader("Upgrade-Insecure-Requests", "1");
            _request.AddHeader("User-Agent", this.UserAgent);
            _request.AddHeader("Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            _request.AddHeader("Sec-Fetch-Site", "none");
            _request.AddHeader("Sec-Fetch-Mode", "navigate");
            _request.AddHeader("Sec-Fetch-User", "?1");
            _request.AddHeader("Sec-Fetch-Dest", "document");
            _request.AddHeader("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7,af;q=0.6");

            return await _request.GetAsync(_pageLogin);
        }

        private AuthModels ParsLogin(string response)
        {
            AuthModels authParam = new AuthModels();

            if (Regex.IsMatch(response, "name=\"(.*?)\" id=\"authentification"))
                authParam.Name = Regex.Match(response, "name=\"(.*?)\" id=\"authentification").Groups[1].Value;

            if (Regex.IsMatch(response, $"value=\"(.*?)\" name=\"{authParam.Name}\""))
                authParam.Value = Regex.Match(response, $"value=\"(.*?)\" name=\"{authParam.Name}\"").Groups[1].Value;

            return authParam;
        }

        private async Task<HttpResponseMessage> DoLogIn(AuthModels param)
        {
            _request.AddHeader("Host", "www.lowadi.com");
            _request.AddHeader("Accept", "text/html, */*; q=0.01");
            _request.AddHeader("X-Requested-With", "XMLHttpRequest");
            _request.AddHeader("User-Agent", this.UserAgent);
            _request.AddHeader("Origin", "https://www.lowadi.com");
            _request.AddHeader("Sec-Fetch-Site", "same-origin");
            _request.AddHeader("Sec-Fetch-Mode", "cors");
            _request.AddHeader("Sec-Fetch-Dest", "empty");
            _request.AddHeader("Referer", _pageLogin);
            return await _request.PostAsync(_pageDoLogin, new Dictionary<string, string>()
            {
                [param.Name] = param.Value,
                ["login"] = this.UserName,
                ["password"] = this.Password,
                ["redirection"] = "https://www.lowadi.com/",
                ["isBoxStyle"] = "",
            });
        }

        public async Task<string> Oauth()
        {
            AuthModels authParams;
            using (var login = await LogIn())
            {
                string content = await login.RespToString();
                if (login.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception("Ошибка статуса loginIn");
                if (string.IsNullOrWhiteSpace(content.ToString()))
                    throw new Exception("Ошибка получения данных loginIn");

                authParams = ParsLogin(content);
                if (authParams == null) throw new Exception("Ошибка получения данных loginIn");
            }

            using (var doLogin = await DoLogIn(authParams))
            {
                if (doLogin.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception("Ошибка статуса doLogin");

                string content = await doLogin.RespToString();
                if (doLogin.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Ошибка получения данных doLogin");
                if (string.IsNullOrWhiteSpace(content)) throw new Exception("Ошибка получения данных doLogin");

                return content;
            }
        }


    }
}