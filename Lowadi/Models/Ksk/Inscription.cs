using System.ComponentModel.DataAnnotations;
using Lowadi.Models.Type.Ksk;

namespace Lowadi.Models.Ksk
{
    public class Inscription : ReqData
    {
        [Required] public int Cheval { get; set; }
        public string Elevage { get; set; }
        public double Competence { get; set; }

        public TriType TriType { get; set; } = TriType.Prestige;
        public SendType Sens { get; set; } = SendType.Asc;

        [Range(20, 200)] public int? Tarif { get; set; }
        [Range(0, 60)] public int? LeconsPrix { get; set; }

        public bool? Foret { get; set; } = null;
        public bool? Montagne { get; set; } = null;
        public bool? Plage { get; set; } = null;

        public bool? Classique { get; set; } = null;
        public bool? Western { get; set; } = null;

        public bool? Fourrage { get; set; } = null;
        public bool? Avoine { get; set; } = null;
        public bool? Carotte { get; set; } = null;
        public bool? Mash { get; set; } = null;
        public bool? HasSelles { get; set; } = null;
        public bool? HasBrides { get; set; } = null;
        public bool? HasTapis { get; set; } = null;
        public bool? HasBonnets { get; set; } = null;
        public bool? HasBandes { get; set; } = null;
        public bool? Hbreuvoir { get; set; } = null;
        public bool? Douche { get; set; } = null;

        public string Centre { get; set; }
        public int CentreBox { get; set; }
        public string Directeur { get; set; }
        [Range(0, 100)] public int? Prestige { get; set; }
        [Range(1, 40)] public int? Bonus { get; set; }

        public BotType? BoxType { get; set; }
        public LitterType BoxLitiere { get; set; }
        [Range(0, 100)] public int? PrePrestige { get; set; }

        public SellesType ProdSellesType { get; set; }
        public BridesType ProdBridesType { get; set; }
        public TapisType ProdTapisType { get; set; }
        public BonnetsType ProdBonnetsType { get; set; }
        public BandesType PropdBandesType { get; set; }
    }
}