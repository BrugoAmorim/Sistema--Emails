using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class UsuariosRequest
    {
        public string Email { get;set; }
        public string Senha { get;set; }
        public string ConfirmarSenha { get;set; }
    }
}