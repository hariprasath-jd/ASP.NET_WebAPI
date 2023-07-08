using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Main.Models
{
    public class LoginData
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; } 
    }
}