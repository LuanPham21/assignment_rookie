using RookieShop.ViewModel.System;

namespace RookieAdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}