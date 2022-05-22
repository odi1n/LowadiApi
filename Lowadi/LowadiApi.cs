using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Lowadi.Interface;
using Lowadi.Interface.Methods;
using Lowadi.Models;
using Lowadi.Methods;
using Lowadi.Others;

namespace Lowadi
{
    public class LowadiApi : ILowadiApi
    {
        /// <summary>
        /// Экю
        /// </summary>
        public static int Equus { get; set; }

        /// <summary>
        /// Пропуск
        /// </summary>
        public static int Pass { get; set; }

        /// <summary>
        /// Лошади
        /// </summary>
        public IHorse Horse { get; set; }

        /// <summary>
        /// Продажа лошадей
        /// </summary>
        public IHorseSale HorseSale { get; set; }

        /// <summary>
        /// Магазин
        /// </summary>
        public IShop Shop { get; set; }

        /// <summary>
        /// Язык
        /// </summary>
        public Language Language { get; private set; }

        private Request _request { get; set; }

        private List<Language> Languages { get; set; } = new List<Language>() {
            new Language() { LanguageType = LanguageType.EN, Link = "https://www.howrse.com" },
            new Language() { LanguageType = LanguageType.US, Link = "https://us.howrse.com" },
            new Language() { LanguageType = LanguageType.UK, Link = "https://www.howrse.co.uk" },
            new Language() { LanguageType = LanguageType.AU, Link = "https://au.howrse.com" },
            new Language() { LanguageType = LanguageType.CA, Link = "https://ca.howrse.com" },
            new Language() { LanguageType = LanguageType.DE, Link = "https://www.howrse.de" },
            new Language() { LanguageType = LanguageType.FR, Link = "https://www.equideow.com" },
            new Language() { LanguageType = LanguageType.ES, Link = "https://www.caballow.com" },
            new Language() { LanguageType = LanguageType.PT, Link = "https://www.howrse.com.pt" },
            new Language() { LanguageType = LanguageType.BR, Link = "https://br.howrse.com" },
            new Language() { LanguageType = LanguageType.IL, Link = "https://www.howrse.co.il" },
            new Language() { LanguageType = LanguageType.RU, Link = "https://www.lowadi.com" },
        };

        public LowadiApi(LanguageType languageType = LanguageType.RU)
        {
            this.Language = Languages.First(x => x.LanguageType == languageType);
            _request = new Request();
        }

        public async Task<ErrorModels> Login(string userName, string password)
        {
            IAuth auth = new Auth(_request, Language);
            var authData = await auth.Oauth(userName, password);

            Horse = new Horse(_request, Language);
            HorseSale = new HorseSale(_request, Language);
            Shop = new Shop(_request, Language);

            return JsonConvert.Deserialize<ErrorModels>(authData);
        }

        internal static void GetBalance(string page)
        {
            var doc = new HtmlParser().ParseDocument(page);
            string equus = doc.GetElementById("reserve").GetAttribute("data-amount");
            string pass = doc.GetElementById("pass").GetAttribute("data-amount");

            Equus = int.Parse(equus);
            Pass = int.Parse(pass);
        }
    }
}