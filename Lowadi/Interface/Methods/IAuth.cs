using System.Threading.Tasks;

namespace Lowadi.Interface.Methods
{
    public interface IAuth
    {
        string UserName { get; set; }
        string Password { get; set; }

        Task<string> Oauth();
    }
}