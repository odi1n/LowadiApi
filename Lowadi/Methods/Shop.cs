using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Lowadi.Interface.Methods;
using Lowadi.Models;
using Lowadi.Models.Shop;
using Lowadi.Models.Type.Shops;
using Lowadi.Others;
using Newtonsoft.Json;
using JsonConvert = Lowadi.Others.JsonConvert;

namespace Lowadi.Methods
{
    public class Shop : IShop
    {
        private Request _request;

        private const string PageMain = "https://www.lowadi.com";
        private const string Achat = PageMain + "/marche/achat";
        private const string Vente = PageMain + "/marche/vente";
        private const string GetInfo = PageMain + "/marche/boutiqueVendre";

        public Shop(Request request)
        {
            _request = request;
        }

        /// <summary>
        /// Купить товар в магазине
        /// </summary>
        /// <param name="ShopData">Данные</param>
        /// <returns></returns>
        public async Task<ShopInfo> Buy(ShopData ShopData)
        {
            using (var response = await _request.PostAsync(Achat, ShopData.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ShopInfo>(content);
            }
        }

        /// <summary>
        /// Продать товар
        /// </summary>
        /// <param name="ShopData">Данные</param>
        /// <returns></returns>
        public async Task<ShopInfo> Sale(ShopData ShopData)
        {
            using (var response = await _request.PostAsync(Vente, ShopData.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ShopInfo>(content);
            }
        }

        /// <summary>
        /// Получить информацию о своих продуктах
        /// </summary>
        /// <param name="items">Продукты о которых нужно получить информацию</param>
        /// <returns></returns>
        public async Task<IList<ShopInformation>> GetInformation(List<ItemsType> items)
        {
            List<ShopInformation> shopInformation = new List<ShopInformation>();

            using (var response = await _request.GetAsync(GetInfo))
            {
                string content = await response.Content.ReadAsStringAsync();

                var doc = new HtmlParser().ParseDocument(content);
                foreach (ItemsType item in items)
                {
                    var count = "0";
                    if (doc.QuerySelector($"span[id^=\"inventaire{item.GetHashCode()}\"]") != null)
                        count = doc.QuerySelector($"span[id^=\"inventaire{item.GetHashCode()}\"]").Text();
                    shopInformation.Add(new ShopInformation() { ItemsType = item, Count = int.Parse(count) });
                }

                return shopInformation;
            }
        }
    }

    public class ShopInformation
    {
        public ItemsType ItemsType { get; set; }
        public int Count { get; set; }
    }

    public partial class ShopInfo
    {
        [JsonProperty("errorsText")] public string ErrorsText { get; set; }

        [JsonProperty("messageText")] public string MessageText { get; set; }

        [JsonProperty("message")] public List<string> Message { get; set; }

        [JsonProperty("retour")] public string Retour { get; set; }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("nombre")] public long Nombre { get; set; }

        [JsonProperty("montant")] public long Montant { get; set; }

        [JsonProperty("updatedCurrency")] public long UpdatedCurrency { get; set; }
    }
}