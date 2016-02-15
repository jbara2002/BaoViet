﻿using System.Threading.Tasks;

namespace BaoVietCore.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> WindowsHelloAuthen();

        AuthenticationResult PasswordAuthen(string input);

        Task<AuthenticationResult> RequestUserConsent();

        void CreatePassword(string password);

        void DeleteAccount();
    }

    public enum AuthenticationResult
    {
        NotAvailable,
        Success,
        Fail
    }
}