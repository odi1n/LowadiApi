using System.Threading.Tasks;
using Lowadi.Methods;
using Lowadi.Models;

namespace Lowadi.Interface
{
    public interface ILowadiApi
    {
        Horse Horse { get; set; }
        HorseSale HorseSale { get; set; }
        Task<ErrorModels> Login(string login, string password);
    }
}