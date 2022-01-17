using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class EscreverEmailBusiness
    {
        Database.EscreverEmailsDatabase banco = new Database.EscreverEmailsDatabase();
        public Models.TbEmailEnviado validaremail(Models.Request.EscreverRequest req){

            Models.TbUsuario remetente = banco.validarconta(req.EmailRemetente);
            Models.TbUsuario destinatario = banco.validarconta(req.EmailDestinatario);
            
            if (string.IsNullOrEmpty(req.Titulo))
                throw new ArgumentException("É necessário adicionar um título ao email");

            if (string.IsNullOrEmpty(req.EmailRemetente))
                throw new ArgumentException("Você precisa adicionar um email válido");

            if (string.IsNullOrEmpty(req.EmailDestinatario))
                throw new ArgumentException("Você precisa adicionar um email válido");

            if (remetente == null)
                throw new ArgumentException("O email do remetente não existe");
                
            if (destinatario == null)
                throw new ArgumentException("O email do destinatário não existe");

            Models.TbEmailEnviado escrevendo = banco.inseriremail(req);
            return escrevendo;
        }
    }
}