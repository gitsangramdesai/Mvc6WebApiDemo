using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Identity
{
    public class RegistrationResult
    {
        public string UserId;
        public IdentityResult Result;
        public string Token;
    }

    public class AuthenticationResult
    {
        public SignInResult Result;
        public string token;
        public string UserId;
        public string FullName;
        public string PhoneNumber;
        public string DisplayName;
        public string RegisteredOn;
        public string Email;
        public string Role;
    }

    public class ForgotPasswordRequestResult
    {
        public string Email;
        public int RecoveryToken;
        public string RequestTime;
        public bool EmailAccountFound;
        public bool MailSend;
        public string code;
    }

    public class ForgotPasswordResultResponse
    {
        public string Email;
        public string RequestTime;
        public IdentityResult IdentityResult;
        public bool IsValidToken;
    }

    public class ChangePasswordResult
    {
        public string Email;
        public string RequestTime;
        public bool IsValidUserCredentials;
        public IdentityResult IdentityResult;
    }
}
