namespace Ocelot.Administration {
    using System;
    using DependencyInjection;
    using IdentityServer4.AccessTokenValidation;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class OcelotBuilderExtensions {
        public static IOcelotBuilder AddAdministration(this IOcelotBuilder builder) {

            IConfiguration configuration = builder.Configuration;

            Action<IdentityServerAuthenticationOptions> idpOptions = o => {
                o.Authority = configuration.GetValue<string>("Idp:Authority");// @"http://localhost:8500";
                o.ApiName = configuration.GetValue("Idp:ApiName", "apigw.admin"); //"apigw.admin";
                o.RequireHttpsMetadata = configuration.GetValue("Idp:RequireHttpsMetadata", false); //false;
                o.SupportedTokens = SupportedTokens.Both;
            };

            builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                               .AddIdentityServerAuthentication(idpOptions);
            //return new OcelotAdministrationBuilder(builder.Services, builder.Configuration);
            return builder;
        }

    }
}
