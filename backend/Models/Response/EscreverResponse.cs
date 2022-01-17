using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class EscreverResponse
    {
        public int IdEmailEnviado {get;set;}
        public string Titulo {get;set;}
        public string Conteudo {get;set;}
        public string EmailDestinatario {get;set;}
        public string EmailRemetente {get;set;}
        public DateTime HorarioEnvio {get;set;}
    }
}