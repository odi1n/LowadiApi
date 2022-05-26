using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Lowadi.Interface.Methods;
using Lowadi.Models;
using Lowadi.Models.Shop;
using Lowadi.Models.Type.Shops;
using Lowadi.Others;
using JsonConvert = Lowadi.Others.JsonConvert;

namespace Lowadi.Methods
{
    public class Shop : IShop
    {
        private Request _request;

        private static string PageMain { get; set; }
        private static string Achat => PageMain + "/marche/achat";
        private static string Vente => PageMain + "/marche/vente";
        private static string GetInfo => PageMain + "/marche/boutiqueVendre";

        public Shop(Request request, Server server)
        {
            PageMain = server.Link;
            _request = request;
        }

        /// <summary>
        /// Купить товар в магазине
        /// </summary>
        /// <param name="ShopData">Данные</param>
        /// <returns></returns>
        public async Task<Buy> Buy(ShopData ShopData)
        {
            using (var response = await _request.PostAsync(Achat, ShopData.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<Buy>(content);
            }
        }

        /// <summary>
        /// Продать товар
        /// </summary>
        /// <param name="ShopData">Данные</param>
        /// <returns></returns>
        public async Task<Sell> Sale(ShopData ShopData)
        {
            using (var response = await _request.PostAsync(Vente, ShopData.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<Sell>(content);
            }
        }

        /// <summary>
        /// Получить информацию о своих продуктах
        /// </summary>
        /// <param name="items">Продукты о которых нужно получить информацию</param>
        /// <returns></returns>
        public async Task<IList<ItemsInfo>> GetInformation(List<ItemsType> items)
        {
            List<ItemsInfo> shopInformation = new List<ItemsInfo>();

            using (var response = await _request.GetAsync(GetInfo))
            {
                string content = await response.Content.ReadAsStringAsync();

                var doc = new HtmlParser().ParseDocument(content);
                foreach (ItemsType item in items)
                {
                    var count = "0";
                    if (doc.QuerySelector($"span[id^=\"inventaire{item.GetHashCode()}\"]") != null)
                        count = doc.QuerySelector($"span[id^=\"inventaire{item.GetHashCode()}\"]").Text();
                    shopInformation.Add(new ItemsInfo() { ItemsType = item, Count = int.Parse(count) });
                }

                return shopInformation;
            }
        }
    }
}