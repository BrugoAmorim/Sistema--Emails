using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class EmailsRecebidosResponse
    {
        public int IdEmailRecebido { get; set; }
        public string Titulo { get; set; }
        public string DConteudo { get; set; }
        public string Remetente { get; set; }
        public bool Lido { get; set; }
        public DateTime HorarioEnvio { get; set; }
    }
}