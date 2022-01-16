using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class LoginUsuarioBusiness
    {
        public Models.TbUsuario validarlogin(Models.Request.LoginUsuarioRequest objeto)
        {
            Database.UsuariosDatabase consultar = new Database.UsuariosDatabase();
            Models.TbUsuario login = consultar.validarlogin(objeto);

            if(string.IsNullOrEmpty(objeto.Email))
                throw new ArgumentException("Você não preencheu o campo de Email");

            if(string.IsNullOrEmpty(objeto.Senha))
                throw new ArgumentException("Este campo é obrigátoro");
            
            if(login == null)
                throw new ArgumentException("Este usuário não existe");

            return login;
        }
    }
}