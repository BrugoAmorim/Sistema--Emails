using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbEmailUsuarios = new HashSet<TbEmailUsuario>();
        }

        public int IdUsuario { get; set; }
        public string DsEmail { get; set; }
        public string DsSenha { get; set; }

        public virtual ICollection<TbEmailUsuario> TbEmailUsuarios { get; set; }
    }
}
