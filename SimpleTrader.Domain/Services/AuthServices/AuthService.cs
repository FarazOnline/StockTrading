using Microsoft.AspNet.Identity;
using StockTrader.Domain.Exceptions;
using StockTrader.Domain.Models;
using System;
using System.Threading.Tasks;
using static StockTrader.Domain.Services.AuthServices.IAuthService;

namespace StockTrader.Domain.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly ILoginService _AccService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(ILoginService AccService, IPasswordHasher passwordHasher)
        {
            _AccService = AccService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAcc = await _AccService.GetByUsername(username);
            PasswordVerificationResult PWVResult = _passwordHasher.VerifyHashedPassword(storedAcc.WhichUser.PasswordHash, password);
            if (PWVResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordX(username, password);
            }
            return storedAcc;
        }

        public async Task<RegResult> Register(string email, string username, string password, string cpassword)
        {
            RegResult RR = RegResult.Success;

            if (password != cpassword)
            {
                RR = RegResult.PWNotMatch;
            }

            Account emailAcc = await _AccService.GetByEmail(email);
            if (emailAcc != null)
            {
                RR = RegResult.EmailX;
            }

            Account userNameAcc = await _AccService.GetByUsername(username);
            if (userNameAcc != null)
            {
                RR = RegResult.UsernameX;
            }

            if (RR == RegResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPassword,
                    DateJoined = DateTime.Now
                };

                Account account = new Account()
                {
                    WhichUser = user
                };

                await _AccService.Create(account);
            }
            return RR;
        }
    }
}
