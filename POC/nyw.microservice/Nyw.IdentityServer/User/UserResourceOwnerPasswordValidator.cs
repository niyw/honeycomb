using IdentityModel;
using IdentityServer4.Validation;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authentication;

namespace Nyw.IdentityServer.User {
    public class UserResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator {
        private readonly UserStore _users;
        private readonly ISystemClock _clock;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestUserResourceOwnerPasswordValidator"/> class.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="clock">The clock.</param>
        public UserResourceOwnerPasswordValidator(UserStore users, ISystemClock clock) {
            _users = users;
            _clock = clock;
        }

        /// <summary>
        /// Validates the resource owner password credential
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context) {
            if (_users.ValidateCredentials(context.UserName, context.Password)) {
                var user = _users.FindByUsername(context.UserName);
                context.Result = new GrantValidationResult(
                    user.SubjectId ?? throw new ArgumentException("Subject ID not set", nameof(user.SubjectId)),
                    OidcConstants.AuthenticationMethods.Password, _clock.UtcNow.UtcDateTime,
                    user.Claims);
            }

            return Task.CompletedTask;
        }
    }
}
