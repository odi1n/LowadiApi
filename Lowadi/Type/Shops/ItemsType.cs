using System.ComponentModel;

namespace Lowadi.Models.Type.Shops
{
    public enum ItemsType
    {
        [Description("Овис")] Oats,
        [Description("Фураж")] Forage,
        [Description("Яблоко")] Apple,
        [Description("Морковь")] Carrot,
        [Description("Комбикорм")] CompoundFeed,
        [Description("Дерево")] Wood,
        [Description("Железо")] Iron,
        [Description("Песок")] Sand,
        [Description("Кожа")] Leather,
        [Description("Солома")] Straw,
        [Description("Лен")] Flax,
        [Description("Пшеница")] Wheat,
        [Description("Семена льна")] SeedsFlax,
        [Description("Семена яблок")] SeedsApple,
        [Description("Семена люцерны")] SeedsAlfalfa,
        [Description("Семена овса")] SeedsOat,
        [Description("Семена пшеницы")] SeedsWheat,
        [Description("Семена маркови")] SeedsCarrot,
        [Description("Семена пропуска")] SeedsPass,
        [Description("Удобрение 1")] Fertilizer_1,
        [Description("Удобрение 2")] Fertilizer_2,
        [Description("Навоз")] Manure,
    }
}