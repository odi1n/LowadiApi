using System.Threading.Tasks;
using Lowadi.Methods;
using Lowadi.Models.Ksk;

namespace Lowadi.Interface.Methods
{
    public interface IKsk
    {
        Task<string> CentreInscription(Inscription inscription, int idHorse);
    }
}