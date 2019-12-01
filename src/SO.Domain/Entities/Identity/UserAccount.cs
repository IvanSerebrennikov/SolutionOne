using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SO.Domain.DataAccessInterfaces.Entity;

namespace SO.Domain.Entities.Identity
{
    public class UserAccount : IdentityUser, IEntity<string>
    {
    }
}
