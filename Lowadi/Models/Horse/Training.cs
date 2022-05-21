using Lowadi.Models.Type;

namespace Lowadi.Models
{
    internal struct Training
    {
        public TrainingType TrainingType { get; set; }
        public string Key { get; set; }

        public string Id { get; set; }
        public string Slider => this.Id + "-sliderHidden";
    }
}