using BookIt.Core.Domain.Authentication.Enum;
using BookIt.Core.Domain.BaseApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Domain.Authentication.Entity
{
    public class User : BaseEntity<Guid>
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
    }
}
