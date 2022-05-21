using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Lowadi.Interface.Methods;
using Lowadi.Models;
using Lowadi.Models.Type;
using Lowadi.Others;

namespace Lowadi.Methods
{
    public class Horse : IHorse
    {
        public ISale Sale { get; set; }
        private Request _request;
        private string DataPageHorseInfo { get; set; }

        private const string PageMain = "https://www.lowadi.com";
        private const string PageFactory = PageMain + "/elevage/chevaux/?elevage=all-horses";
        private const string PageGetHorses = PageMain + "/elevage/chevaux/searchHorse";
        private const string PageHorseInfo = PageMain + "/elevage/chevaux/cheval?id=";
        private const string PageDoSuckle = PageMain + "/elevage/chevaux/doSuckle";
        private const string PageDoDrink = PageMain + "/elevage/chevaux/doDrink";
        private const string PageDoStroke = PageMain + "/elevage/chevaux/doStroke";
        private const string PageDoGroom = PageMain + "/elevage/chevaux/doGroom";
        private const string PageDoEatTreat = PageMain + "/elevage/chevaux/doEatTreat";
        private const string PageDoPlay = PageMain + "/elevage/chevaux/doPlay";
        private const string PageDoEat = PageMain + "/elevage/chevaux/doEat";
        private const string PageDoNight = PageMain + "/elevage/chevaux/doNight";
        private const string PageDoAge = PageMain + "/elevage/chevaux/doAge";
        private const string PageDoCentreMission = PageMain + "/elevage/chevaux/doCentreMission";

        public Horse(Request request)
        {
            this._request = request;
            this.Sale = new Sale(request);
        }

        /// <summary>
        /// Получить все заводы
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Factory>> GetFactory()
        {
            List<Factory> factories = new List<Factory>();
            using (var response = await _request.GetAsync(PageFactory))
            {
                string content = await response.Content.ReadAsStringAsync();
                var doc = new HtmlParser().ParseDocument(content);
                foreach (var element in doc.QuerySelectorAll("a.tab-action-select.tab-action"))
                {
                    if (element.GetAttribute("href") == null)
                        continue;

                    string name = element.Text();
                    string id = element.GetAttribute("href");
                    id = Regex.Match(id, "#tab-(.*)").Groups[1].Value;

                    factories.Add(new Factory() { Name = name, Id = int.Parse(id == "all-horses" ? "0" : id), });
                }
            }

            return factories;
        }

        /// <summary>
        /// Получить всех лошадей
        /// </summary>
        /// <param name="idFactory">Номер завода</param>
        /// <returns></returns>
        public async Task<MyHorse> GetAllHorse(int idFactory)
        {
            MyHorse myHorse = new MyHorse() { Horses = new List<Horses>() };
            int pageNumber = 1;

            for (int i = 0; i < pageNumber + 1; i++)
            {
                Dictionary<string, string> param = new Dictionary<string, string>() {
                    ["go"] = "1",
                    ["startingPage"] = i.ToString(),
                    ["id"] = idFactory.ToString(),
                    ["chevalType"] = "",
                    ["chevalEspece"] = "any-all",
                    ["unicorn"] = "2",
                    ["pegasus"] = "2",
                };

                using (var response = await _request.PostAsync(PageGetHorses, param))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var doc = new HtmlParser().ParseDocument(content);

                    string min = "0";
                    string max = "0";
                    if (doc.QuerySelector(".pageNumbering>ul>li.page") != null)
                    {
                        min = doc.QuerySelectorAll(".pageNumbering>ul>li.page>a").First().GetAttribute("data-page");
                        max = doc.QuerySelectorAll(".pageNumbering>ul>li.page>a").Last().GetAttribute("data-page");
                    }

                    if (myHorse.Page == null)
                    {
                        pageNumber = int.Parse(max);
                        myHorse.Page = new Page() { Min = int.Parse(min), Max = int.Parse(max) };
                    }

                    foreach (IElement element in doc.QuerySelectorAll("li.damier-cell>div"))
                    {
                        string id = element.QuerySelector("div>a").GetAttribute("href");
                        id = Regex.Match(id, "id=(.*)").Groups[1].Value;
                        string name = element.QuerySelector("div>ul>li>a").Text();
                        string factory = element.QuerySelector("div>ul>li>a.affixe") == null
                            ? null
                            : element.QuerySelector("ul>li>a.affixe").Text();
                        var sleep = element.QuerySelector("div.cheval-status>span>img") != null;

                        myHorse.Horses.Add(new Horses() {
                            Id = int.Parse(id), Name = name, Factory = factory, IsSleep = sleep
                        });
                    }
                }
            }

            return myHorse;
        }

        /// <summary>
        /// Получить информацию о лошади
        /// </summary>
        /// <param name="idHorse">Id Лошади</param>
        /// <returns></returns>
        public async Task GetHorseInfo(int idHorse)
        {
            using (var response = await _request.GetAsync(PageHorseInfo + idHorse))
                DataPageHorseInfo = await response.Content.ReadAsStringAsync();
        }

        private Dictionary<string, string> ParsInput(string pageInfo, string key, int index = 2, int max = 15)
        {
            IHtmlDocument document = new HtmlParser().ParseDocument(pageInfo);
            Dictionary<string, string> param = new Dictionary<string, string>();

            for (int i = index; index < max; i++)
            {
                if (document.QuerySelector($"#{key}>input:nth-child({i})") == null)
                    break;

                string name = document.QuerySelector($"#{key}>input:nth-child({i})").GetAttribute("name")
                    .ToLower();
                string cleareAll = Regex.Match(name, key + "(.*)").Groups[1].Value.ToLower();

                string value1 = document.QuerySelector($"#{key}>input:nth-child({i})").GetAttribute("value")
                    .ToLower();

                param.Add(cleareAll == "" ? name : cleareAll, value1);
            }

            return param;
        }

