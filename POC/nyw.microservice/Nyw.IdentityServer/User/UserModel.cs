using IdentityModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace Nyw.IdentityServer.User {
    public class UserModel {
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Usermail { get; set; }
        public string MobilePhone { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>(new ClaimComparer());
    }
}
