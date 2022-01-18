using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailsController : ControllerBase
    {
        Utils.EmailsEnviadoUtils converteremails = new Utils.EmailsEnviadoUtils();

        // funcao para enviar um email
        [HttpPost("enviar-email")]
        public ActionResult<Models.Response.EscreverResponse> escreveremail(Models.Request.EscreverRequest req){

            try{
            Business.EscreverEmailBusiness escreveremail = new Business.EscreverEmailBusiness();

            Models.TbEmailEnviado commit = escreveremail.validaremail(req);
            Models.Response.EscreverResponse caixatexto = converteremails.convertertb(commit);
            return caixatexto;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErroResponse(ex.Message, 400)
                );
            }
        }
    
        // funcao para ver os emails enviados, entra o id do usuario e retorna uma lista
        [HttpGet("emails-enviados/{idusuario}")]
        public ActionResult<List<Models.Response.EscreverResponse>> buscarmeusemails(int idusuario){

            try{
            Business.EmailBusiness buscarenviados = new Business.EmailBusiness();

            List<Models.TbEmailEnviado> emailsescritos = buscarenviados.buscaremailsenviados(idusuario);
            List<Models.Response.EscreverResponse> enviados = converteremails.listaenviadosPres(emailsescritos);
            return enviados;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.ErroResponse(ex.Message, 400)
                );
            }
        }

        // funcao para buscar os email recebidos, entra o id do usuario e retorna uma lista com os emails
        [HttpGet("emails-recebidos/{idusuario}")]
        public ActionResult<List<Models.Response.EmailsRecebidosResponse>> emailsparamim(int idusuario){

            try{
            Business.EmailBusiness caixadetexto = new Business.EmailBusiness();

            List<Models.TbEmailUsuario> naolidos = caixadetexto.buscaremailsrecebidos(idusuario);
            List<Models.Response.EmailsRecebidosResponse> novos =
            converteremails.lstemailuserPres(naolidos);

            return novos;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.ErroResponse(ex.Message, 400)
                );
            }
        }

        // funcao para deletar um email expecifico
        [HttpDelete("apagar-email/{idemail}")]
        public ActionResult<string> apagandoemails(int idemail){

            try{
                Business.DeletarEmailBusiness validar = new Business.DeletarEmailBusiness();
                validar.validardelete(idemail);
                return "O email foi deletado";
            }
            catch(System.Exception ex){
                return new BadRequestObjectResult(
                    new Models.ErroResponse(ex.Message, 404)
                );
            }
        }

        // funcao para marcar o email como lido ou desmarcar
        [HttpPut("marcar-lido/{idemail}/{lido}")]
        public ActionResult<Models.Response.EmailsRecebidosResponse> marcarcomolido(int idemail, int lido){

            try{
                Business.EmailBusiness validarleitura = new Business.EmailBusiness();

                Models.TbEmailRecebido email = validarleitura.leremail(idemail,lido);
                Models.Response.EmailsRecebidosResponse res = converteremails.tbemailPres(email);

                return res;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErroResponse(ex.Message, 404)
                );
            }
        }
    }
}