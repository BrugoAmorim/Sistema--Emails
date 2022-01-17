using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailsEnviadosController : ControllerBase
    {
        Utils.EmailsEnviadoUtils converteremails = new Utils.EmailsEnviadoUtils();

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
    }
}