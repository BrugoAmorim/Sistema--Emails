using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class UsuariosResponse
    {
        public int Idusuario { get;set; }
        public string Email { get;set; }
        public string Senha { get;set; }
    }
}