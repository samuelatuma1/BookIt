using BookIt.Core.Domain.Authentication.Enum;
using BookIt.Core.Domain.BaseApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Domain.Authentication.Model
{
    public class UserModel : BaseModel<Guid>
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }

        public string UserRoleText 
        {
            get
            {
                return UserRole.ToString();
            } 
        }
    }
}
