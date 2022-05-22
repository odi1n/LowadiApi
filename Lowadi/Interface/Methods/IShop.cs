
using System.Collections.Generic;
using System.Threading.Tasks;
using Lowadi.Methods;
using Lowadi.Models.Shop;
using Lowadi.Models.Type.Shops;

namespace Lowadi.Interface.Methods
{
    public interface IShop
    {
        Task<ShopInfo> Buy(ShopData ShopData);
        Task<ShopInfo> Sale(ShopData ShopData);
        Task<IList<ShopInformation>> GetInformation(List<ItemsType> items);
    }
}