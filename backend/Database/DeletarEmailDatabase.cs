using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class DeletarEmailDatabase
    {
        Models.dbemailsContext db = new Models.dbemailsContext();
        public void deletar(int id)
        {
            Models.TbEmailUsuario email = db.TbEmailUsuarios.First(x => x.IdEmailUsuario == id);
            int idemail = email.IdEmailRecebido;

            db.TbEmailUsuarios.Remove(email);
            db.SaveChanges();

            Models.TbEmailRecebido naolidos = db.TbEmailRecebidos.First(x => x.IdEmailRecebido == idemail);
            db.TbEmailRecebidos.Remove(naolidos);
            db.SaveChanges();
        }

        public Models.TbEmailUsuario procurarparApagar(int id){

            Models.TbEmailUsuario procurando = db.TbEmailUsuarios.FirstOrDefault(x => x.IdEmailUsuario == id);
            return procurando;
        }
    }
}