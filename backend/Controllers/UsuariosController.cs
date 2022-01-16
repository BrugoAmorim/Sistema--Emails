using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {

        // funcao apenas para a busca de registros no banco, nao sera adicionada ao site
        [HttpGet("contascriadas")]
        public List<Models.TbUsuario> usuariosativos(){

            Models.dbemailsContext db = new Models.dbemailsContext();

            List<Models.TbUsuario> usuarioscadastrados = db.TbUsuarios.ToList();
            return usuarioscadastrados;
        }

        // funcao de criar nova conta, para novos usuarios
        [HttpPost("novaconta")]
        public ActionResult<Models.Response.UsuariosResponse> criarconta(Models.Request.UsuariosRequest objeto){

            try{
            Business.UsuariosBusiness validar = new Business.UsuariosBusiness();
            Models.Response.UsuariosResponse res = new Models.Response.UsuariosResponse();

            Models.TbUsuario conta = validar.validarconta(objeto);
            res.Idusuario = conta.IdUsuario;
            res.Email = conta.DsEmail;
            res.Senha = conta.DsSenha;

            return res;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.ErroResponse(ex.Message, 400)
                );
            }
        }

        // funcao de login, o usuario preenche o campo de email e senha e o sistema verifica se o usuario ja foi cadastrado
        [HttpPost("login")]
        public ActionResult<Models.Response.LoginUsuarioResponse> loginsistema(Models.Request.LoginUsuarioRequest req)
        {
            try{
            Business.LoginUsuarioBusiness logar = new Business.LoginUsuarioBusiness();
            Models.Response.LoginUsuarioResponse caixote = new Models.Response.LoginUsuarioResponse();

            Models.TbUsuario conta = logar.validarlogin(req);
            caixote.Email = conta.DsEmail;
            caixote.IdUsuario = conta.IdUsuario;

            return caixote;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.ErroResponse(ex.Message, 400)
                );
            }
        }
    }
}