using System.Collections.Generic;
using Lowadi.Methods;

namespace Lowadi.Models
{
    public class MyHorse
    {
        public IList<Horses> Horses { get; set; }
        /// <summary>
        /// Страницы
        /// </summary>
        public Page Page { get; set; }
    }
}