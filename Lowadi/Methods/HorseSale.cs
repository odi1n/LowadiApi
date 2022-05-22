using System;
using System.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Lowadi.Interface.Methods;
using Lowadi.Models;
using Lowadi.Models.Type;
using Lowadi.Others;
using Newtonsoft.Json;
using JsonConvert = Lowadi.Others.JsonConvert;

namespace Lowadi.Methods
{
    public class HorseSale : IHorseSale
    {
        private Request _request;

        private static string PageMain { get; set; }
        private readonly string _pageLink = PageMain + "/marche/vente/index";
        private readonly string _pageBuy = PageMain + "/marche/vente/prive/doAcheter";

        public HorseSale(Request request, Language language)
        {
            PageMain = language.Link;
            this._request = request;
        }

        /// <summary>
        /// Получить лошадей продажи
        /// </summary>
        /// <param name="typeSale">Тип покупки</param>
        /// <param name="page">Номер страницы с лошадьми</param>
        /// <returns></returns>
        public async Task<ICollection<Corrals>> GetHorses(TypeSale typeSale = TypeSale.Reserved, int page = 0)
        {
            string prive = "";
            if (typeSale == TypeSale.Auctions) prive = "enchere";
            if (typeSale == TypeSale.Straight) prive = "modificationDate";
            if (typeSale == TypeSale.Reserved) prive = "prive";

            Dictionary<string, string> param = new Dictionary<string, string>() {
                ["type"] = prive, ["tri"] = "modificationDate", ["sens"] = "DESC", ["page"] = page.ToString(),
            };

            using (var response = await _request.GetAsync(_pageLink, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                LowadiApi.GetBalance(content);
                return ParseHorse(content);
            }
        }

        private List<Corrals> ParseHorse(string pageData)
        {
            var doc = new HtmlParser().ParseDocument(pageData);
            List<Corrals> corralsList = new List<Corrals>();

            foreach (var element in doc.Body.QuerySelectorAll("#vente-chevaux>table>tbody>tr"))
            {
                if (element.QuerySelector("td:nth-child(5)>table>tbody>tr:nth-child(1)>td>img") == null)
                    break;

                var sex = element.QuerySelector("td:nth-child(5)>table>tbody>tr:nth-child(1)>td>img")
                    .GetAttribute("alt");
                var name = element.QuerySelector("td:nth-child(5)>table>tbody>tr:nth-child(2)>td>a").Text();
                var skills = element.QuerySelector("td:nth-child(7)>span>span>span:nth-child(1)>div").Text();
                var genetics = element.QuerySelector("td:nth-child(7)>span>span>span:nth-child(2)>span").Text();
                var date = element.QuerySelector("td:nth-child(9)>small").Text();
                var price = element.QuerySelector("td:nth-child(10)>div>div>div>span>strong").Text();
                string linkBuy = element.QuerySelector("td:nth-child(10)>div>div>script").Text();
                linkBuy = Regex.Match(linkBuy, "'params': '(.*?)'}").Groups[1].ToString();

                corralsList.Add(new Corrals() {
                    SexType = sex == "male" ? SexType.Male : SexType.Male,
                    Name = name,
                    Skills = Int32.Parse(skills),
                    Genetics = Int32.Parse(genetics),
                    Date = DateTime.Parse(date),
                    Price = Int32.Parse(price),
                    LinkBuy = HttpUtility.UrlDecode(linkBuy)
                });
            }

            return corralsList;
        }

        /// <summary>
        /// Купить лошадб
        /// </summary>
        /// <param name="linkBuy">Ссылка на покупку</param>
        /// <returns></returns>
        public async Task<BuyHorse> DoAcheter(string linkBuy)
        {
            using (var response = await _request.PostAsync(_pageBuy, linkBuy))
            {
                string content = await response.Content.ReadAsStringAsync();
                return new BuyHorse() {
                    Buy = JsonConvert.Deserialize<Buy>(content), Error = JsonConvert.Deserialize<ErrorModels>(content),
                };
            }
        }
    }
}