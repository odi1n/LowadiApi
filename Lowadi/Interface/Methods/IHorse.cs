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

        Task<string> DoSuckle();
        Task<string> DoEat(int forageCount = 0, int oatsCount = 0);
        Task<string> DoDrink();
        Task<string> DoStroke();
        Task<string> DoGroom();
        Task<string> DoEatTreat();
        Task<string> DoPlay();
        Task<string> DoNight();
        Task<string> DoAge();

        Task<string> DoCentreMission(int idHorse);

        Task<string> DoWalk(Walk walk, int value = 1);
    }
}