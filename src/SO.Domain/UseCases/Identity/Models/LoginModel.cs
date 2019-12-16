using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Domain.UseCases.Identity.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
