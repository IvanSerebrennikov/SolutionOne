using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Domain.UseCases.Account.Models
{
    public class UserAccountModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
