using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class TbEmailEnviado
    {
        public int IdEmailEnviado { get; set; }
        public string NmTitulo { get; set; }
        public string DsConteudo { get; set; }
        public string DsEmailDestinatario { get; set; }
        public DateTime DtEnvio { get; set; }
        public string DsEmailRemetente { get; set; }
    }
}
