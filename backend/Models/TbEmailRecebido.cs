using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class TbEmailRecebido
    {
        public TbEmailRecebido()
        {
            TbEmailUsuarios = new HashSet<TbEmailUsuario>();
        }

        public int IdEmailRecebido { get; set; }
        public string NmTitulo { get; set; }
        public string DsConteudo { get; set; }
        public string DsEmailRemetente { get; set; }
        public bool? BlLido { get; set; }
        public DateTime DtEnvio { get; set; }

        public virtual ICollection<TbEmailUsuario> TbEmailUsuarios { get; set; }
    }
}
