using IdentityModel;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System;


namespace Nyw.IdentityServer.User {
    public class UserStore {
        private readonly List<UserModel> _users = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestUserStore"/> class.
        /// </summary>
        /// <param name="users">The users.</param>
        public UserStore(/*List<MyUserModel> users*/) {
            //_users = users;
            if (_users == null) {
                _users = new List<UserModel> {
                    new UserModel{ SubjectId="1", Username="test1", Usermail="test1@qq.com", MobilePhone="13900000001", Password="P2ssw0rd", Claims=new List<Claim>{ new Claim("name", "test1"),new Claim("website", "https://test1.com") } },
                    new UserModel{ SubjectId="2", Username="test2", Usermail="test2@qq.com", MobilePhone="13900000002", Password="P2ssw0rd", Claims=new List<Claim>{ new Claim("name", "test2"),new Claim("website", "https://test2.com") }  },
                    new UserModel{ SubjectId="3", Username="test3", Usermail="test3@qq.com", MobilePhone="13900000003", Password="P2ssw0rd", Claims=new List<Claim>{ new Claim("name", "test3"),new Claim("website", "https://test3.com") }  },
                    new UserModel{ SubjectId="4", Username="test4", Usermail="test4@qq.com", MobilePhone="13900000004", Password="P2ssw0rd", Claims=new List<Claim>{ new Claim("name", "test4"),new Claim("website", "https://test4.com") }  },
                    new UserModel{ SubjectId="5", Username="test5", Usermail="test5@qq.com", MobilePhone="13900000005", Password="P2ssw0rd", Claims=new List<Claim>{ new Claim("name", "test5"),new Claim("website", "https://test5.com") }  }
                };
            }
        }

        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool ValidateCredentials(string username, string password) {
            var user = FindByUsername(username);
            if (user != null) {
                return user.Password.Equals(password);
            }

            return false;
        }

        /// <summary>
        /// Finds the user by subject identifier.
        /// </summary>
        /// <param name="subjectId">The subject identifier.</param>
        /// <returns></returns>
        public UserModel FindBySubjectId(string subjectId) {
            return _users.FirstOrDefault(x => x.SubjectId == subjectId);
        }

        /// <summary>
        /// Finds the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public UserModel FindByUsername(string username) {
            return _users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Finds the user by external provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public UserModel FindByExternalProvider(string provider, string userId) {
            /*return _users.FirstOrDefault(x =>
                x.ProviderName == provider &&
                x.ProviderSubjectId == userId);*/
            return null;
        }

        /// <summary>
        /// Automatically provisions a user.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claims">The claims.</param>
        /// <returns></returns>
        public UserModel AutoProvisionUser(string provider, string userId, List<Claim> claims) {
            // create a list of claims that we want to transfer into our store
            var filtered = new List<Claim>();

            foreach (var claim in claims) {
                // if the external system sends a display name - translate that to the standard OIDC name claim
                if (claim.Type == ClaimTypes.Name) {
                    filtered.Add(new Claim(JwtClaimTypes.Name, claim.Value));
                }
                // if the JWT handler has an outbound mapping to an OIDC claim use that
                else if (JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.ContainsKey(claim.Type)) {
                    filtered.Add(new Claim(JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap[claim.Type], claim.Value));
                }
                // copy the claim as-is
                else {
                    filtered.Add(claim);
                }
            }

            // if no display name was provided, try to construct by first and/or last name
            if (!filtered.Any(x => x.Type == JwtClaimTypes.Name)) {
                var first = filtered.FirstOrDefault(x => x.Type == JwtClaimTypes.GivenName)?.Value;
                var last = filtered.FirstOrDefault(x => x.Type == JwtClaimTypes.FamilyName)?.Value;
                if (first != null && last != null) {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first + " " + last));
                }
                else if (first != null) {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first));
                }
                else if (last != null) {
                    filtered.Add(new Claim(JwtClaimTypes.Name, last));
                }
            }

            // create a new unique subject id
            var sub = CryptoRandom.CreateUniqueId();

            // check if a display name is available, otherwise fallback to subject id
            var name = filtered.FirstOrDefault(c => c.Type == JwtClaimTypes.Name)?.Value ?? sub;

            // create new user
            var user = new UserModel {
                SubjectId = sub,
                Username = name,
                /*ProviderName = provider,
                ProviderSubjectId = userId,*/
                Claims = filtered
            };

            // add user to in-memory store
            _users.Add(user);

            return user;
        }

    }
}
