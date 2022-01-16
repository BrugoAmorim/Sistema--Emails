using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ErroResponse
    {
        public int codigo { get;set; }
        public string motivo { get;set; }

        public ErroResponse (string motivo, int codigo){

            this.motivo = motivo;
            this.codigo = codigo;
        }
    }
}