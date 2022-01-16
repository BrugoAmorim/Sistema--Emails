using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class UsuariosDatabase
    {
        Models.dbemailsContext db = new Models.dbemailsContext();
        public Models.TbUsuario salvaruser(Models.Request.UsuariosRequest req){

            Models.TbUsuario user = new Models.TbUsuario();
            user.DsEmail = req.Email;
            user.DsSenha = req.Senha;

            db.TbUsuarios.Add(user);
            db.SaveChanges();

            return user;
        }

        public Models.TbUsuario validarlogin(Models.Request.LoginUsuarioRequest req)
        {
            List<Models.TbUsuario> users = db.TbUsuarios.ToList();

            Models.TbUsuario conta = users.FirstOrDefault(x => x.DsEmail == req.Email && x.DsSenha == req.Senha);
            return conta;
        }

        public Models.TbUsuario procurarconta(Models.Request.UsuariosRequest req)
        {
            List<Models.TbUsuario> users = db.TbUsuarios.ToList();

            Models.TbUsuario conta = users.FirstOrDefault(x => x.DsEmail == req.Email);
            return conta;
        }
    }
}