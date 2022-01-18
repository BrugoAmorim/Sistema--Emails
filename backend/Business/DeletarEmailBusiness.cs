using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class DeletarEmailBusiness
    {
        Database.DeletarEmailDatabase ctx = new Database.DeletarEmailDatabase();
        public void validardelete(int idemail)
        {
            Models.TbEmailUsuario email = ctx.procurarparApagar(idemail);

            if(email == null)
                throw new ArgumentException("Este email não foi encontrado");

            ctx.deletar(idemail);
        }
    }
}