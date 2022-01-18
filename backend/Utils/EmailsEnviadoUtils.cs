using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Utils
{
    public class EmailsEnviadoUtils
    {
        // primeiro eu salvo o request na tabela de emails enviados
        public Models.TbEmailEnviado reqPtb(Models.Request.EscreverRequest req){

            Models.TbEmailEnviado enviando = new Models.TbEmailEnviado();

            enviando.NmTitulo = req.Titulo;
            enviando.DsConteudo = req.Conteudo;
            enviando.DsEmailRemetente = req.EmailRemetente;
            enviando.DsEmailDestinatario = req.EmailDestinatario;
            enviando.DtEnvio = DateTime.Now;

            return enviando;
        }

        // segundo, eu converto da tb enviado para a tabela email recebido
        public Models.TbEmailRecebido enviadoPrecebido (Models.TbEmailEnviado req)
        {
            Models.TbEmailRecebido emailrecebido = new Models.TbEmailRecebido();

            emailrecebido.NmTitulo = req.NmTitulo;
            emailrecebido.DsConteudo = req.DsConteudo;
            emailrecebido.DsEmailRemetente = req.DsEmailRemetente;
            emailrecebido.DtEnvio = req.DtEnvio;
            emailrecebido.BlLido = false;

            return emailrecebido;
        }

        // por ultimo eu pego o id do destinatario e pego o email que foi enviado para ele
        public Models.TbEmailUsuario inserirtbfrkey (int idusuario, Models.TbEmailRecebido req){

            Models.TbEmailUsuario emailrcebido = new Models.TbEmailUsuario();

            emailrcebido.IdEmailRecebido = req.IdEmailRecebido;
            emailrcebido.IdUsuario = idusuario;

            return emailrcebido;
        }

        public Models.Response.EscreverResponse convertertb (Models.TbEmailEnviado req){

            Models.Response.EscreverResponse res = new Models.Response.EscreverResponse();

            res.IdEmailEnviado = req.IdEmailEnviado;
            res.Titulo = req.NmTitulo;
            res.Conteudo = req.DsConteudo;
            res.EmailDestinatario = req.DsEmailDestinatario;
            res.EmailRemetente = req.DsEmailRemetente;
            res.HorarioEnvio = req.DtEnvio;

            return res;
        }

        public List<Models.Response.EscreverResponse> listaenviadosPres(List<Models.TbEmailEnviado> req)
        {

            List<Models.Response.EscreverResponse> escritos = new List<Models.Response.EscreverResponse>();

            foreach(Models.TbEmailEnviado item in req){

                escritos.Add(convertertb(item));
            }

            return escritos;
        }

        public Models.Response.EmailsRecebidosResponse tbemailuserPres(Models.TbEmailUsuario req){

            Models.Response.EmailsRecebidosResponse caixamsg = new Models.Response.EmailsRecebidosResponse();

            caixamsg.IdEmailRecebido = req.IdEmailRecebido;
            caixamsg.Titulo = req.IdEmailRecebidoNavigation.NmTitulo;
            caixamsg.Lido = req.IdEmailRecebidoNavigation.BlLido;
            caixamsg.Remetente = req.IdEmailRecebidoNavigation.DsEmailRemetente;
            caixamsg.HorarioEnvio = req.IdEmailRecebidoNavigation.DtEnvio;
            caixamsg.DConteudo = req.IdEmailRecebidoNavigation.DsConteudo;

            return caixamsg;
        }

        public List<Models.Response.EmailsRecebidosResponse> lstemailuserPres(List<Models.TbEmailUsuario> req){

            List<Models.Response.EmailsRecebidosResponse> lst = new List<Models.Response.EmailsRecebidosResponse>();

            foreach(Models.TbEmailUsuario item in req){

                lst.Add(tbemailuserPres(item));
            }
            
            return lst;
        }

        public Models.Response.EmailsRecebidosResponse tbemailPres(Models.TbEmailRecebido req){

            Models.Response.EmailsRecebidosResponse res = 
            new Models.Response.EmailsRecebidosResponse();

            res.IdEmailRecebido = req.IdEmailRecebido;
            res.Titulo = req.NmTitulo;
            res.Lido = req.BlLido;
            res.Remetente = req.DsEmailRemetente;
            res.HorarioEnvio = req.DtEnvio;
            res.DConteudo = req.DsConteudo;

            return res;
        }
    }
}