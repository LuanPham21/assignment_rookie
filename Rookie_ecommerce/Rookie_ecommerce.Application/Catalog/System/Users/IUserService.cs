using RookieShop.ViewModel.System;

namespace Rookie_ecommerce.Application.Catalog.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}