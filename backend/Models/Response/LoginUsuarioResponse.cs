using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class LoginUsuarioResponse
    {
        public int IdUsuario { get;set; }
        public string Email { get;set; }
    }
}