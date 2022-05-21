using Lowadi.Attribute;

namespace Lowadi.Models.Type.Ksk
{
    /// <summary>
    /// Максимальный тариф
    /// </summary>
    public enum TriType
    {
        [StringValue("prestige")] Prestige,
        [StringValue("tarif1")] Tarif1,
        [StringValue("tarif2")] Tarif2,
        [StringValue("tarif3")] Tarif3,
        [StringValue("tarif4")] Tarif4,
        [StringValue("tarif5")] Tarif5,
    }
}