using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class UsuariosBusiness
    {
        Database.UsuariosDatabase banco = new Database.UsuariosDatabase();
        public Models.TbUsuario validarconta(Models.Request.UsuariosRequest req){

            Models.TbUsuario conta = banco.procurarconta(req);

            if(string.IsNullOrEmpty(req.Email))
                throw new ArgumentException("O campo email não foi preenchido");

            if(conta != null)
                throw new ArgumentException("Está email já foi registrado");

            if(!req.Email.Contains("@gmail.com") && !req.Email.Contains("@outlook.com"))
                throw new ArgumentException("Este email é inválido");

            if(string.IsNullOrEmpty(req.Senha))
                throw new ArgumentException("Você não definiu uma senha");

            if(req.Senha.Length < 8)
                throw new ArgumentException("Crie senhas com no mínimo 8 caracteres");

            if(req.Senha.Length > 20)
                throw new ArgumentException("O número máximo de caracteres foi atingido");

            if(req.ConfirmarSenha != req.Senha)
                throw new ArgumentException("A senha precisa ser a mesma nos dois campos");

            Models.TbUsuario contacriada = banco.salvaruser(req);
            return contacriada;
        }
    }
}