using System.Collections.Generic;
using System.Linq;
using Lowadi.Models.Type;
using Lowadi.Models.Type.Shops;

namespace Lowadi.Models
{
    public class ServerData
    {
        internal static ICollection<Server> Servers = new List<Server>() {
            // new Server() { ServerType = ServerType.EN, Link = "https://www.howrse.com" },
            // new Server() { ServerType = ServerType.US, Link = "https://us.howrse.com" },
            // new Server() { ServerType = ServerType.UK, Link = "https://www.howrse.co.uk" },
            // new Server() { ServerType = ServerType.AU, Link = "https://au.howrse.com" },
            // new Server() { ServerType = ServerType.CA, Link = "https://ca.howrse.com" },
            // new Server() { ServerType = ServerType.DE, Link = "https://www.howrse.de" },
            // new Server() { ServerType = ServerType.FR, Link = "https://www.equideow.com" },
            // new Server() { ServerType = ServerType.ES, Link = "https://www.caballow.com" },
            // new Server() { ServerType = ServerType.PT, Link = "https://www.howrse.com.pt" },
            // new Server() { ServerType = ServerType.BR, Link = "https://br.howrse.com" },
            // new Server() { ServerType = ServerType.IL, Link = "https://www.howrse.co.il" },
            new Server() {
                ServerType = ServerType.RU,
                Link = "https://www.lowadi.com",
                ItemsCollection = new List<Items>() {
                    new Items() { ItemsType = ItemsType.Oats, Id = 109 },
                    new Items() { ItemsType = ItemsType.Forage, Id = 446 },
                    new Items() { ItemsType = ItemsType.Apple, Id = 101 },
                    new Items() { ItemsType = ItemsType.Carrot, Id = 102 },
                    new Items() { ItemsType = ItemsType.CompoundFeed, Id = 447 },
                    new Items() { ItemsType = ItemsType.Wood, Id = 453 },
                    new Items() { ItemsType = ItemsType.Iron, Id = 454 },
                    new Items() { ItemsType = ItemsType.Sand, Id = 455 },
                    new Items() { ItemsType = ItemsType.Leather, Id = 456 },
                    new Items() { ItemsType = ItemsType.Straw, Id = 115 },
                    new Items() { ItemsType = ItemsType.Flax, Id = 114 },
                    new Items() { ItemsType = ItemsType.Wheat, Id = 169 },
                    new Items() { ItemsType = ItemsType.SeedsFlax, Id = 178 },
                    new Items() { ItemsType = ItemsType.SeedsApple, Id = 168 },
                    new Items() { ItemsType = ItemsType.SeedsAlfalfa, Id = 445 },
                    new Items() { ItemsType = ItemsType.SeedsOat, Id = 175 },
                    new Items() { ItemsType = ItemsType.SeedsWheat, Id = 177 },
                    new Items() { ItemsType = ItemsType.SeedsCarrot, Id = 176 },
                    new Items() { ItemsType = ItemsType.SeedsPass, Id = 157 },
                    new Items() { ItemsType = ItemsType.Fertilizer_1, Id = 125 },
                    new Items() { ItemsType = ItemsType.Fertilizer_2, Id = 126 },
                    new Items() { ItemsType = ItemsType.Manure, Id = 127 },
                }
            }
        };

        internal static string GetItemId(object convertedValue)
        {
            return Servers.First(x => x.ServerType == LowadiApi.Server.ServerType)
                .ItemsCollection.First(x => x.ItemsType == (ItemsType)convertedValue).Id.ToString();
        }

        internal static List<ItemsType> GetItemType(List<ItemsType> itemsTypes)
        {
            return ServerData.Servers.First(x => x.ServerType == LowadiApi.Server.ServerType)
                .ItemsCollection.Where(x => itemsTypes.Contains(x.ItemsType))
                .Select(x => x.ItemsType).ToList();
        }
    }
}