        private Dictionary<string, string> ParsInput(string pageInfo, string id, string key, int value)
        {
            IHtmlDocument document = new HtmlParser().ParseDocument(pageInfo);
            Dictionary<string, string> param = new Dictionary<string, string>();

            if (document.GetElementById(id) == null)
                return param;

            string name = document.GetElementById(id).GetAttribute("name").ToLower();
            string cleareAll = Regex.Match(name, key + "(.*)").Groups[1].Value.ToLower();

            param.Add(cleareAll == "" ? name : cleareAll, value.ToString());
            return param;
        }

        private int ParsData(string pageInfo, string selector)
        {
            IHtmlDocument document = new HtmlParser().ParseDocument(pageInfo);
            if (document.QuerySelector(selector) == null)
                return 0;

            var count = document.QuerySelector(selector).Text().Replace(" ", "");
            return int.Parse(count);
        }

        /// <summary>
        /// Уход - дать молока
        /// </summary>
        /// <param name="page">Страница где будем брать данные</param>
        /// <returns></returns>
        public async Task<ActionInfo> DoSuckle(string page = null)
        {
            var param = ParsInput(page ?? DataPageHorseInfo, "form-do-suckle");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoSuckle, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - Кормить
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoEat(int forageCount = 0, int oatsCount = 0, string page = null)
        {
            Dictionary<string, string> param = ParsInput(page ?? DataPageHorseInfo, "feeding");

            if (param.Count == 0)
                return null;

            if (forageCount == 0)
                forageCount = ParsData(page ?? DataPageHorseInfo, ".section-fourrage.section-fourrage-target");
            if (oatsCount == 0)
                oatsCount = ParsData(page ?? DataPageHorseInfo, ".section-avoine.section-avoine-target");

            var forage = ParsInput(page ?? DataPageHorseInfo, "haySlider-sliderHidden", "feeding", forageCount);
            if (forage.Count > 0)
                param.Add(forage.First().Key, forage.First().Value);

            var oats = ParsInput(page ?? DataPageHorseInfo, "oatsSlider-sliderHidden", "feeding", oatsCount);
            if (oats.Count > 0)
                param.Add(oats.First().Key, oats.First().Value);

            using (HttpResponseMessage response = await _request.PostAsync(PageDoEat, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - дать воды
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoDrink(string page = null)
        {
            var param = ParsInput(page ?? DataPageHorseInfo, "form-do-drink");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoDrink, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - Ласкать
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoStroke(string page = null)
        {
            var param = ParsInput(page ?? DataPageHorseInfo, "form-do-stroke");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoStroke, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - Чистить
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoGroom(string page = null)
        {
            var param = ParsInput(page ?? DataPageHorseInfo, "form-do-groom");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoGroom, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - Морковь
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoEatTreat(string page = null)
        {
            Dictionary<string, string> param = ParsInput(page ?? DataPageHorseInfo, "form-do-eat-treat-carotte");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoEatTreat, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - Играть
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoPlay(string page = null)
        {
            var param = ParsInput(page ?? DataPageHorseInfo, "formCenterPlay");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoPlay, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - Отправить спать
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoNight(string page = null)
        {
            var param = ParsInput(page ?? DataPageHorseInfo, "form-do-night");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoNight, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Уход - Вырастить
        /// </summary>
        /// <returns></returns>
        public async Task<RedirectInfo> DoAge(string page = null)
        {
            var param = ParsInput(page ?? DataPageHorseInfo, "age");
            if (param.Count == 0)
                return null;

            using (var response = await _request.PostAsync(PageDoAge, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<RedirectInfo>(content);
            }
        }

        /// <summary>
        /// Выполнить миссию
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoCentreMission(int idHorse)
        {
            Dictionary<string, string> param = new Dictionary<string, string>() { ["id"] = idHorse.ToString() };

            using (var response = await _request.PostAsync(PageDoCentreMission, param))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        struct Walks
        {
            public Walk Walk { get; set; }
            public string Id { get; set; }
            public string Key { get; set; }
        }

        /// <summary>
        /// Выполнить прогулки
        /// </summary>
        /// <param name="walk">Тип прогулки</param>
        /// <param name="value">На сколько сделать прогулку</param>
        /// <param name="page">Страница откуда берем данные</param>
        /// <returns></returns>
        public async Task<ActionInfo> DoWalk(Walk walk, int value = 1, string page = null)
        {
            Walks walks = new List<Walks>() {
                new Walks() { Walk = Walk.Foret, Key = "formbaladeForet", Id = "walkforetSlider-sliderHidden" },
                new Walks() { Walk = Walk.Montagne, Key = "formbaladeMontagne", Id = "walkmontagneSlider-sliderHidden" }
            }.First(x => x.Walk == walk);

            Dictionary<string, string> param = ParsInput(page ?? DataPageHorseInfo, walks.Key);
            if (param.Count == 0)
                return null;

            Dictionary<string, string> parsInput = ParsInput(page ?? DataPageHorseInfo, walks.Id, walks.Key, value);
            param.Add(parsInput.First().Key, parsInput.First().Value);

            using (HttpResponseMessage response = await _request.PostAsync(PageDoCentreMission, param))
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.Deserialize<ActionInfo>(content);
            }
        }

        /// <summary>
        /// Прогулка
        /// </summary>
        /// <returns></returns>
        public async Task<ActionInfo> DoTraining()
        {
            return null;
        }
    }
}