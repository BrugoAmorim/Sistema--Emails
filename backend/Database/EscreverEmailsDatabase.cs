using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class EscreverEmailsDatabase
    {
        Utils.EmailsEnviadoUtils conversoremails = new Utils.EmailsEnviadoUtils();
        Models.dbemailsContext db = new Models.dbemailsContext();
        
        // funcao para verificar se o email esta cadastrado no sistema
        public Models.TbUsuario validarconta (string email){

            Models.TbUsuario user = db.TbUsuarios.FirstOrDefault(x => x.DsEmail == email);
            return user;
        }

        // funcao que fara insercao em tres tabelas 
        public Models.TbEmailEnviado inseriremail (Models.Request.EscreverRequest req)
        {
            Models.TbUsuario user = validarconta(req.EmailDestinatario);

            Models.TbEmailEnviado enviar = conversoremails.reqPtb(req);
            db.TbEmailEnviados.Add(enviar);
            db.SaveChanges();

            Models.TbEmailRecebido recebendo = conversoremails.enviadoPrecebido(enviar);
            db.TbEmailRecebidos.Add(recebendo);
            db.SaveChanges();
            
            Models.TbEmailUsuario recebido = conversoremails.inserirtbfrkey(user.IdUsuario, recebendo);
            db.TbEmailUsuarios.Add(recebido);
            db.SaveChanges();

            return enviar;
        }
    }
}