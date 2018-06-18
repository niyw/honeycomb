using Nyw.IdentityServer.User;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Extension methods for the IdentityServer builder
    /// </summary>
    public static class IdentityServerBuilderExtensions {
        /// <summary>
        /// Adds test users.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddUserModel(this IIdentityServerBuilder builder) {
            builder.Services.AddSingleton(new UserStore());
            builder.AddProfileService<UserProfileService>();
            builder.AddResourceOwnerValidator<UserResourceOwnerPasswordValidator>();
            return builder;
        }
    }
}