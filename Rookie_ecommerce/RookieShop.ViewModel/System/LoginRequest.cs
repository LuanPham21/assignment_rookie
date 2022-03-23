using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.ViewModel.System
{
    public class LoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}