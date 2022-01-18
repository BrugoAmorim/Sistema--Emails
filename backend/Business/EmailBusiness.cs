using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class EmailBusiness
    {
        Database.EmailsDatabase banco = new Database.EmailsDatabase();
        public List<Models.TbEmailEnviado> buscaremailsenviados (int id)
        {
            Models.TbUsuario conta = banco.procuraruser(id);

            if(conta == null)
                throw new ArgumentException("Este email não foi encontrado");

            List<Models.TbEmailEnviado> lst = banco.procuraremails(conta);

            if(lst.Count == 0)
                throw new ArgumentException("Você ainda não enviou nenhum email");

            return lst;
        }

        public List<Models.TbEmailUsuario> buscaremailsrecebidos(int id)
        {
            Models.TbUsuario conta = banco.procuraruser(id);

            if(conta == null)
                throw new ArgumentException("Este email não foi encontrado");

            List<Models.TbEmailUsuario> naolidos = banco.caixademsg(id);

            if(naolidos.Count == 0)
                throw new ArgumentException("Você ainda não recebeu nenhum email");

            return naolidos;
        }

        public Models.TbEmailRecebido leremail(int idmail, int valor)
        {
            Models.TbEmailRecebido correspondencia = banco.procurarmail(idmail);
            bool lido;

            if(valor != 1 && valor != 0)
                throw new ArgumentException("Não foi possível marcar como lido");

            if(correspondencia == null)
                throw new ArgumentException("Este email não foi encontrado");

            if(valor == 1)
                lido = true;
            else
                lido = false;

            Models.TbEmailRecebido marcacao = banco.emaillido(idmail,lido);
            return marcacao;

        }
    }
}