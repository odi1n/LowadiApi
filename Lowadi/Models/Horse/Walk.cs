using Lowadi.Models.Type;

namespace Lowadi.Models
{
    internal struct Walk
    {
        public WalkType WalkType { get; set; }
        public string Id { get; set; }
        public string Key { get; set; }
        public string Slider => this.Id + "-sliderHidden";
    }
}