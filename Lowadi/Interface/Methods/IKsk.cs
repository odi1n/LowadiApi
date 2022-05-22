using System.Threading.Tasks;
using Lowadi.Models;
using Lowadi.Models.Ksk;

namespace Lowadi.Interface.Methods
{
    public interface IKsk
    {
        Task<CentreInscription> CentreInscription(Inscription inscription, int idHorse);
        Task<RedirectInfo> DoCentreInscription();
    }
}