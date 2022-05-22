
using System.Collections.Generic;
using System.Threading.Tasks;
using Lowadi.Models.Shop;
using Lowadi.Models.Type.Shops;

namespace Lowadi.Interface.Methods
{
    public interface IShop
    {
        Task<PurchaseInfo> Buy(ShopData ShopData);
        Task<PurchaseInfo> Sale(ShopData ShopData);
        Task<IList<ItemsInfo>> GetInformation(List<ItemsType> items);
    }
}