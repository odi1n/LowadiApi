using System.Collections.Generic;
using Lowadi.Models.Type;
using Lowadi.Models.Type.Shops;

namespace Lowadi.Models
{


    public class Server
    {
        public ServerType ServerType { get; set; }
        public string Link { get; set; }
        public ICollection<Items> ItemsCollection;
    }

    public class Items
    {
        public ItemsType ItemsType { get; set; }
        public int Id { get; set; }
    }
}