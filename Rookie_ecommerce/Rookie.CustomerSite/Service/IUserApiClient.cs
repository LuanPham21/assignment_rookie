using RookieShop.ViewModel.System;

namespace Rookie.CustomerSite.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}