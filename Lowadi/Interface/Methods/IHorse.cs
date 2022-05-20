using System.Collections.Generic;
using System.Threading.Tasks;
using Lowadi.Models;
using Lowadi.Models.Type;

namespace Lowadi.Interface.Methods
{
    public interface IHorse
    {
        ISale Sale { get; set; }

        Task<ICollection<Factory>> GetFactory();

        Task<MyHorse> GetAllHorse(int idFactory);
        Task GetHorseInfo(int idHorse);

        Task<ActionInfo> DoSuckle();
        Task<ActionInfo> DoEat(int forageCount = 0, int oatsCount = 0);
        Task<ActionInfo> DoDrink();
        Task<ActionInfo> DoStroke();
        Task<ActionInfo> DoGroom();
        Task<ActionInfo> DoEatTreat();
        Task<ActionInfo> DoPlay();
        Task<ActionInfo> DoNight();
        Task<RedirectInfo> DoAge();

        Task<ActionInfo> DoCentreMission(int idHorse);

        Task<ActionInfo> DoWalk(Walk walk, int value = 1);
    }
}