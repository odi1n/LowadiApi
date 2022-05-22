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

        private Request _request { get; set; }

        public LowadiApi()
        {
            _request = new Request();
        }

        public async Task<ErrorModels> Login(string login, string password)
        {
            IAuth auth = new Auth(login, password, _request);
            var authData = await auth.Oauth();

            Horse = new Horse(_request);
            HorseSale = new HorseSale(_request);
            Shop = new Shop(_request);

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