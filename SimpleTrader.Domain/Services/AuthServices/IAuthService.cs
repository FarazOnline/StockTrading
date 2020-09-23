using StockTrader.Domain.Models;
using System.Threading.Tasks;

namespace StockTrader.Domain.Services.AuthServices
{
    public interface IAuthService
    {
        enum RegResult
        {
            Success,
            PWNotMatch,
            EmailX,
            UsernameX
        }

        Task<RegResult>Register(string email, string username, string password, string confirmpassword);
        Task<Account>Login(string username, string password);
    }
}
