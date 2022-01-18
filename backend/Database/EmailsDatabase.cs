using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class EmailsDatabase
    {
        Models.dbemailsContext db = new Models.dbemailsContext();
        
        public Models.TbUsuario procuraruser(int iduser){

            Models.TbUsuario conta = db.TbUsuarios.FirstOrDefault(x => x.IdUsuario == iduser);
            return conta;
        }
        
        public List<Models.TbEmailEnviado> procuraremails(Models.TbUsuario req)
        {
            List<Models.TbEmailEnviado> enviados = db.TbEmailEnviados
                                                     .Where(x => x.DsEmailRemetente == req.DsEmail)
                                                     .ToList();

            return enviados;
        }

        public List<Models.TbEmailUsuario> caixademsg (int iduser){

            List<Models.TbEmailUsuario> recebidos = db.TbEmailUsuarios.Where(x => x.IdUsuario == iduser).Include(x => x.IdEmailRecebidoNavigation).ToList();

            return recebidos;
        }

        // funcao para procurar o email, para assim marcar como lido
        public Models.TbEmailRecebido procurarmail(int id){

            Models.TbEmailRecebido notificacoes = db.TbEmailRecebidos.FirstOrDefault(x => x.IdEmailRecebido == id);

            return notificacoes;
        }

        //funcao que irá marcar o email como lido ou desmarcar
        public Models.TbEmailRecebido emaillido(int idmail, bool lido)
        {
            Models.TbEmailRecebido ler = db.TbEmailRecebidos.First(x => x.IdEmailRecebido == idmail);

            ler.BlLido = lido;
            db.SaveChanges();

            return ler;
        }
    }
}