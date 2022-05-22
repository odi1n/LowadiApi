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
        private readonly string _achat = PageMain + "/marche/achat";
        private readonly string _vente = PageMain + "/marche/vente";
        private readonly string _getInfo = PageMain + "/marche/boutiqueVendre";

        public Shop(Request request, Language language)
        {
            PageMain = language.Link;
            _request = request;
        }

        /// <summary>
        /// Купить товар в магазине
        /// </summary>
        /// <param name="ShopData">Данные</param>
        /// <returns></returns>
        public async Task<PurchaseInfo> Buy(ShopData ShopData)
        {
            using (var response = await _request.PostAsync(_achat, ShopData.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<PurchaseInfo>(content);
            }
        }

        /// <summary>
        /// Продать товар
        /// </summary>
        /// <param name="ShopData">Данные</param>
        /// <returns></returns>
        public async Task<PurchaseInfo> Sale(ShopData ShopData)
        {
            using (var response = await _request.PostAsync(_vente, ShopData.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<PurchaseInfo>(content);
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

            using (var response = await _request.GetAsync(_getInfo))
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