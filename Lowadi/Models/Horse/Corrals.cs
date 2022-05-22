using System;
using Lowadi.Models.Type;

namespace Lowadi.Models
{
    public class Corrals
    {
        public long Id { get; set; } = 0;
        public string Name { get; set; }
        public SexType SexType { get; set; }
        public int Skills { get; set; }
        public int Genetics { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string LinkBuy { get; set; }
    }
}