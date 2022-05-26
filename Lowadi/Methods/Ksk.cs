using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lowadi.Interface.Methods;
using Lowadi.Models;
using Lowadi.Models.Ksk;
using Lowadi.Others;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Lowadi.Methods
{
    public class Ksk : IKsk
    {
        private Request _request;
        private string DataPageHorseInfo { get; set; }

        private static string PageMain { get; set; }
        private static string PageCentreSelection => PageMain + "/elevage/chevaux/centreSelection";
        private static string PageDoCentreInscription => PageMain + "/elevage/chevaux/doCentreInscription";


        public Ksk(Request request, Server server)
        {
            PageMain = server.Link;
            _request = request;
        }

        /// <summary>
        /// Получить и отфильтровать кск
        /// </summary>
        /// <param name="inscription">Настройки</param>
        /// <param name="idHorse">Id лошади</param>
        /// <returns></returns>
        /// <exception cref="ValidationException">Валидация данных</exception>
        public async Task<CentreInscription> CentreInscription(Inscription inscription, int idHorse)
        {
            inscription.Cheval = idHorse;

            var validation = new ValidationContext(inscription);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(inscription, validation, results, true))
                throw new ValidationException(results.First().ErrorMessage);

            using (var response = await _request.PostAsync(PageCentreSelection, inscription.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                CentreInscription json = null;
                try
                {
                    json = JsonConvert.DeserializeObject<CentreInscription>(content);
                }
                catch (Exception e)
                {
                    DataPageHorseInfo = null;
                    return null;
                }

                DataPageHorseInfo = json.Content;
                return json;
            }
        }

        /// <summary>
        /// Записаться в КСК
        /// </summary>
        /// <returns></returns>
        public async Task<RedirectInfo> DoCentreInscription()
        {
            if (DataPageHorseInfo == null)
                return null;

            var linkRend = Regex.Match(DataPageHorseInfo, @"\{\'params\'\: \'id=(.*?)\'\}").Groups[1].Value;
            using (var response = await _request.PostAsync(PageDoCentreInscription, "id=" + linkRend))
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RedirectInfo>(content);
            }
        }
    }
}