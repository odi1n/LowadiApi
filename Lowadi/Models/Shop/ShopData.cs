using System.ComponentModel.DataAnnotations;
using Lowadi.Models.Type.Shops;

namespace Lowadi.Models.Shop
{
    public class ShopData : ReqData
    {
        public ItemsType Id { get; set; }
        [MinLength(1)] public int Nombre { get; set; } = 1;
        public string Mode { get; set; } = "eleveur";
    }
}