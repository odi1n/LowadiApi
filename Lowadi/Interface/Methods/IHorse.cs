using System.Collections.Generic;
using System.Threading.Tasks;
using Lowadi.Methods;
using Lowadi.Models;
using Lowadi.Models.Type;

namespace Lowadi.Interface.Methods
{
    public interface IHorse
    {
        ISale Sale { get; set; }
        IKsk Ksk { get; set; }

        Task<ICollection<Factory>> GetFactory();

        Task<MyHorse> GetHorse(int idFactory, bool all = false);
        Task GetHorseInfo(int idHorse);

        Task<RedirectInfo> DoAge(string page = null);

        Task<ActionInfo> DoSuckle(string page = null);
        Task<ActionInfo> DoEat(int forageCount = 0, int oatsCount = 0, string page = null);
        Task<ActionInfo> DoDrink(string page = null);
        Task<ActionInfo> DoStroke(string page = null);
        Task<ActionInfo> DoGroom(string page = null);
        Task<ActionInfo> DoEatTreat(string page = null);
        Task<ActionInfo> DoPlay(string page = null);
        Task<ActionInfo> DoNight(string page = null);
        Task<ActionInfo> DoCentreMission(int idHorse);
        Task<ActionInfo> DoWalk(WalkType walkType, int value = 1, string page = null);
        Task<ActionInfo> DoTraining(TrainingType trainingType, int value = 1, string page = null);
    }
}