using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Identity
{
    public class ApplicationUserManager<TUser> : UserManager<TUser>  where TUser : class
    {
        public ApplicationUserManager(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, 
            IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger, IHttpContextAccessor contextAccessor)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger, contextAccessor)
        {
            optionsAccessor.Value.Password = new PasswordOptions { RequireDigit = false, RequiredLength = 6, RequireLowercase = false, RequireNonLetterOrDigit = false, RequireUppercase = false };
            this.RegisterTokenProvider("EmailTokenProvider", new EmailTokenProvider<TUser>());
            optionsAccessor.Value.Tokens.PasswordResetTokenProvider = "EmailTokenProvider";
        }
    }
}
