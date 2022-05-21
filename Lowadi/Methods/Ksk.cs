using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lowadi.Attribute;
using Lowadi.Interface.Methods;
using Lowadi.Models.Ksk;
using Lowadi.Models.Type.Ksk;
using Lowadi.Others;

namespace Lowadi.Methods
{
    public class Ksk : IKsk
    {
        private Request _request;
        private string DataPageHorseInfo { get; set; }

        private const string PageMain = "https://www.lowadi.com";
        private const string PageCentreSelection = PageMain + "/elevage/chevaux/centreSelection";


        public Ksk(Request request)
        {
            _request = request;
        }

        /// <summary>
        /// Выбор Kck
        /// </summary>
        /// <param name="inscription">Настройки</param>
        /// <param name="idHorse">Id лошади</param>
        /// <returns></returns>
        /// <exception cref="ValidationException">Валидация данных</exception>
        public async Task<string> CentreInscription(Inscription inscription, int idHorse)
        {
            inscription.Cheval = idHorse;

            var validation = new ValidationContext(inscription);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(inscription, validation, results, true))
                throw new ValidationException(results.First().ErrorMessage);

            using (var response = await _request.PostAsync(PageCentreSelection, inscription.GetParam()))
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }
    }
}