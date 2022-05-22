using Lowadi.Models.Type.Shops;

namespace Lowadi.Models.Shop
{
    public class ShopData : ReqData
    {
        public int Id { get; set; }
        public ItemsType ItemsType { get; set; }
        public string Mode { get; set; } = "eleveur";
    }
}