
using System.Collections.Generic;
using System.Threading.Tasks;
using Lowadi.Models.Shop;
using Lowadi.Models.Type.Shops;

namespace Lowadi.Interface.Methods
{
    public interface IShop
    {
        Task<Buy> Buy(ShopData ShopData);
        Task<Sell> Sale(ShopData ShopData);
        Task<IEnumerable<ItemsInfo>> GetInformation(List<ItemsType> items);
    }
}