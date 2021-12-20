using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenges.Models
{
    public class UserModel : Microsoft.AspNetCore.Identity.IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
