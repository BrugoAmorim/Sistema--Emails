using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class TbEmailUsuario
    {
        public int IdEmailUsuario { get; set; }
        public int IdEmailRecebido { get; set; }
        public int IdUsuario { get; set; }

        public virtual TbEmailRecebido IdEmailRecebidoNavigation { get; set; }
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
    }
}
