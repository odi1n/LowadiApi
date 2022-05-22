using System.Threading.Tasks;

namespace Lowadi.Interface.Methods
{
    public interface IAuth
    {
        Task<string> Oauth(string userName, string password);
    }
}