using Lowadi.Attribute;

namespace Lowadi.Models.Type.Ksk
{
    /// <summary>
    /// Выигрыш
    /// </summary>
    public enum SendType
    {
        [StringValue("DESC")] Desc,
        [StringValue("ASC")] Asc,
    }
}