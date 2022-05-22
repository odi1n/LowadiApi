using System.Threading.Tasks;
using Lowadi.Interface.Methods;
using Lowadi.Methods;
using Lowadi.Models;

namespace Lowadi.Interface
{
    public interface ILowadiApi
    {
        IHorse Horse { get; set; }
        IHorseSale HorseSale { get; set; }
        IShop Shop { get; set; }
        Task<ErrorModels> Login(string userName, string password);
    }
}