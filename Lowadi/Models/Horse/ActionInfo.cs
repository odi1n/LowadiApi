using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lowadi.Models
{
    public partial class ActionInfo : ErrorModels
    {
        [JsonProperty("blocks")] public Blocks Blocks { get; set; }

        [JsonProperty("addClass")] public AddClass AddClass { get; set; }

        [JsonProperty("chevalSante")] public long ChevalSante { get; set; }

        [JsonProperty("chevalMoral")] public long ChevalMoral { get; set; }

        [JsonProperty("chevalEnergie")] public long ChevalEnergie { get; set; }

        [JsonProperty("coefficientEnergieEndurance")]
        public double CoefficientEnergieEndurance { get; set; }

        [JsonProperty("coefficientEnergievitesse")]
        public double CoefficientEnergievitesse { get; set; }

        [JsonProperty("coefficientEnergieGalop")]
        public double CoefficientEnergieGalop { get; set; }

        [JsonProperty("coefficientEnergieTrot")]
        public double CoefficientEnergieTrot { get; set; }

        [JsonProperty("coefficientEnergieSaut")]
        public double CoefficientEnergieSaut { get; set; }

        [JsonProperty("coefficientEnergieDressage")]
        public double CoefficientEnergieDressage { get; set; }

        [JsonProperty("enduranceValeur")] public double EnduranceValeur { get; set; }

        [JsonProperty("vitesseValeur")] public double VitesseValeur { get; set; }

        [JsonProperty("dressageValeur")] public double DressageValeur { get; set; }

        [JsonProperty("galopValeur")] public double GalopValeur { get; set; }

        [JsonProperty("trotValeur")] public double TrotValeur { get; set; }

        [JsonProperty("sautValeur")] public double SautValeur { get; set; }

        [JsonProperty("enduranceComplet")] public bool EnduranceComplet { get; set; }

        [JsonProperty("vitesseComplet")] public bool VitesseComplet { get; set; }

        [JsonProperty("dressageComplet")] public bool DressageComplet { get; set; }

        [JsonProperty("galopComplet")] public bool GalopComplet { get; set; }

        [JsonProperty("trotComplet")] public bool TrotComplet { get; set; }

        [JsonProperty("sautComplet")] public bool SautComplet { get; set; }

        [JsonProperty("enduranceBonus")] public string EnduranceBonus { get; set; }

        [JsonProperty("vitesseBonus")] public string VitesseBonus { get; set; }

        [JsonProperty("dressageBonus")] public string DressageBonus { get; set; }

        [JsonProperty("galopBonus")] public string GalopBonus { get; set; }

        [JsonProperty("trotBonus")] public string TrotBonus { get; set; }

        [JsonProperty("sautBonus")] public string SautBonus { get; set; }

        [JsonProperty("typeAddCompetences")] public object TypeAddCompetences { get; set; }

        [JsonProperty("canAddCompetences")] public List<object> CanAddCompetences { get; set; }

        [JsonProperty("listAddCompetences")] public List<object> ListAddCompetences { get; set; }

        [JsonProperty("skillMargins")] public List<object> SkillMargins { get; set; }

        [JsonProperty("varsB1")] public double VarsB1 { get; set; }

        [JsonProperty("varsB2")] public double VarsB2 { get; set; }

        [JsonProperty("varsB3")] public long VarsB3 { get; set; }

        [JsonProperty("varsB4")] public long VarsB4 { get; set; }

        [JsonProperty("varsB5")] public double VarsB5 { get; set; }

        [JsonProperty("varsB6")] public long VarsB6 { get; set; }

        [JsonProperty("varsE1")] public long VarsE1 { get; set; }

        [JsonProperty("varsE2")] public long VarsE2 { get; set; }

        [JsonProperty("varsE3")] public long VarsE3 { get; set; }

        [JsonProperty("varsE4")] public long VarsE4 { get; set; }

        [JsonProperty("varsE5")] public long VarsE5 { get; set; }

        [JsonProperty("varsE6")] public long VarsE6 { get; set; }

        [JsonProperty("chevalTemps")] public long ChevalTemps { get; set; }

        [JsonProperty("hourWarning")] public bool HourWarning { get; set; }

        [JsonProperty("marketingOperation")] public object MarketingOperation { get; set; }

        [JsonProperty("varsPlage")] public long VarsPlage { get; set; }

        [JsonProperty("chevalSpecialisation")] public object ChevalSpecialisation { get; set; }
    }

    public partial class AddClass
    {
        [JsonProperty("module-history")] public string ModuleHistory { get; set; }
    }

    public partial class Blocks
    {
        [JsonProperty("history-body-content")] public string HistoryBodyContent { get; set; }

        [JsonProperty("history-foot-content")] public string HistoryFootContent { get; set; }

        [JsonProperty("care-body-content")] public string CareBodyContent { get; set; }

        [JsonProperty("center-body-content")] public string CenterBodyContent { get; set; }

        [JsonProperty("competition-body-content")]
        public string CompetitionBodyContent { get; set; }

        [JsonProperty("status-body-content")] public object StatusBodyContent { get; set; }

        [JsonProperty("skills-body-content")] public object SkillsBodyContent { get; set; }

        [JsonProperty("mission-body-content")] public string MissionBodyContent { get; set; }

        [JsonProperty("training-body-content")]
        public string TrainingBodyContent { get; set; }

        [JsonProperty("hour-body-content")] public object HourBodyContent { get; set; }

        [JsonProperty("walk-body-content")] public string WalkBodyContent { get; set; }

        [JsonProperty("rosee-body-content")] public string RoseeBodyContent { get; set; }

        [JsonProperty("night-body-content")] public string NightBodyContent { get; set; }
    }
}