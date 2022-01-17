using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class EscreverRequest
    {
        public string Titulo {get;set;}
        public string Conteudo {get;set;}
        public string EmailDestinatario {get;set;}
        public string EmailRemetente {get;set;}
    }
}